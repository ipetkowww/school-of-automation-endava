@ui
Feature: Add Question To Existing Assessment Test Test Cases
    As an Administrator
    I want to be able to add a question to an existing test

    Scenario: Verify a new question section can be added successfully
        Given The admin is logged in in Admin Portal
        And Assessment with name "AutoAssessmentTest" is created
        When The user clicks on Edit for assessment test with name "AutoAssessmentTest"
        And The user clicks on Add another button in Question section
        Then Question text field is displayed
        And Upload image button is displayed
        And Delete question button is displayed
        And The question has 3 answers available
        And Each answer has input text field with corresponding 'Is Correct' check-box and delete button

    Scenario: Verify user can delete a question section
        Given The admin is logged in in Admin Portal
        And Assessment with name "AutoAssessmentTest" is created
        When The user clicks on Edit for assessment test with name "AutoAssessmentTest"
        And The user clicks on Add another button in Question section
        And The user clicks on Delete button in Question section
        Then The question is deleted successfully
        
    Scenario: Verify a new answer field can be added successfully
        Given The admin is logged in in Admin Portal
        And Assessment with name "AutoAssessmentTest" is created
        When The user clicks on Edit for assessment test with name "AutoAssessmentTest"
        And The user clicks on Add another button in Question section
        And The user clicks on Add another button for an Answer
        Then The question has 4 answers available
        And Each answer has input text field with corresponding 'Is Correct' check-box and delete button