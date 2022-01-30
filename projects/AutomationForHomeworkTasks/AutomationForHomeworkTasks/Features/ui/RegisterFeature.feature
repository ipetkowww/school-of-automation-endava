@ui @register
Feature: Registration Tests

Scenario Outline: Successful Registration
	Given "Register" page is opened
	When The user fills following data for registration:
		| Title | First name | Sir name | Email        | Password  | Country  | City   |
		| Mr.   | Ivan       | Petkov   | RANDOM_EMAIL | secret123 | Bulgaria | Burgas |
	And The user clicks on agree with terms of service
	And The user clicks on Register button
	Then The user is successfully registered

Scenario: Unsuccessful Registration with Already Registered Email
	Given "Register" page is opened
	When The user fills following data for registration:
		| Title | First name | Sir name | Email                | Password  | Country  | City   |
		| Mr.   | Ivan       | Petkov   | admin@automation.com | secret123 | Bulgaria | Burgas |
	And The user clicks on agree with terms of service
	And The user clicks on Register button
	Then The error message for already existing email is displayed