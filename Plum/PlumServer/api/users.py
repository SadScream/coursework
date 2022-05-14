import datetime, time
from flask import Blueprint, request
from flask_login import login_required, current_user
from typing import List

from sqlalchemy.sql.functions import user

from tools.response import *
from models.db_context import db, User

users_api = Blueprint('users_api', __name__)


@users_api.route("/users/", methods=['GET'])
@login_required
def get_users():
	list_users = db.session.query(User).all()

	data = {
		"ok": True,
		"users": list(map(user_to_json, list_users))
	}

	return data


@users_api.route("/users/<int:user_id>", methods=['GET'])
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


@users_api.route("/users/<string:login>", methods=['GET'])
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


@users_api.route("/users/<string:username>", methods=['GET'])
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
			"login": user_obj.login,
			"username": user_obj.username,
			"phone_visibility": user_obj.phone_visibility,
			"status": user_obj.status,
			"last_visit": user_obj.last_visit.strftime("%d.%m.%Y, %H:%M")}

	if user_obj.user_id == current_user.user_id or user_obj.phone_visibility:
		data.update({"phone_number": user_obj.phone_number})

	return data
