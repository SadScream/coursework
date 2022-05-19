import datetime
from sqlalchemy import or_, and_, desc, asc
from sqlalchemy.orm import contains_eager
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

	if not check_message(text):
		data["message"] = "Сообщение не может содержать 0 или более 1000 символов."
		return json_response(data, 422)

	date = datetime.datetime.fromtimestamp(r["date"])
	recipient = db.session.query(User).filter(User.user_id == r["recipient_id"]).first()

	if recipient and recipient != current_user:
		if recipient not in current_user.contacts:
			current_user.add_contact(recipient)

		message_obj = Message(owner=current_user, recipient=recipient, text=text, date=date)
		db.session.add(message_obj)
		db.session.commit()

		data["ok"] = True
		return json_response(data)

	data["message"] = "Пользователь не найден"
	return json_response(data, 404)


@msg_api.route("/messages/", methods=['GET'])
@login_required
def get_new_messages():
	data = {
		"ok": True
	}

	list_messages: List[Message] = db.session.query(Message).filter(
		and_(
			Message.recipient == current_user, Message.read.is_(False),
			Message.owner_id.in_(u.user_id for u in current_user.contacts)  # если отправителя есть в контактах
		)
	).all()

	data["messages"] = list(map(message_to_json, list_messages))

	return json_response(data)


@msg_api.route("/messages/history/<int:user_id>", methods=['GET'])
@login_required
def get_contact_messages(user_id):
	data = {
		"ok": False
	}

	user_obj: User = db.session.query(User).filter(User.user_id == user_id).first()

	if not user_obj:
		data["message"] = "Пользователя с таким идентификатором не существует"
		return json_response(data, 404)

	list_messages_query = db.session.query(Message).filter(
		or_(
			and_(
				Message.owner == user_obj,
				Message.recipient == current_user,
				Message.owner_id.in_(u.user_id for u in current_user.contacts)),  # если отправителя есть в контактах
			and_(
				Message.recipient == user_obj,
				Message.owner == current_user,
				Message.recipient_id.in_(u.user_id for u in current_user.contacts)  # если отправителя есть в контактах
			)
		)
	). \
		order_by(asc(Message.date))

	list_messages: List[Message] = list_messages_query.all()

	data["ok"] = True
	data["messages"] = list(
		map(lambda message: message_to_json(message, True if message.owner != current_user else False), list_messages))
	db.session.commit()

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


def message_to_json(message_obj: Message, set_read: bool = False) -> dict:
	if set_read and not message_obj.read:
		message_obj.read = True

	data = {
		"message_id": message_obj.message_id,
		"owner_id": message_obj.owner_id,
		"recipient_id": message_obj.recipient_id,
		"text": message_obj.text,
		"date": message_obj.date.strftime("%d.%m.%Y, %H:%M:%S.%f"),
		"read": message_obj.read
	}

	return data


def check_message(text: str):
	return 1 <= len(text) <= 1000
