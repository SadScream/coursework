"""ondelete cascade

Revision ID: 58bca4d6c2f4
Revises: bddcf6e21c59
Create Date: 2022-05-19 15:55:01.499265

"""
from alembic import op
import sqlalchemy as sa


# revision identifiers, used by Alembic.
revision = '58bca4d6c2f4'
down_revision = 'bddcf6e21c59'
branch_labels = None
depends_on = None


def upgrade():
    op.drop_constraint(constraint_name="user_contact_ibfk_1", table_name="user_contact", type_="foreignkey")
    op.create_foreign_key(
        constraint_name="user_contact_ibfk_1",
        source_table="user_contact",
        referent_table="user",
        local_cols=["contact_id"],
        remote_cols=["user_id"],
        ondelete="CASCADE")
    op.drop_constraint(constraint_name="user_contact_ibfk_2", table_name="user_contact", type_="foreignkey")
    op.create_foreign_key(
        constraint_name="user_contact_ibfk_2",
        source_table="user_contact",
        referent_table="user",
        local_cols=["user_id"],
        remote_cols=["user_id"],
        ondelete="CASCADE")


def downgrade():
    pass
