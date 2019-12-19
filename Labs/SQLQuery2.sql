use master
go

drop database if exists ClimbingDB
go

create database ClimbingDB
go

use ClimbingDB
go

drop table if exists ClimbIndoors
go
drop table if exists ClimbOutdoors
go

create table ClimbIndoors
(
ClimbID int identity not null primary key,
ClimbName varchar(30) null,
ClimbGrade varchar(5) not null,
ClimbDone bit not null,
ClimbLocation varchar(50) not null 
)
go
create table ClimbOutdoors
(
ClimbID int identity not null primary key,
ClimbName varchar(30) null,
ClimbGrade varchar(5) not null,
ClimbDone bit not null,
ClimbLocation varchar(50) not null 
)
go
insert into ClimbIndoors values ('Blue in corner', 'v4', 1,'Harrowall')
insert into ClimbOutdoors values ('Dawn Wall', '5.14d', 0, 'Yosemite Valley')