@ui
@subscribe-training-program
Feature: Subscribe For Training Program
As an applicant
I would like to apply for a training program

    Scenario: Subscribe Page Elements Check
        Given The user opens "Subscribe" page
        Then First Name field is displayed
        And Last Lame field is displayed
        And Email field is displayed
        And Phone number field is displayed
        And Major field is displayed
        And Graduation status dropdown is displayed
        And Preferred Technologies field is displayed
        And Subscribe button is displayed
        And Subscribe button is "disabled"

    Scenario: Verify successful subscription
        Given The user opens "Subscribe" page
        When The user fills following data for subscription:
          | firstName | lastName | email        | phoneNumber |
          | Auto      | AutoLast | RANDOM_EMAIL | 0877555555  |
        And The user selects Graduation Status
        And The user selects Preferred Technologies
        And The user clicks on Subscribe button
        Then The user verifies welcome message is displayed

    Scenario Outline: Verify user is not able to Subscribe with incorrect information in the required fields
        Given The user opens "Subscribe" page
        When The user fills following data for subscription:
          | firstName   | lastName   | email   | phoneNumber   |
          | <firstName> | <lastName> | <email> | <phoneNumber> |
        And The user selects Graduation Status
        And The user selects Preferred Technologies
        Then Subscribe button is "disabled"

        Examples:
          | firstName | lastName | email        | phoneNumber |
          |           | Ivanov   | RANDOM_EMAIL | 0888888888  |
          | Ivan      |          | RANDOM_EMAIL | 0888888888  |
          | Ivan      | Ivanov   | RANDOM_EMAIL |             |
          | Ivan      | Ivanov   |              | 123         |
          | 555       | Ivanov   | RANDOM_EMAIL | 0888888888  |
          | Ivan      | 555      | RANDOM_EMAIL | 0888888888  |

    Scenario: Verify user not able to Subscribe if Graduation Status is not selected
        Given The user opens "Subscribe" page
        When The user fills following data for subscription:
          | firstName   | lastName   | email   | phoneNumber   |
          | <firstName> | <lastName> | <email> | <phoneNumber> |
        And The user selects Preferred Technologies
        Then Subscribe button is "disabled"

    Examples:
      | firstName | lastName | email        | phoneNumber |
      | Auto      | AutoLast | RANDOM_EMAIL | 0888888888  |

    Scenario: Verify user not able to Subscribe if Preferred Technologies is not selected
        Given The user opens "Subscribe" page
        When The user fills following data for subscription:
          | firstName   | lastName   | email   | phoneNumber   |
          | <firstName> | <lastName> | <email> | <phoneNumber> |
        And The user selects Graduation Status
        Then Subscribe button is "disabled"

    Examples:
      | firstName | lastName | email        | phoneNumber |
      | Auto      | AutoLast | RANDOM_EMAIL | 0888888888  |

    Scenario Outline: Verify user not able to Subscribe with incorrect email
        Given The user opens "Subscribe" page
        When The user fills following data for subscription:
          | firstName   | lastName   | email   | phoneNumber   |
          | <firstName> | <lastName> | <email> | <phoneNumber> |
        And The user selects Preferred Technologies
        And The user selects Graduation Status
        Then Subscribe button is "disabled"

        Examples:
          | firstName | lastName | phoneNumber | email           |
          | Auto      | AutoLast | 0888888888  |                 |
          | Auto      | AutoLast | 0888888888  | linok36493@     |
          | Auto      | AutoLast | 0888888888  | votooe.com      |
          | Auto      | AutoLast | 0888888888  | linok36493@.com |
          | Auto      | AutoLast | 0888888888  | @votooe.com     |
          | Auto      | AutoLast | 0888888888  | .com            |