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