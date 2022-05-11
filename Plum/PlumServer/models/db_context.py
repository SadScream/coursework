from flask_sqlalchemy import SQLAlchemy
from sqlalchemy.dialects.mysql import DATETIME
from flask_login import UserMixin
from typing import List
from werkzeug.security import generate_password_hash, check_password_hash

db = SQLAlchemy()


class User(db.Model, UserMixin):
	__tablename__ = 'user'
	user_id = db.Column(db.Integer, primary_key=True)
	login = db.Column(db.String(128), nullable=False, unique=True)
	username = db.Column(db.String(128), nullable=False, unique=True)
	phone_number = db.Column(db.String(16), nullable=True, unique=True)
	password_hash = db.Column(db.String(256), nullable=False)
	status = db.Column(db.String(256), nullable=True, unique=False)
	visit = db.Column(db.DateTime, nullable=False)

	contact_id = db.Column(db.Integer, db.ForeignKey('user.user_id'))
	contacts: List = db.relation('User', remote_side=[user_id], uselist=True, backref='contact')

	messages = db.relationship('Message', backref='owner')

	def __repr__(self):
		return "<{0}: {1}>".format(self.user_id, self.username)

	def get_id(self):
		return self.user_id

	def set_password(self, password):
		self.password_hash = generate_password_hash(password)

	def check_password(self, password):
		return check_password_hash(self.password_hash, password)


class Message(db.Model):
	__tablename__ = 'message'
	message_id = db.Column(db.Integer, primary_key=True)

	from_ = db.Column(
		"from",
		db.Integer,
		db.ForeignKey("user.user_id",
					  ondelete='CASCADE'),
	)

	to = db.Column(
		db.Integer,
		db.ForeignKey("user.user_id",
					  ondelete='CASCADE'),
	)

	text = db.Column(db.String(1024))
	date = db.Column(DATETIME(fsp=6), nullable=False)
