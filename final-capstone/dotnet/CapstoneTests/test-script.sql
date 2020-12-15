DELETE FROM pets;
DELETE FROM applications;
DELETE FROM users;
--populate default data
INSERT INTO pets (breed, pet_age, pet_name, pet_image, is_adopted, arrival_date, adoption_date, adopted_by) VALUES ('Elephant', 49, 'Mai-Thai', 'Image goes here', 0, '12-04-2010', '04/27/2020', 'Matt');
INSERT INTO pets (breed, pet_age, pet_name, pet_image, is_adopted, arrival_date, adoption_date, adopted_by) VALUES ('Dog', 2, 'Izzy', 'Image goes here', 0, '12/01/2010','08/19/2018', 'Zach');
INSERT INTO pets (breed, pet_age, pet_name, is_adopted, arrival_date) VALUES ('Gecko', 4, 'Rango', 1, '12-04-2010');
INSERT INTO pets (breed, pet_age, pet_name, pet_image, is_adopted, arrival_date, adoption_date, adopted_by) VALUES ('Cat', 12, 'Choncky', 'Image goes here', 0, '12/02/2010', 'Isabella', '01/01/2018');

INSERT INTO applications (username, email, phone_number, prompt_response, first_name, last_name, status) 
VALUES ('brotato', 'bro@tater.com', '555-444-5555', 'i like potate', 'bruh', 'bro', 1);

INSERT INTO applications (username, email, phone_number, prompt_response, first_name, last_name, status) 
VALUES ('catluvr', 'catluvr@gmail.com', '555-555-5555', 'I love cats', 'Crazy', 'CatLady', 1);

INSERT INTO users (username, password_hash, salt, user_role, first_name, last_name, email, phone_number, is_first_login)
VALUES ('mark', '234', '24', 'user', 'markie', 'markoo', 'email@gmail.com', '555-555-5555', 1)

INSERT INTO users (username, password_hash, salt, user_role, first_name, last_name, email, phone_number, is_first_login)
VALUES ('brotato', 'weifuhil', '2r897y3ef', 'admin', 'bruh', 'bro', 'bro@tater.com', '555-444-5555', 0)










