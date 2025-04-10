create database FMDB

use FMDB

create table users (
    user_id int primary key identity(1,1),
    username nvarchar(50) not null,
    password nvarchar(100) not null,
    email nvarchar(100) not null
);
--drop table users

create table expensecategories (
    category_id int primary key identity(101,1),
    category_name nvarchar(50) not null
);
--drop table expensecategories

create table expenses (
    expense_id int primary key identity(201,1),
    user_id int not null,
    amount decimal(10, 2) not null,
    category_id int not null,
    date date not null,
    description nvarchar(255),
    foreign key (user_id) references users(user_id),
    foreign key (category_id) references expensecategories(category_id)
);

--drop table expenses

insert into users (username, password, email) values
('keshav21', 'pass@123', 'keshavlal21@example.com'),
('arjun_p', 'arjun456', 'arjunp@example.com'),
('meena_s', 'meena789', 'meenas@example.com'),
('rahul_d', 'rahul999', 'rahuld@example.com'),
('divya_k', 'divya@321', 'divyak@example.com'),
('sanjay_v', 'sanjay@pass', 'sanjayv@example.com'),
('neha_m', 'neha!pass', 'neham@example.com'),
('vignesh_r', 'vicky007', 'vicky@example.com'),
('lakshmi_n', 'lakshmi123', 'lakshmin@example.com'),
('karthik_g', 'karthik456', 'karthikg@example.com');

insert into expensecategories (category_name) values
('Food'),
('Transport'),
('Utilities'),
('Entertainment'),
('Healthcare'),
('Education'),
('Travel'),
('Groceries'),
('Rent'),
('Miscellaneous');

insert into expenses (user_id, amount, category_id, date, description) values
(4, 200.00, 104, '2025-04-04', 'Movie night'),
(8, 180.00, 108, '2025-04-18', 'Weekly groceries'),
(2, 50.00, 102, '2025-04-02', 'Bus ticket'),
(10, 90.00, 110, '2025-04-20', 'Misc shopping'),
(6, 600.00, 106, '2025-04-16', 'Skill workshop'),
(9, 1000.00, 109, '2025-04-09', 'Monthly rent'),
(3, 120.75, 103, '2025-04-03', 'Electricity bill'),
(1, 60.00, 101, '2025-04-11', 'Snacks'),
(7, 1500.00, 107, '2025-04-17', 'Trip to Chennai'),
(2, 45.00, 102, '2025-04-12', 'Auto fare'),
(5, 130.00, 105, '2025-04-15', 'Medicines'),
(8, 220.00, 108, '2025-04-08', 'Monthly groceries'),
(10, 75.00, 110, '2025-04-10', 'Stationery items'),
(4, 250.00, 104, '2025-04-14', 'Concert ticket'),
(6, 500.00, 106, '2025-04-06', 'Online course'),
(9, 1050.00, 109, '2025-04-19', 'Rent paid in advance'),
(1, 150.00, 101, '2025-04-01', 'Lunch at restaurant'),
(7, 800.00, 107, '2025-04-07', 'Trip to Ooty'),
(5, 90.50, 105, '2025-04-05', 'Doctor consultation'),
(3, 110.00, 103, '2025-04-13', 'Water bill');

select * from users
select * from expensecategories
select * from expenses
