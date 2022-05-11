import datetime, time
from flask import Blueprint, request
from flask_login import login_required, current_user, logout_user
from typing import List

from tools.response import *
from models.db_context import db, User, Message

user_api = Blueprint('user_api', __name__)


@user_api.route("/users/", methods=['GET'])
@login_required
def get_users():
	users = []
	data = {
		"ok": False
	}

	_users = db.session.query(User).all()

	for u in _users:
		user = {
			"user_id": u.user_id,
			"username": u.username,
		}
		users.append(user)

	data["ok"] = True
	data["users"] = users
	return data


@user_api.route("/contacts/", methods=['GET'])
@login_required
def get_contacts():
	contacts = []

	data = {
		"ok": False
	}

	_contacts: List[User] = db.session.query(User).filter(User in current_user.contacts).first()

	for u in _contacts:
		contacts.append(user_to_json(u))

	data["ok"] = True
	data["contacts"] = contacts
	return data


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
	user_obj = db.session.query(User).filter(User.username == username).first()

	if user_obj:
		data["message"] = "Username already taken"
		return json_response(data, 409)
	elif len(username):
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


@user_api.route("/users/<string:username>", methods=['GET'])
@login_required
def get_user_by_username(username):
	user_obj: User = db.session.query(User).filter(User.username == username).first()

	data = {
		"ok": False
	}

	if user_obj:
		data.update(user_to_json(user_obj))
		data["ok"] = True

		return json_response(data)

	return json_response(data, 404)


def user_to_json(user_obj: User) -> dict:
	data = {"ok": True,
			"user_id": user_obj.user_id,
			"username": user_obj.username,
			"phone_number": user_obj.phone_number,
			"status": user_obj.status,
			"visit": user_obj.visit}

	return data
