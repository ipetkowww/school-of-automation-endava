Feature: DatabaseTests

    @DB
    Scenario: Get All Records Where Title Contains "Virus"
        When The user get all records where title contains word "<word>"
        Then The user verifies all fetched data contain word "<word>" in title
               
        Examples: 
        | word  |
        | virus |