import datetime
from flask import Blueprint, request
from flask_login import login_required, current_user, logout_user
from typing import List

from tools.response import *
from models.db_context import db, User, Message

msg_api = Blueprint('msg_api', __name__)


@msg_api.route("/messages/", methods=['POST'])
@login_required
def send_message():
	"""
	-> JSON {
		"text": str,
		"date": float
	}
	:return: JSON {'ok': true}
	"""

	r = request.json
	text = r["text"]
	date = datetime.datetime.fromtimestamp(r["date"])

	data = {
		"ok": False
	}

	if current_user:
		message_obj = Message(user_id=current_user.user_id, text=text, date=date)
		db.session.add(message_obj)
		db.session.commit()

		data["ok"] = True
		return json_response(data)

	data["message"] = "User not found"
	return json_response(data, 404)


@msg_api.route("/messages/", methods=['GET'])
@login_required
def get_messages():
	messages = []
	data = {
		"ok": False
	}

	from_date = request.args.get("timestamp")  # сообщения будут искаться начиная с этой даты

	if from_date is None:  # если дата не была передана, то ищем сообщения за 24 часа
		current_time = datetime.datetime.utcnow()
		from_date = current_time - datetime.timedelta(seconds=60 * 60 * 24)

	_messages: List[Message] = db.session.query(Message).filter(
		Message.to == current_user.user_id or Message.from_ == current_user.user_id
		and
		Message.date >= from_date
	).all()

	for msg in _messages:
		msg_json = {
			"message_id": msg.message_id,
			"username": msg.username,
			"user_id": msg.user_id,
			"text": msg.text,
			"date": msg.date.timestamp()
		}

		if msg.from_ != current_user.user_id:
			user: User = db.session.query(User).filter(User.user_id == msg.user_id).first()
			msg_json["username"] = user.username

		messages.append(msg_json)

	data["ok"] = True
	data["messages"] = messages
	return json_response(data)


@msg_api.route("/messages/<int:message_id>", methods=['GET'])
@login_required
def get_message(message_id):
	message_obj = db.session.query(User).filter(Message.message_id == message_id).first()

	data = {
		"ok": False
	}

	if message_obj:
		user: User = db.session.query(User).filter(User.user_id == message_obj.user_id).first()

		data["ok"] = True
		data["message_id"] = message_obj.message_id
		data["user_id"] = message_obj.user_id
		data["text"] = message_obj.text
		data["date"] = message_obj.date.timestamp()
		data["username"] = user.username

		return json_response(data)

	return json_response(data, 404)
