import datetime, time
from flask import Blueprint, request
from flask_login import login_required, current_user
from typing import List

from api.users import user_to_json, check_login, check_username, check_password, check_field_length
from tools.response import *
from models.db_context import db, User

user_api = Blueprint('user_api', __name__)


@user_api.route("/user/", methods=['GET'])
@login_required
def get_current_user():
	"""
	Возвращает информацию об авторизованном пользователе

	:return Response<200>:
		{
			"ok": bool,
			"user_id": int,
			"login": str,
			"username": str,
			"phone_visibility": bool,
			"phone_number": str,
			"status": str,
		}
	"""

	data = {"ok": True}
	data.update(user_to_json(current_user))

	return json_response(data)


@user_api.route("/user/", methods=['POST'])
@login_required
def update_fields():
	"""
	-> {
		"login"?: str,
		"username"?: str,
		"phone_number"?: str,
		"phone_visibility"?: bool,
		"password"?: str,
		"status"?: str,
	}
	:return Response<200>:
		{
			'ok': bool
		}
	:return Response<!200>:
		{
			'ok': bool,
			'message': str
		}
	:rtype: json
	"""

	data = {
		"ok": False
	}

	json: dict = request.json
	field_func = {
		"login": change_login,
		"username": change_username,
		"phone_number": change_phone_number,
		"phone_visibility": change_phone_visibility,
		"password": change_password,
		"status": change_status
	}

	changed = False

	for field in field_func.keys():
		if json.get(field) is not None and \
				(not hasattr(current_user, field) or json.get(field) != current_user.__getattr__(field)):

			if field == "password" and (len(json.get("password")) == 0 or current_user.check_password(json.get("password"))):
				continue

			changed = True
			res = field_func[field](json.get(field), data)

			if res != 200:
				db.session.commit()
				return json_response(data, res)

	if not changed:
		data["ok"] = True
		data["message"] = "Поля уже обновлены"

	db.session.commit()
	return json_response(data)


def change_login(new_login, data) -> int:
	user_obj = db.session.query(User).filter(User.login == new_login).first()

	if user_obj:
		data["message"] = "Этот логин уже используется"
		return 409
	elif check_login(new_login):
		current_user.login = new_login

		data["ok"] = True
		return 200

	data["message"] = ("Неправильный формат логина. "
					  "Логин должно быть не короче 3 символов и не длиннее 16, а также состоять из "
					   "букв латинского алфавита, цифр или символов *_()#!&")
	return 422


def change_username(new_username, data):
	if check_username(new_username):
		current_user.username = new_username

		data["ok"] = True
		return 200

	data["message"] = ("Неправильный формат имени. "
					  "Имя должно быть не короче 3 символов и не длиннее 16, а также состоять из "
					   "букв латинского алфавита, цифр или символов *_ ()#!&")
	return 422


def change_phone_number(new_phone_number, data):
	if check_field_length(new_phone_number, 11, 16):
		current_user.phone_number = new_phone_number

		data["ok"] = True
		return 200

	data["message"] = ("Неправильный номер телефона. Номер телефона не может быть короче "
					   "11 символов, а также не должен быть длиннее 16")
	return 422


def change_phone_visibility(new_phone_visibility, data):
	current_user.phone_visibility = new_phone_visibility

	data["ok"] = True
	return 200


def change_password(new_password, data):
	if check_password(new_password):
		current_user.set_password(new_password)

		data["ok"] = True
		return 200

	data["message"] = ("Неправильный формат пароля. Пароль должен быть длиной не менее 6 символов и не более 32, "
					   "а также состоять только из букв латинского алфавита и цифр")
	return 422


def change_status(new_status, data):
	if check_field_length(new_status, max_len=139):
		current_user.status = new_status

		data["ok"] = True
		return 200

	data["message"] = "Статус не может быть длиннее 139 символов"
	return 422
