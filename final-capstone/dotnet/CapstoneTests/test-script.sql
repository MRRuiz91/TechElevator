DELETE FROM pets;
DELETE FROM applications;
--populate default data
INSERT INTO pets (breed, pet_age, pet_name, pet_image, is_adopted, arrival_date, adoption_date, adopted_by) VALUES ('Elephant', 49, 'Mai-Thai', 'Image goes here', 0, '12-04-2010', '04/27/2020', 'Matt');
INSERT INTO pets (breed, pet_age, pet_name, pet_image, is_adopted, arrival_date, adoption_date, adopted_by) VALUES ('Dog', 2, 'Izzy', 'Image goes here', 0, '12/01/2010','08/19/2018', 'Zach');
INSERT INTO pets (breed, pet_age, pet_name, is_adopted, arrival_date) VALUES ('Gecko', 4, 'Rango', 1, '12-04-2010');
INSERT INTO pets (breed, pet_age, pet_name, pet_image, is_adopted, arrival_date, adoption_date, adopted_by) VALUES ('Cat', 12, 'Choncky', 'Image goes here', 0, '12/02/2010', 'Isabella', '01/01/2018');

INSERT INTO applications (username, email, phone_number, prompt_response, first_name, last_name, status)
VALUES ('catluvr', 'catluvr@gmail.com', '555-555-5555', 'I love cats', 'Crazy', 'CatLady', 1);



