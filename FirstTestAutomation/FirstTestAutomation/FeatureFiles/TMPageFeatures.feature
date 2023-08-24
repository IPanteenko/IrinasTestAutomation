Feature: TMPageFeatures

As a TurnUp portal admin
I would like to creat, edit and delete Time record
so that I can manage time and material successfully

@tag1
Scenario: create time record with valid details
	Given I logged in to TurnUp portal successfully
	And I navigated to Time&Material page
	When I create new record
	Then the new record should be created succefssfully and appear in the table


Scenario Outline: edit time record with valid details
   Given I logged in to TurnUp portal successfully
   And I navigated to Time&Material page
   When I update '<Code>', '<Description>', '<Price>' in existing Time record
   Then the rewcord should have updated '<Code>', '<Description>', '<Price>'

Examples: 
| Code  | Description  | Price    |
| Code1 | Desxription1 | 101.00   |
| Code2 | Description2 | 102.00   |
| Code3 | Description3 | 103.00   |


Scenario: delete an existing record
    Given I logged in to TurnUp portal successfully
	And I navigated to Time&Material page
	When I delete an existing record
	Then the record should be deleted successfully