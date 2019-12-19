use master
go

drop database if exists TasksDB

create database TasksDB
go
use TasksDB
go
drop table if exists Tasks
drop table if exists Categories
drop table if exists Users
create table Categories
(
CategoryID int not null identity primary key,
CategoryName varchar(50) null,
)
create table Users
(
UserID int not null identity primary key,
UserName varchar(50) null
)

create table Tasks
(
TaskID int not null identity primary key,
CategoryID int null foreign key references Categories (CategoryID),
UserID int null foreign key references Users (UserID),
Description varchar(50) null,
Done bit null,
DateCompleted Date null
)
go
insert into Categories values ('Admin')
insert into Categories values ('Personal')
insert into Categories values ('Programming')
insert into Users values ('Ross')
insert into Users values ('James')
insert into Users values ('Tom')
insert into Tasks values (1,1,'Test 1',1,'2019-11-26')
insert into Tasks values (2,2,'Test 2',1,'2019-11-26')
insert into Tasks values (3,3,'Test 3',0, null)
select TaskID,
t.CategoryID,
CategoryName,
t.UserID,
UserName,
Description,
Done,
DateCompleted
from Tasks t
full join Users u on t.UserID = u.UserID
full join Categories c on t.CategoryID = c.CategoryID
select * from Users
select * from Tasks
select * from Categories