--TASK-1
--1.
create database SISDB

--2.
create table students(
	student_id int primary key,
	first_name varchar(20) not null,
	last_name varchar(20),
	date_of_birth date not null,
	email varchar(50) unique not null,
	phone varchar(15) not null,
)

create table teacher(
	teacher_id int primary key,
	first_name varchar(20) not null,
	last_name varchar(20),
	email varchar(50) unique not null,
)

create table courses(
	course_id int primary key,
	course_name varchar(50) unique not null,
	credits int,
	teacher_id int,
	foreign key (teacher_id) references teacher(teacher_id)
)
create table enrollment(
	enroll_id int primary key,
	student_id int,
	course_id int,
	enroll_date date not null,
	foreign key (student_id) references students(student_id),
	foreign key (course_id) references courses(course_id)
)

create table payments(
	payment_id int primary key,
	student_id int,
	amount int not null,
	payment_date date not null,
	foreign key (student_id) references students(student_id)
)

--5.

insert Students (student_id, first_name, last_name, date_of_birth, email, phone) values
(1, 'John', 'Doe', '2000-05-15', 'johndoe@example.com', '9876543210'),
(2, 'Alice', 'Smith', '1999-08-22', 'alicesmith@example.com', '9876543211'),
(3, 'Bob', 'Johnson', '2001-11-30', 'bobjohnson@example.com', '9876543212'),
(4, 'Emma', 'Brown', '2000-01-10', 'emmbrown@example.com', '9876543213'),
(5, 'Michael', 'Williams', '1998-07-20', 'michaelwilliams@example.com', '9876543214'),
(6, 'Sophia', 'Miller', '2002-04-05', 'sophiamiller@example.com', '9876543215'),
(7, 'Daniel', 'Davis', '2001-09-12', 'danieldavis@example.com', '9876543216'),
(8, 'Olivia', 'Martinez', '2003-06-25', 'oliviamartinez@example.com', '9876543217'),
(9, 'David', 'Anderson', '1999-03-18', 'davidanderson@example.com', '9876543218'),
(10, 'Emily', 'Wilson', '2000-12-01', 'emilywilson@example.com', '9876543219')


insert teacher (teacher_id, first_name, last_name, email) values
(10, 'William', 'Clark', 'william.clark@example.com'),
(20, 'Elizabeth', 'Taylor', 'elizabeth.taylor@example.com'),
(30, 'James', 'Harris', 'james.harris@example.com'),
(40, 'Sarah', 'Martin', 'sarah.martin@example.com'),
(50, 'Robert', 'Thompson', 'robert.thompson@example.com'),
(60, 'Jessica', 'White', 'jessica.white@example.com'),
(70, 'Thomas', 'Moore', 'thomas.moore@example.com'),
(80, 'Karen', 'Lee', 'karen.lee@example.com'),
(90, 'Richard', 'Hall', 'richard.hall@example.com'),
(100, 'Amanda', 'Young', 'amanda.young@example.com')

insert into Courses (course_id, course_name, credits, teacher_id) values
(101, 'Mathematics', 4, 10),
(102, 'Physics', 3, 30),
(103, 'Chemistry', 3, 20),
(104, 'Biology', 4, 40),
(105, 'History', 3, 70),
(106, 'Geography', 2, 60),
(107, 'English', 3, 50),
(108, 'Computer Science', 4, 90),
(109, 'Economics', 3, 100),
(110, 'Psychology', 3, 80)

insert Enrollment (enroll_id, student_id, course_id, enroll_date) values
(201, 1, 101, '2025-01-10'),
(202, 2, 102, '2025-01-12'),
(203, 3, 103, '2025-01-15'),
(204, 4, 104, '2025-01-18'),
(205, 5, 105, '2025-01-20'),
(206, 6, 106, '2025-01-22'),
(207, 7, 107, '2025-01-25'),
(208, 8, 108, '2025-01-28'),
(209, 9, 109, '2025-01-30'),
(210, 10, 110, '2025-02-01')


insert into Payments (payment_id, student_id, amount, payment_date) values
(111, 1, 5000, '2025-01-15'),
(112, 2, 4800, '2025-01-17'),
(113, 3, 4600, '2025-01-20'),
(114, 4, 4500, '2025-01-22'),
(115, 5, 4700, '2025-01-25'),
(116, 6, 4900, '2025-01-28'),
(117, 7, 5000, '2025-02-01'),
(118, 8, 5200, '2025-02-03'),
(119, 9, 5300, '2025-02-05'),
(120, 10, 5100, '2025-02-07')

--Task:2
--1.
insert into students( student_id,first_name,last_name,date_of_birth,email,phone) values
(11,'John' , 'Doe', '1995-08-15','john.doe@example.com','1234567890')

--2.
insert enrollment(enroll_id, student_id, course_id, enroll_date) values
(211,11,103,'2025-02-05')

--3.
update teacher
set email = 'jessica.white2022@example.com' 
where first_name ='Jessica' 

--4.
delete from enrollment
where student_id = 6 and course_id = 106

--5.
update courses
set teacher_id = 20
where course_id = 103

--6.
/*The student id has referential integerity so we have to delete the student data 
in order we do deleting like ==> ((enrollment , payment) -> student).Now the student data will be deleted. */

delete from enrollment
where student_id=3

delete from payments
where student_id = 3

delete from students
where student_id = 3 

--7.
update payments
set amount = 5120
where payment_id = 117 


--Task:3
--1.
select s.student_id,s.first_name as 'student name',sum(p.amount) as 'total payment' 
from students s join payments p 
on s.student_id = p.student_id 
where s.student_id = 8
group by s.student_id,s.first_name

--2.
select c.course_id,c.course_name as 'Course name', count(e.student_id) as 'students enrolled'
from courses c join enrollment e on c.course_id = e.course_id
group by c.course_id,c.course_name
order by c.course_id

--3.


select * from teacher
select * from enrollment
select * from students
select * from payments
select * from courses
