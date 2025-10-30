Feature: Login

A short summary of the feature

@MonWedFri
Scenario Outline: Login to Website
	Given I enter username as <username>
	And I enter password as <password>
	When I click login
	Then I should be logged in with proper user
Examples: 
| username      | password     |
| standard_user | secret_sauce |