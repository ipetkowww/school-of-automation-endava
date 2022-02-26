@ui
@register
Feature: Registration Tests

    Scenario Outline: Successful Registration
        Given "Register" page is opened
        When The user fills following data for registration:
          | First Name | Last name | Address      | City   | State  | Zip Code | SSN | Username        | Password | Confirm |
          | Ivan       | Petkov    | Test Address | Burgas | Burgas | 8008     | 056 | RANDOM_USERNAME | pass123  | pass123 |
        And The user clicks on Register button
        Then The user is successfully registered