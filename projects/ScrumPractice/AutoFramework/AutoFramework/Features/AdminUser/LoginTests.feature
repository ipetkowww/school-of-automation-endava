@ui
Feature: LoginTests
	Simple calculator for adding two numbers

@admin
Scenario: Login as Admin User in Admin Panel
	Given The user opens Admin Portal "login" page
	When The user logs in into the system with username "admin" and password "admin123"
	