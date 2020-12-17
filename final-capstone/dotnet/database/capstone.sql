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
	phone_number varchar(14) NOT NULL,
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
VALUES ('3', 'Roger', 'https://live.staticflickr.com/65535/50692703601_d9e9b23049_w.jpg', 1, '07/08/2019', '12/08/2020', 'Jason Picardi');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('2', 'Fred', 'https://live.staticflickr.com/65535/50691972548_e85879479d_w.jpg', 0, '02/07/2019');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('Hank Age 4, Dale Age 3', 'Hank and Dale', 'https://live.staticflickr.com/65535/50692717801_23d8ec2099_w.jpg', 0, '06/02/2019');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('8', 'Grace', 'https://live.staticflickr.com/65535/50692781287_9ea237ec1f_w.jpg', 0, '06/08/2019');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('49', 'Mai-Thai', 'https://live.staticflickr.com/65535/50696603332_eb7de29dd5_w.jpg', 0, '05/01/1978');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('3', 'Frida', 'https://live.staticflickr.com/65535/50692703616_3370d7881a_c.jpg', 0, '12/08/2019');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('3', 'Juniper', 'https://live.staticflickr.com/65535/50692781192_af5aeb2a35_c.jpg', 0, '09/09/2019');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('6', 'Willow', 'https://live.staticflickr.com/65535/50695131592_2c99144b3e_c.jpg', 0, '10/10/2019');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('2', 'Simone', 'https://live.staticflickr.com/65535/50694304838_7922a255e5_c.jpg', 0, '10/20/2019');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('5', 'Bear', 'https://live.staticflickr.com/65535/50694304848_0efe8c04f1_c.jpg', 0, '10/20/2019');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('2', 'George', 'https://live.staticflickr.com/65535/50692851887_c99e4f9db2_w.jpg', 0, '12/08/2020');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('3', 'Arlo', 'https://live.staticflickr.com/65535/50694818113_b17f16a73c_w.jpg', 0, '01/01/2020');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('8', 'Penny', 'https://live.staticflickr.com/65535/50719402142_649a4cb625_c.jpg', 0, '12/07/2012');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date, adoption_date, adopted_by)
VALUES ('4', 'Pepper', 'https://live.staticflickr.com/65535/50730014656_15924af337_w.jpg', 1, 'unknown', '09/23/17', 'Matt Jorgensen')

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date, adoption_date, adopted_by)
VALUES ('5', 'Flora', 'https://live.staticflickr.com/65535/50729282263_76bd72db55_w.jpg', 1, 'unknown', '02/24/15', 'Matt Jorgensen')

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('4', 'Sam', 'https://live.staticflickr.com/65535/50730110067_ba1bda8f0e_w.jpg', 0, '12/15/2020');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('14', 'Kilo', 'https://live.staticflickr.com/65535/50730014686_62a145b23f_w.jpg', 0, '10/1/2020');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('4', 'Kailani', 'https://live.staticflickr.com/65535/50729282193_a680377287_w.jpg', 0, '11/26/2020');

INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
VALUES ('9', 'Biggu', 'https://live.staticflickr.com/65535/50730110387_59072e3e2e_w.jpg', 0, '04/27/2020');

INSERT INTO applications (username, email, phone_number, prompt_response, first_name, last_name, status)
VALUES ('MRRuiz', 'matt.ruizeh@gmail.com', '(859)816-7648', 'Save the animals, bro', 'Matt', 'Ruiz', 1)

INSERT INTO applications (username, email, phone_number, prompt_response, first_name, last_name, status)
VALUES ('mj13', 'matt.jorgensen13@gmail.com', '(555)555-5555', 'I love animals', 'Matt', 'Jorgensen', 1)

INSERT INTO applications (username, email, phone_number, prompt_response, first_name, last_name, status)
VALUES ('Wiiilllsssooonn', 'zachary.l.wilson21@gmail.com', '(513)708-7973', 'Every animal deserves a loving family and a warm home! <3', 'Zach', 'Wilson', 1)

INSERT INTO applications (username, email, phone_number, prompt_response, first_name, last_name, status)
VALUES ('workmanZ', 'zacharyyy.1994@gmail.com', '(859)867-5309', 'Animals are people!', 'Zach', 'Workman', 1)
--INSERT INTO pets (pet_age, pet_name, pet_image, is_adopted, arrival_date)
--VALUES (, '', '', 0, 12/08/2020);
GO