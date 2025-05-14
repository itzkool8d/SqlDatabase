University Enrollment System
This is a C# Windows Forms application connected to a MySQL database using XAMPP.

Open in Visual Studio for best readability. Code contained within forms, right click and select view code.

Requirements
XAMPP (MySQL running on port 3306)

Visual Studio with .NET Framework 4.8.2

Database
Database name: university

Requires tables for students, courses, sections, instructors, rooms, departments, enrollments, and users

Login Levels
User – For students. Can only view their enrolled classes.

Admin – Can view, search, and insert data into the database. Used for general administrative access.

Owner – Full access. Can manage users, roles, and all data within the system.


Demo Info: This is a demonstration of what kind of capabilities user's at different levels may have. When running program.cs, you will be prompted to a login screen, the following usernames and passwords may be used to access different levels of database control.

User:

Username: user

Password: user

Admin:

Username: admin

Password: admin

Owner:

Username: owner

Password: owner

Notes
Make sure MySQL is running on port 3306 and the university database is properly set up.

Connection settings may need to be updated in the source code depending on your local MySQL configuration.
