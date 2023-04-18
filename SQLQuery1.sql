create database Universidad

USE Universidad

create table Student (
idStudent int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
NameStudent varchar (30),
LastNameStudent varchar (30),
UsernameStudent varchar(30),
EmailStudent varchar(50),
PasswordStudent varchar(30),
)

create table Teacher (
idStudent int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
NameTeacher varchar (30),
LastNameTeacher varchar (30),
UsernameTeacher varchar(30),
EmailTeacher varchar(50),
PasswordTeacher varchar(30),
)

insert into Student values ('Carlos', 'Salazar', 'CarlosSalazar', 'carlossalazarrrrr@gmail.com', 'carlosalazar123')


insert into Teacher values ('Bismark', 'Montero', 'BismarkMontero', 'bismarkkmontero@gmail.com', 'bismalbismal')

select * from Student

select * from Teacher

drop table Student

select UsernameStudent, PasswordStudent from Student


CREATE TABLE Estudiantes (
    id INT PRIMARY KEY,
    nombre VARCHAR(50),
    apellido VARCHAR(50)
);


 


CREATE TABLE Maestros (
    id INT PRIMARY KEY,
    nombre VARCHAR(50),
    apellido VARCHAR(50)
);
