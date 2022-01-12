Feature: Registration Tests

@tag1
Scenario: Successful Registration
	Given "Register" page is opened
	When The user fills following data for registration:
		| First name | Sir name | Email        | Password  | Country  | City   |
		| Ivan       | Petkov   | RANDOM_EMAIL | secret123 | Bulgaria | Burgas |
	And The user clicks on agree with terms of service
	And The user clicks on Register button
	Then The user is successfully registered