@ui
@login
Feature: Login Tests

    Scenario Outline: Successful login
        Given The uer with following data is created:
          | First Name | Last name | Address      | City   | State  | Zip Code | SSN | Username   | Password   | Confirm    |
          | Ivan       | Petkov    | Test Address | Burgas | Burgas | 8008     | 056 | <username> | <password> | <password> |
        And The user log outs from the system  
        And Login page is displayed
        When The user logs in with username "<username>" and password "<password>"
        Then The user is logged in successfully

        Examples:
          | username        | password |
          | RANDOM_USERNAME | pass123  |