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
		"recipient_id": int,
		"text": str,
		"date": float
	}
	:return: JSON {'ok': true}
	"""

	data = {
		"ok": False
	}

	r = request.json
	text = r["text"]
	date = datetime.datetime.fromtimestamp(r["date"])
	recipient = db.session.query(User).filter(User.user_id == r["recipient_id"]).first()

	if recipient:
		message_obj = Message(owner=current_user, recipient=recipient, text=text, date=date)
		db.session.add(message_obj)
		db.session.commit()

		data["ok"] = True
		return json_response(data)

	data["message"] = "Recipient not found"
	return json_response(data, 404)


@msg_api.route("/messages/", methods=['GET'])
@login_required
def get_messages():
	data = {
		"ok": True
	}

	from_date = request.args.get("timestamp")  # сообщения будут искаться начиная с этой даты

	if from_date is None:  # если дата не была передана, то ищем сообщения за 24 часа
		current_time = datetime.datetime.utcnow()
		from_date = current_time - datetime.timedelta(seconds=60 * 60 * 24)

	list_messages: List[Message] = db.session.query(Message).filter(
		Message.owner == current_user
		and
		Message.date >= from_date
	).all()

	data["messages"] = list(map(message_to_json, list_messages))

	return json_response(data)


@msg_api.route("/messages/<int:message_id>", methods=['GET'])
@login_required
def get_message(message_id):
	message_obj = db.session.query(User).filter(Message.message_id == message_id).first()

	data = {
		"ok": False
	}

	if message_obj:
		data["ok"] = True
		data.update(message_to_json(message_obj))

		return json_response(data)

	return json_response(data, 404)


def message_to_json(message_obj: Message) -> dict:
	data = {"owner_id": message_obj.owner_id,
			"recipient_id": message_obj.recipient_id,
			"recipient_username": message_obj.recipient.username,
			"text": message_obj.text,
			"date": message_obj.date.timestamp()}

	return data
