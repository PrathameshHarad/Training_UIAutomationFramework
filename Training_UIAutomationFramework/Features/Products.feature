Feature: Products

A short summary of the feature

@products
Scenario Outline: Sort Products Price Low To High
	Given I log in to website using username as <username> and password as <password>
	When I filter price as low to high as <sortBy>
	Then I results should be sorted to price low to high
	Examples: 
	| username      | password     | sortBy              |
	| standard_user | secret_sauce | Price (low to high) |
