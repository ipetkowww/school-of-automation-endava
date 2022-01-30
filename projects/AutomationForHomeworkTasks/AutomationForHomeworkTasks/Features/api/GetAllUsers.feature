@api
Feature: Get All Users API Test Cases

@get-all-users
Scenario: Get All Users Request
	When The user executes GET request to endpoint "/users"
	Then The user verifies status code is 200 with message "OK"
	And The user verifies data for the users is not null