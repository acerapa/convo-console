# Create a table called users
# with the following columns:
# id, username, password, email, first_name, last_name, phone_number, created_at, updated_at
# id should be an auto-incrementing integer
# username should be a string with a maximum length of 255 characters
# password should be a string with a maximum length of 255 characters
# email should be a string with a maximum length of 255 characters
# first_name should be a string with a maximum length of 255 characters
# last_name should be a string with a maximum length of 255 characters
# phone_number should be a string with a maximum length of 255 characters
# created_at should be a timestamp with a default value of the current timestamp

CREATE TABLE IF NOT EXISTS `users` (
    `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `username` VARCHAR(255) NOT NULL UNIQUE,
    `password` VARCHAR(255) NOT NULL,
    `email` VARCHAR(255) NOT NULL UNIQUE,
    `first_name` VARCHAR(255) NOT NULL,
    `last_name` VARCHAR(255) NOT NULL,
    `phone_number` VARCHAR(255) NOT NULL,
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
)

