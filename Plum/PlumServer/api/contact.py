import datetime, time
from flask import Blueprint, request
from flask_login import login_required, current_user
from typing import List

from api.user import user_to_json
from tools.response import *
from models.db_context import db, User, Message

contact_api = Blueprint('contact_api', __name__)


@contact_api.route("/contacts/", methods=['GET'])
@login_required
def get_contacts():
	"""
	Возвращает список контактов авторизованного пользователя

	:return Response<200>:
		{
			"ok": bool,
			"contacts": list[User]
		}
	:rtype: json
	"""

	data = {
		"ok": True,
		"contacts": list(map(user_to_json, current_user.contacts))
	}

	return data


@contact_api.route("/contacts/", methods=['POST'])
@login_required
def add_contact():
	"""
	Принимает в POST-запросе JSON-объект, содержащий идентификатор пользователя, которого
	нужно добавить в контакты

	-> {
		"user_id": int
	}
	:return Response<200>:
		{
			'ok': true
		}
	:return Response<!200>:
		{
			"ok": bool,
			"message": str
		}
	:rtype: json
	"""

	data = {
		"ok": False
	}

	contact_id = request.json["user_id"]

	if current_user.user_id == contact_id:
		data["message"] = "Нельзя добавлять в контакты самого себя"
		return json_response(data, 405)

	contact = db.session.query(User).filter(User.user_id == contact_id).first()

	if contact:
		current_user.add_contact(contact)
		db.session.commit()
		data["ok"] = True

		return json_response(data)

	data["message"] = "Пользователь не найден"

	return json_response(data, 404)


@contact_api.route("/contacts/<int:user_id>", methods=['DELETE'])
@login_required
def delete_contact(user_id):
	"""
	Удаляет пользователя из списка контактов

	:param user_id: идентификатор пользователя
	:type user_id: int
	:return Response<200>:
		{
			"ok": bool
		}
	:return Response<!200>:
		{
			"ok": bool,
			"message": str
		}
	:rtype: json
	"""

	data = {
		"ok": False
	}

	contact = db.session.query(User).filter(User.user_id == user_id).first()

	if contact:
		current_user.remove_contact(contact)
		db.session.commit()
		data["ok"] = True

		return json_response(data)

	data["message"] = "Пользователь не найден"

	return json_response(data, 404)