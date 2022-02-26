@ui
Feature: Update User Info Test Cases

    @update-user-info
    Scenario: Update User Info
        Given The uer with following data is created:
          | First Name | Last name | Address      | City   | State  | Zip Code | SSN | Username   | Password   | Confirm    |
          | Ivan       | Petkov    | Test Address | Burgas | Burgas | 8008     | 056 | <username> | <password> | <password> |
        When The user clicks on Update Contact Info link from Account Services
        And The user updates the profile with the following data:
          | First Name | Last name | Address      | City     | State      | Zip Code |
          | FirstEdit  | LastEdit  | Edit Address | EditCity | EditBurgas | 123      |
        Then The user verifies profile info is updated

    Examples:
      | username        | password |
      | RANDOM_USERNAME | pass123  |