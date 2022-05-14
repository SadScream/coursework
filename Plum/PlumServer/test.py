import datetime
import time

import requests
from requests.auth import HTTPBasicAuth


def registration(session: requests.Session, host: str, login: str, password: str):
	url = host % "sign-up/"

	r = session.post(url=url, json={
		"login": login,
		"password": password
	})

	print("REGISTRATION result: ", r.json(), "\n")
	return r.json()


def login(session: requests.Session, host: str, login: str, password: str):
	url = host % "sign-in/"
	r = session.get(url=url, auth=HTTPBasicAuth(login, password))

	print("LOGIN result: ", r.json(), "\n")
	return r.json()


def send_message(session: requests.Session, host: str, recipient_id: int, text: str):
	url = host % "messages/"
	r = session.post(url=url, json={
		"recipient_id": recipient_id,
		"text": text,
		"date": time.time()
	})

	print("SEND_MESSAGE result: ", r.json(), "\n")
	return r.json()


def add_contact(session: requests.Session, host: str, user_id: int):
	url = host % "contacts/"
	r = session.post(url=url, json={
		"user_id": user_id
	})

	print("ADD_CONTACT result: ", r.json(), "\n")
	return r.json()


def get_users(session: requests.Session, host: str):
	url = host % "users/"
	r = session.get(url)
	print("GET USERS result: ", r.json(), "\n")
	return r.json()


def get_messages(session: requests.Session, host: str):
	url = host % "messages/"
	r = session.get(url)
	print("GET MESSAGES result: ", r.json(), "\n")
	return r.json()


def get_contacts(session: requests.Session, host: str):
	url = host % "contacts/"
	r = session.get(url)
	print("GET CONTACTS result: ", r.json(), "\n")
	return r.json()


def change_username(session: requests.Session, host: str, new_username: str):
	url = host % "user/"

	r = session.post(url=url, json={
		"username": new_username
	})

	print("CHANGE USERNAME result: ", r.json(), "\n")
	return r.json()


def change_login(session: requests.Session, host: str, new_login: str):
	url = host % "user/"

	r = session.post(url=url, json={
		"login": new_login
	})

	print("CHANGE LOGIN result: ", r.json(), "\n")
	return r.json()


if __name__ == '__main__':
	host = "http://127.0.0.1:5000/api/%s"
	session = requests.Session()
	# registration(session, host, "saddy", "123")
	# registration(session, host, "sadscream", "123")
	# registration(session, host, "test", "test")
	# login(session, host, "sadscream", "123")
	# login(session, host, "saddy", "123")
	login(session, host, "ЖОПА", "test")
	# change_username(session, host, "saddysa")
	change_username(session, host, "аманчик")
	change_login(session, host, "эээ")

	# get_users(session, host)
	# send_message(session, host, 5, "hello!")
	# add_contact(session, host, 5)
	# add_contact(session, host, 6)
	# get_messages(session, host)
	# get_contacts(session, host)
