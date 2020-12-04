USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
);

CREATE TABLE pets (
	pet_id int IDENTITY(1,1) NOT NULL,
	breed varchar(64) NOT NULL,
	pet_age int,
	pet_name varchar(64) NOT NULL,
	pet_image varchar(200),
	is_adopted bit NOT NULL,
	arrival_date varchar(10) NOT NULL,
	adoption_date varchar(10),
	adopted_by varchar(64)
	CONSTRAINT PK_pet PRIMARY KEY (pet_id)
	
);
/*
CREATE TABLE species (
	species_id int IDENTITY(1,1) NOT NULL,
	species_name varchar(64) NOT NULL,
	CONSTRAINT PK_breed PRIMARY KEY (speciesId)
);

CREATE TABLE breeds (
	breed_id int IDENTITY(1,1) NOT NULL,
	breed_name varchar(64) NOT NULL,
	CONSTRAINT PK_breed PRIMARY KEY (breed_id)
);

AlTER TABLE pets 
ADD FOREIGN KEY(pet_type) REFERENCES breed(breed_id)
*/


--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

INSERT INTO pets (pet_type, pet_age, pet_name, pet_image, is_adopted, arrival_date, adoption_date, adopted_by) VALUES ('Elephant', 49, 'Mai-Thai', 'Image goes here', 0, '12-04-2010', '04/27/2020', 'Matt')
INSERT INTO pets (pet_type, pet_age, pet_name, pet_image, is_adopted, arrival_date, adoption_date, adopted_by) VALUES ('Dog', 2, 'Izzy', 'Image goes here', 0, '12/01/2010','08/19/2018', 'Zach')
INSERT INTO pets (pet_type, pet_age, pet_name, pet_image, is_adopted, arrival_date, adoption_date, adopted_by) VALUES ('Gecko', 4, 'Rango', 0, '12-04-2010')
INSERT INTO pets (pet_type, pet_age, pet_name, pet_image, is_adopted, arrival_date, adoption_date, adopted_by) VALUES ('Cat', 12, 'Choncky', 'Image goes here', 0, '12/02/2010', 'Isabella', '01/01/2018')

GO