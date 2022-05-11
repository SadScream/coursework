import datetime

from flask_sqlalchemy import SQLAlchemy
from sqlalchemy.dialects.mysql import DATETIME
from flask_login import UserMixin
from typing import List
from werkzeug.security import generate_password_hash, check_password_hash

db = SQLAlchemy()

user_contact_association = db.Table('user_contact', db.Model.metadata,
    db.Column('user_id', db.ForeignKey('user.user_id'), index=True),
    db.Column('contact_id', db.ForeignKey('user.user_id')),
	db.UniqueConstraint('user_id', 'contact_id', name='unique_contacts')
)


class User(db.Model, UserMixin):
	__tablename__ = 'user'
	user_id = db.Column(db.Integer, primary_key=True)
	login = db.Column(db.String(128), nullable=False, unique=True)
	username = db.Column(db.String(128), nullable=False)
	phone_number = db.Column(db.String(16), nullable=True, unique=True)
	phone_visibility = db.Column(db.Boolean, nullable=False, default=False)
	password_hash = db.Column(db.String(256), nullable=False)
	status = db.Column(db.String(256), nullable=True)
	last_visit = db.Column(db.DateTime, nullable=False, default=datetime.datetime.now())

	messages = db.relationship('Message', backref='owner', lazy=True, foreign_keys="[Message.owner_id]")
	contacts = db.relationship('User',
						   secondary=user_contact_association,
						   primaryjoin=user_id == user_contact_association.c.user_id,
						   secondaryjoin=user_id == user_contact_association.c.contact_id)

	def __repr__(self):
		return "<{0}: {1}>".format(self.user_id, self.username)

	def add_contact(self, contact):
		if contact not in self.contacts:
			self.contacts.append(contact)
			contact.contacts.append(self)

	def remove_contact(self, contact):
		if contact in self.contacts:
			self.contacts.remove(contact)
			contact.contacts.remove(self)

	def get_id(self):
		return self.user_id

	def set_password(self, password):
		self.password_hash = generate_password_hash(password)

	def check_password(self, password):
		return check_password_hash(self.password_hash, password)


class Message(db.Model):
	__tablename__ = 'message'
	message_id = db.Column(db.Integer, primary_key=True)

	owner_id = db.Column(
		db.Integer,
		db.ForeignKey("user.user_id",
					  ondelete='CASCADE'),
	)

	recipient_id = db.Column(
		db.Integer,
		db.ForeignKey("user.user_id",
					  ondelete='CASCADE'),
	)
	recipient = db.relationship("User", foreign_keys=[recipient_id])

	text = db.Column(db.String(4096))
	date = db.Column(DATETIME(fsp=6), nullable=False)
