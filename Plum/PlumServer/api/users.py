import datetime, time
from flask import Blueprint, request
from sqlalchemy import or_, and_, desc, asc
from flask_login import login_required, current_user
from typing import List

from sqlalchemy.sql.functions import user

from string import ascii_letters
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


@users_api.route("/users/search/<string:query>", methods=['GET'])
@login_required
def search_users_by_query(query):
	def remove_non_digit(s: str):
		return ''.join(filter(str.isdigit, s))

	users: List[User] = db.session.query(User).filter(
		and_(
			User.user_id != current_user.user_id,
			User.user_id.not_in(u.user_id for u in current_user.contacts),
			or_(
				User.username.like(f"{query}%"),
				User.login.like(f"{query}%"),
				and_(User.phone_visibility.is_(True),
					 User.phone_number.regexp_replace('[^[:digit:]]', '').like(f"{remove_non_digit(query)}%"))
			)
		)
	).all()

	data = {
		"ok": True,
		"users": list(map(user_to_json, users))
	}

	return json_response(data)


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


def check_field_length(check_str: str, min_len: int = 0, max_len: int = 1000):
	return min_len <= len(check_str) <= max_len


def check_password(password: str):
	return check_field_length(password, 6, 32) and \
		   all(c.isdigit() or c in ascii_letters for c in password)


def check_username(username: str):
	return check_login(username, "*_ ()#!&")


def check_login(login: str, symbol_alphabet: str = None):
	if symbol_alphabet is None:
		symbol_alphabet = "*_()#!&"

	return check_field_length(login, 3, 16) and \
		   all(c.isdigit() or c in ascii_letters or c in symbol_alphabet for c in login)
