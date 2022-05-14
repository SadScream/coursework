import datetime, time
from flask import Blueprint, request
from flask_login import login_required, current_user
from typing import List

from api.users import user_to_json
from tools.response import *
from models.db_context import db, User

user_api = Blueprint('user_api', __name__)


@user_api.route("/user/", methods=['GET'])
@login_required
def get_current_user(user_id):
	data = {"ok": True}
	data.update(user_to_json(current_user))

	return json_response(data)


@user_api.route("/user/", methods=['POST'])
@login_required
def update_fields():
	"""
	-> JSON {
		"login"?: str,
		"username"?: str,
		"phone_number"?: str,
		"phone_visibility"?: bool,
		"password"?: str,
		"status"?: str,
	}
	:return: JSON {'ok': true}
	"""

	data = {
		"ok": False
	}

	json: dict = request.json

	if json.get("login") is not None and json.get("login") != current_user.login:
		return change_login(json.get("login"), data)
	if json.get("username") is not None and json.get("username") != current_user.username:
		return change_username(json.get("username"), data)
	if json.get("phone_number") is not None and json.get("phone_number") != current_user.phone_number:
		return change_phone_number(json.get("phone_number"), data)
	if json.get("phone_visibility") is not None and json.get("phone_visibility") != current_user.phone_visibility:
		return change_phone_visibility(json.get("phone_visibility"), data)
	if json.get("password") is not None and not current_user.check_password(json.get("password")):
		return change_password(json.get("password"), data)
	if json.get("status") is not None and json.get("login") != current_user.login:
		return change_status(json.get("status"), data)

	data["ok"] = True
	data["message"] = "Nothing to update"

	return json_response(data)


def change_login(new_login, data):
	user_obj = db.session.query(User).filter(User.login == new_login).first()

	if user_obj:
		data["message"] = "Этот логин уже используется"
		return json_response(data, 409)
	elif len(new_login):
		current_user.login = new_login
		db.session.commit()

		data["ok"] = True
		return json_response(data)

	data["message"] = "Неправильный формат логина. Логин должен быть не короче 3 символов и не длиннее 16"
	return json_response(data)


def change_username(new_username, data):
	if len(new_username):
		current_user.username = new_username
		db.session.commit()

		data["ok"] = True
		return json_response(data)

	data["message"] = "Неправильный формат имени. Имя должно быть не короче 3 символов и не длиннее 16"
	return json_response(data)


def change_phone_number(new_phone_number, data):
	if len(new_phone_number):
		current_user.phone_number = new_phone_number
		db.session.commit()

		data["ok"] = True
		return json_response(data)

	data["message"] = "Неправильный формат номера телефона"
	return json_response(data)


def change_phone_visibility(new_phone_visibility, data):
	current_user.phone_visibility = new_phone_visibility
	db.session.commit()

	data["ok"] = True
	return json_response(data)


def change_password(new_password, data):
	if len(new_password):
		current_user.set_password(new_password)
		db.session.commit()

		data["ok"] = True
		return json_response(data)

	data["message"] = ("Неправильный формат пароля. Пароль должен быть длиной не менее 6 символов и не более 32, "
					   "а также состоять только из букв латинского алфавита и цифр")
	return json_response(data)


def change_status(new_status, data):
	if len(new_status) > 256:
		current_user.status = new_status
		db.session.commit()

		data["ok"] = True
		return json_response(data)

	data["message"] = "Статус не может быть длиннее 256 символов"
	return json_response(data)
