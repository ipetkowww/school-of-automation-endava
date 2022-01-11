Feature: Login Tests

@login
Scenario: Successful login
	Given Login page is opened
	When The user logs in with email "admin@automation.com" and password "pass123"
	Then The user is logged in successfully

@login
Scenario Outline: Unsuccessful login
	Given Login page is opened
	When The user logs in with email "notexistingmail@test.com" and password "pass123"
	Then The 'Invalid user or email' error message is displayed