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
	petId int IDENTITY(1,1) NOT NULL,
	petType varchar(64) NOT NULL,
	petAge int,
	petName varchar(64) NOT NULL,
	petImage varchar(200),
	isAdopted bit NOT NULL,
	arrivalDate dateTime NOT NULL,
	adoptionDate dateTime,
	adoptedBy varchar(64)
	CONSTRAINT PK_pet PRIMARY KEY (petId)
	
);

CREATE TABLE breed (
	breedId varchar(64) NOT NULL,
	breedName varchar(64) NOT NULL
	CONSTRAINT PK_breed PRIMARY KEY (breedId)
);

AlTER TABLE pets 
ADD FOREIGN KEY(petType) REFERENCES breed(breedId)



--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO