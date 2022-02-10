@api
Feature: CRUD Operations API Test Cases

@create-user
Scenario Outline: [PetStore API] Create User
	When The user executes "POST" request to endpoint "/user" with body:
		| id   | username   | firstName | lastName | email     | password | phone   | userStatus |
		| <id> | <username> | Ivan      | Petkov   | qa@qa.com | pas123   | 0000000 | 1          |
	Then The user verifies status code is 200 with message "OK"
	And The user verifies that user with id <id> and username "<username>" is successfully created

Examples:
	| id  | username   |
	| 123 | ivanpetkov |

@edit-user
Scenario: [PetStore API] Edit Existing User
	When The user executes "POST" request to endpoint "/user" with body:
		| id   | username   | firstName | lastName | email     | password | phone   | userStatus |
		| <id> | <username> | Ivan      | Petkov   | qa@qa.com | pas123   | 0000000 | 1          |
	When The user executes "PUT" request to endpoint "/user/<username>" with body:
		| id   | username   | firstName | lastName | email           | password  | phone | userStatus |
		| <id> | <username> | Ivan      | Petkov   | newemail@qa.com | parola123 | 007   | 100        |
	Then The user verifies that user data for username "<username>" is successfully edited

Examples:
	| id  | username   |
	| 123 | ivanpetkov |