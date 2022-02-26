@api
Feature: CRUD Operations API Test Cases

    @create-user
    Scenario Outline: Create User
        When The user executes "POST" request to endpoint "/users" with body:
          | name        | gender | email   | status |
          | Ivan Petkov | male   | <email> | active |
        Then The user verifies status code is 201 with message "Created"
        And The user verifies that user with email "<email>" is successfully created

        Examples:
          | email                          |
          | ivan.petkov.auto@finalexam.com |

    @edit-user
    Scenario: Edit Existing User
        When The user executes "POST" request to endpoint "/users" with body:
          | name        | gender | email              | status |
          | Ivan Petkov | male   | <emailForCreation> | active |
        And The user executes "PATCH" request to endpoint "/users" with body:
          | name          | email          | status | gender |
          | Ivan Georgiev | <emailForEdit> | active | male   |
        Then The user verifies status code is 200 with message "OK"
        And The user verifies that user data is successfully edited

    Examples:
      | emailForCreation               | emailForEdit |
      | ivan.petkov.auto@finalexam.com | RANDOM_EMAIL |