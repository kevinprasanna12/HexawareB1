create database FM_DB
use FM_DB
--drop table users
create table users (
	users_id int primary key,
	username varchar(15) not null,
	password varchar(16) not null unique,
	email varchar(20) not null
)

--drop table expense_categories
create table expense_categories (
	category_id int primary key,
	category_name varchar(max)  
)

--drop table expenses

create table expenses(
	expense_id int primary key,
	users_id int not null,
	amount int not null,
	category_id int not null,
	exp_date date not null,
	exp_description varchar(max),
	foreign key (users_id) references users(users_id),
	foreign key (category_id) references expense_categories(category_id)
) 
