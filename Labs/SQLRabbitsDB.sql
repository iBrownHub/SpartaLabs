drop database if exists RabbitsDB
go
Create database RabbitsDB
go
use RabbitsDB
go
drop table if exists Rabbits
create table Rabbits
(
	RabbitID INT NOT NULL IDENTITY PRIMARY KEY,
	RabbitName VARCHAR(30) NULL,
	RabbitAge INT NULL
)
go
--insert into Rabbits values ('Honey', 2)
--insert into Rabbits values ('Midnight', 5)
--insert into Rabbits values ('Alfie', 3)
SELECT * FROM Rabbits