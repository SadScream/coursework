import datetime, time
from flask import Blueprint, request
from flask_login import login_required, current_user, logout_user, login_user

from api.users import check_login, check_password
from tools.response import *  # noqa
from models.db_context import db, User, Message  # noqa

auth_api = Blueprint('auth_api', __name__)


@auth_api.route('/sign-up/', methods=['POST'])
def sign_up():
	"""
	-> JSON {
		"username": str,
		"password": str
	}
	:return: JSON {'ok': true}
	"""

	data = {
		"ok": False
	}

	if current_user.is_authenticated:
		data["message"] = "Вы авторизованы"
		return json_response(data, 403)

	r = request.json
	login = r['login']
	password = r['password']

	user_obj = db.session.query(User).filter(User.login == login).first()

	if user_obj:
		data["message"] = "Этот логин уже занят"
		return json_response(data, 406)

	if check_login(login) and check_password(password):
		user = User(login=login, username=login)
		user.set_password(password)

		db.session.add(user)
		db.session.commit()

		data["ok"] = True

		return json_response(data)

	data["message"] = (
		"Логин должен быть не короче 3 символов и не длиннее 16, "
		"а также состоять только из букв латинского алфавита, цифр и "
		"символов *_()#!&.\n"
		"Пароль должен быть длиной не менее 6 символов и не более 32, "
		"а также состоять только из букв латинского алфавита и цифр")
	return json_response(data, 422)


@auth_api.route('/sign-in/', methods=['GET'])
def sign_in():
	'''
	BasicAuth метод авторизации

	-> HEADERS:
		Authorization: Basic <login:password>  *BASE64*
	:return: {
		"ok": bool,
		"user_id": int,
		"message": str
	}
	'''

	data = {
		"ok": False
	}

	if current_user.is_authenticated:
		data["ok"] = True
		data["message"] = "Вы уже авторизованы"
		return json_response(data, 200)

	remember: bool = request.args.get("remember") == "1"

	if request.authorization:
		login = request.authorization.username
		password = request.authorization.password
		user_obj = db.session.query(User).filter(User.login == login).first()

		if user_obj and user_obj.check_password(password):
			login_user(user_obj, remember=remember)
			data["ok"] = True
			data["user_id"] = user_obj.user_id

			return json_response(data)

		data["message"] = "Неправильный логин или пароль"
		return json_response(data, 403)

	data["message"] = "BasicAuth needs"
	return json_response(data, 401)


@auth_api.route('/logout/')
@login_required
def logout():
	'''
	Выход из учетной записи

	:return: {
		"ok": bool
	}
	'''

	logout_user()
	return json_response({"ok": True})