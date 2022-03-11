@ui
@create-assessment
Feature: Create Assessment Test Cases

    Scenario: Create Assessment Page Elements Check
        Given The admin is logged in in Admin Portal
        When The admin clicks on Add button for "Tests" field
        Then "Title" field is displayed
        And "Duration" field is displayed
        And "Technologies" field is displayed
        And Choose all button is displayed
        And Question section is displayed
        And Add another button button is displayed in Question section
        And Save and add another button is displayed
        And Save and continue editing button is displayed
        And SAVE button is displayed

    Scenario Outline: Verify Admin can create a new Assessment Test only with mandatory fields
        Given The admin is logged in in Admin Portal
        When The admin clicks on Add button for "Tests" field
        And The admin fills title "<title>"
        And The admin fills number "2" for duration
        And The admin clicks on SAVE button
        Then The admin verifies that assessment test with name "<title>" is successfully created

        Examples:
          | title              |
          | AutoTestAssessment |

    Scenario: Create Assessment Test without Title
        Given The admin is logged in in Admin Portal
        When The admin clicks on Add button for "Tests" field
        And The admin fills number "2" for duration
        And The admin clicks on SAVE button
        Then Please correct the error below message is displayed
        And This field is required error message is displayed for "Title" field

    Scenario: Create Assessment Test without Duration
        Given The admin is logged in in Admin Portal
        When The admin clicks on Add button for "Tests" field
        And The admin fills title "AutoTestAssessment"
        And The admin clicks on SAVE button
        Then Please correct the error below message is displayed
        And This field is required error message is displayed for "Duration" field

    Scenario Outline: Verify Duration field accepts only digits between 1 and 999 included
        Given The admin is logged in in Admin Portal
        When The admin clicks on Add button for "Tests" field
        And The admin fills title "<title>"
        And The admin fills number "<duration>" for duration
        And The admin clicks on SAVE button
        Then The admin verifies that assessment test with name "<title>" is successfully created

        Examples:
          | title              | duration |
          | AutoTestAssessment | 1        |
          | AutoTestAssessment | 2        |
          | AutoTestAssessment | 998      |
          | AutoTestAssessment | 999      |

    Scenario Outline: Verify Duration field cannot accept digits lower than 1 and grater than 999
        Given The admin is logged in in Admin Portal
        When The admin clicks on Add button for "Tests" field
        And The admin fills title "<title>"
        And The admin fills number "<duration>" for duration
        And The admin clicks on SAVE button
        Then Please correct the error below message is displayed
        And Ensure this value is less than or equal to <duration> error message is displayed

        Examples:
          | title              | duration |
          | AutoTestAssessment | 0        |
          | AutoTestAssessment | 1000     |

    Scenario: Verify elements of Question Section
        Given The admin is logged in in Admin Portal
        When The admin clicks on Add button for "Tests" field
        And The user clicks on Add another button in Question section
        Then Question text field is displayed
        And Upload image button is displayed
        And Delete question button is displayed
        And The question has 3 answers available
        And Each answer has input text field with corresponding 'Is Correct' check-box and delete button

    Scenario: Verify Title field should accept only alphabetic characters
        Given The admin is logged in in Admin Portal
        When The admin clicks on Add button for "Tests" field
        And The admin fills title "123@!'"
        And The admin fills number "2" for duration
        And The admin clicks on SAVE button
        Then Please correct the error below message is displayed