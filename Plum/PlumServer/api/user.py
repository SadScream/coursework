import datetime, time
from flask import Blueprint, request
from flask_login import login_required, current_user
from typing import List

from tools.response import *
from models.db_context import db, User, Message

user_api = Blueprint('user_api', __name__)


@user_api.route("/users/", methods=['GET'])
@login_required
def get_users():
	list_users = db.session.query(User).all()

	data = {
		"ok": True,
		"users": list(map(user_to_json, list_users))
	}

	return data


@user_api.route("/contacts/", methods=['GET'])
@login_required
def get_contacts():
	data = {
		"ok": True,
		"contacts": list(map(user_to_json, current_user.contacts))
	}

	return data


@user_api.route("/contacts/", methods=['POST'])
@login_required
def add_contact():
	"""
	-> JSON {
		"user_id": int,
	}
	:return: JSON {'ok': true}
	"""

	data = {
		"ok": False
	}

	r = request.json
	contact = db.session.query(User).filter(User.user_id == r["user_id"]).first()

	if contact:
		current_user.add_contact(contact)
		db.session.add(current_user)
		db.session.commit()
		data["ok"] = True

		return json_response(data)

	data["message"] = "User not found"

	return json_response(data, 404)


@user_api.route("/users/", methods=['POST'])
@login_required
def change_login():
	"""
	-> JSON {
		"new_login": str
	}
	:return: JSON {'ok': true}
	"""

	data = {
		"ok": False
	}

	login = request.json["new_login"]
	user_obj = db.session.query(User).filter(User.login == current_user.login).first()

	if user_obj:
		data["message"] = "Login is already taken"
		return json_response(data, 409)
	elif len(login):
		current_user.login = login

		db.session.add(current_user)
		db.session.commit()

		data["ok"] = True
		return json_response(data)  # noqa

	return json_response(data)  # noqa


@user_api.route("/users/", methods=['POST'])
@login_required
def change_username():
	"""
	-> JSON {
		"new_username": str
	}
	:return: JSON {'ok': true}
	"""

	data = {
		"ok": False
	}

	username = request.json["new_username"]

	if len(username):
		current_user.username = username

		db.session.add(current_user)
		db.session.commit()

		data["ok"] = True
		return json_response(data)  # noqa

	return json_response(data)  # noqa


@user_api.route("/users/<int:user_id>", methods=['GET'])
@login_required
def get_user_by_id(user_id):
	user_obj = db.session.query(User).filter(User.user_id == user_id).first()

	data = {
		"ok": False
	}

	if user_obj:
		data.update(user_to_json(user_obj))
		data["ok"] = True

		return json_response(data)

	return json_response(data, 404)


@user_api.route("/users/<string:login>", methods=['GET'])
@login_required
def get_user_by_login(login):
	user_obj: User = db.session.query(User).filter(User.login == login).first()

	data = {
		"ok": False
	}

	if user_obj:
		data.update(user_to_json(user_obj))
		data["ok"] = True

		return json_response(data)

	return json_response(data, 404)


@user_api.route("/users/<string:username>", methods=['GET'])
@login_required
def get_users_by_username(username):
	users: List[User] = db.session.query(User).filter(User.username == username).all()

	data = {
		"ok": False
	}

	if len(users):
		data["users"] = list(map(user_to_json, users))
		data["ok"] = True

		return json_response(data)

	return json_response(data, 404)


def user_to_json(user_obj: User) -> dict:
	data = {"user_id": user_obj.user_id,
			"username": user_obj.username,
			"phone_number": user_obj.phone_number,
			"status": user_obj.status,
			"last_visit": user_obj.last_visit.strftime("%d.%m.%Y, %H:%M")}

	if user_obj.user_id == current_user.user_id:
		data.update({"login": current_user.login})

	return data
