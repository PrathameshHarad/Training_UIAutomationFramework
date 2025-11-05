Feature: Products

A short summary of the feature

@products
Scenario Outline: Verify Cart and Checkout Price Matches Inventory Price
	Given I log in to website using username as <username> and password as <password>
	When select Sauce labs backpack from inventory
	And navigate to cart page
	Then verify saucelabs backpack price
	When navigate to checkout page
	And fill the address details firstname as <firstName> lastname as <lastName> postalcode as <postalCode> and continue to next
	Then verify sacucelabs packpack item and price
	And finish the order


	Examples: 
	| username      | password     | firstName  | lastName | postalCode |
	| standard_user | secret_sauce | Prathamesh | Harad    |     421401 |
