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
	user_role varchar(50) NOT NULL,
	first_name varchar(64),
	last_name varchar(64),
	email varchar(64),
	phone_number varchar(12),
	is_first_login bit

	CONSTRAINT PK_user PRIMARY KEY (user_id)
);

CREATE TABLE pets (
	pet_id int IDENTITY(1,1) NOT NULL,
	breed varchar(64),
	pet_age varchar(64),
	pet_name varchar(64) NOT NULL,
	pet_image varchar(200),
	is_adopted bit NOT NULL,
	arrival_date varchar(10) NOT NULL,
	adoption_date varchar(10),
	adopted_by varchar(64)
	CONSTRAINT PK_pet PRIMARY KEY (pet_id)
	
);

CREATE TABLE applications (
	application_id int IDENTITY(1,1) NOT NULL,
	username varchar(64) NOT NULL,
	email varchar(64) NOT NULL,
	phone_number varchar(12) NOT NULL,
	prompt_response varchar(500) NOT NULL,
	first_name varchar(64) NOT NULL,
	last_name varchar(64) NOT NULL,
	status int NOT NULL --1 = PENDING, 2= APPROVED, 3=DENIED
	CONSTRAINT PK_app PRIMARY KEY (application_id)

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
INSERT INTO users (username, password_hash, salt, user_role, is_first_login) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 0);

INSERT INTO users (username, password_hash, salt, user_role, is_first_login) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin', 0);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date,adoption_date, adopted_by)
VALUES ('3', 'Roger', 'https://live.staticflickr.com/65535/50692703601_19cbf11613_c.jpg', 1, 07/08/2019, 12/08/2020, 'Jason Picardi');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('2', 'Fred', 'https://live.staticflickr.com/65535/50691972548_e85879479d_w.jpg', 0, 02/07/2019);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('Hank Age 4, Dale Age 3', 'Hank and Dale', 'https://live.staticflickr.com/65535/50692717801_23d8ec2099_w.jpg', 0, 06/02/2019);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('8', 'Grace', 'https://live.staticflickr.com/65535/50692781287_9ea237ec1f_w.jpg', 0, 06/08/2019);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('3', 'Frida', 'https://live.staticflickr.com/65535/50692703616_3370d7881a_c.jpg', 0, 12/08/2019);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('3', 'Juniper', 'https://live.staticflickr.com/65535/50692781192_af5aeb2a35_c.jpg', 0, 09/09/2019);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('6', 'Willow', 'https://live.staticflickr.com/65535/50695131592_2c99144b3e_c.jpg', 0, 10/10/2019);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('2', 'Simone', 'https://live.staticflickr.com/65535/50694304838_7922a255e5_c.jpg', 0, 10/20/2019);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('5', 'Bear', 'https://live.staticflickr.com/65535/50694304848_0efe8c04f1_c.jpg', 0, 10/20/2019);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('2', 'George', 'https://live.staticflickr.com/65535/50692851887_c99e4f9db2_w.jpg', 0, 12/08/2020);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('3', 'Arlo', 'https://live.staticflickr.com/65535/50694818113_b17f16a73c_w.jpg', 0, 01/01/2020);

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('8', 'Penny', 'https://live.staticflickr.com/65535/50719402142_649a4cb625_c.jpg', 0, 12/07/2012);
--INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
--VALUES (, '', '', 0, 12/08/2020);
GO