CREATE DATABASE db_swift_send;

CREATE TABLE tblClass(
	clid INT AUTO_INCREMENT PRIMARY KEY,
    nameClass VARCHAR(30) NOT NULL,
    yearGroup VARCHAR(20) NOT NULL,
    numbr INT NOT NULL,
    CHECK(numbr >= 0 and numbr <= 100)
);
DROP TABLE tblClass;
INSERT INTO tblClass(nameClass, yearGroup, numbr) VALUES ("T Level Yr 1", "1st", 8), ("T Level Yr 2", "2nd", 7), ("AS CS Grp1", "1st", 16);

CREATE TABLE tblStudents( 
	stid INT AUTO_INCREMENT PRIMARY KEY,
    clid INT,
    FOREIGN KEY (clid) REFERENCES tblClass(clid),
    title VARCHAR(10) NOT NULL,
    forename VARCHAR(30) NOT NULL,
    surname VARCHAR(30) NOT NULL,
    email VARCHAR(100) NOT NULL -- stored procedure later
);

INSERT INTO tblStudents(clid, title, forename, surname, email) VALUES (1, 'Mr', 'Peter', 'Johnson', 'pjohnson@gmail.com'), (1, 'Mr', 'Sam', 'Holmes', 'sholmes@hotmail.com'), (1, 'Mrs', 'Karen', 'Peterson', 'kpeterson@hotmail.com'), (1, 'Mrs', 'Jennifer', 'Carlson', 'jcarlson@hotmail.com'), (1, 'Mr', 'Elliot', 'Burns', 'eb05263952@priestley.ac.uk');
INSERT INTO tblStudents(clid, title, forename, surname, email) VALUES (2, 'Mr', 'Alfie', 'Walters', 'aw05261696@priestley.ac.uk');

CREATE TABLE users (
    userID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    firstName VARCHAR(50) NOT NULL,
    lastName VARCHAR(50) NOT NULL,
    salt VARCHAR(50) NOT NULL,
    hashedPassword VARCHAR(100) NOT NULL
);

-- Inserting valuestblusers
INSERT INTO users(username, firstName, lastName, salt, hashedPassword)
VALUES ('admin', 'John', 'Smith', 'lksdfliesf', 'password123');

DROP TABLE users;

CREATE TABLE tblTemplate(
	tpid INT AUTO_INCREMENT PRIMARY KEY,
    templateName VARCHAR(20) NOT NULL,
    templateTitle VARCHAR(25) NOT NULL,
    templateMessage VARCHAR(200) NOT NULL
);

SELECT * FROM tblTemplate;

INSERT INTO tblTemplate(templateName, templateTitle, templateMessage) VALUES ('admin', 'John', 'Smith');
