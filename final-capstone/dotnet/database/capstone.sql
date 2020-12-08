USE master;
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
	breed varchar(64),
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

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date,adoption_date, adopted_by)
VALUES (3, 'Roger', 'https://flic.kr/p/2kexmF4', 1, 07/08/2019, 12/08/2020, 'Jason Picardi');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES (2, 'Fred', 'https://flic.kr/p/2ketBmG', 0, 02/07/2019);

INSERT INTO pets (pet_name, pet_image, is_adopted, arrival_date)
VALUES ('Hank and Dale', 'https://flic.kr/p/2kexqTT', 0, 06/02/2019);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES (8, 'Grace', 'https://flic.kr/p/2kexKLt', 0, 06/08/2019);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES (3, 'Frida', 'https://flic.kr/p/2kexmFj', 0, 12/08/2019);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES (3, 'Juniper', 'https://flic.kr/p/2kexKJQ', 0, 09/09/2019);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES (6, 'Willow', 'https://flic.kr/p/2keKNqY', 0, 10/10/2019);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES (2, 'Simone', 'https://flic.kr/p/2keFyEA', 0, 10/20/2019);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES (5, 'Bear', 'https://flic.kr/p/2keFyEL', 0, 10/20/2019);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES (2, 'George', 'https://flic.kr/p/2key7KH', 0, 12/08/2020);

INSERT INTO pets (pet_age, pet_name, is_adopted, arrival_date)
VALUES (3, 'Arlo', 0, 01/01/2020);

--INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
--VALUES (, '', '', 0, 12/08/2020);
GO