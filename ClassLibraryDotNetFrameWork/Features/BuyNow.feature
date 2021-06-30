Feature: Buy Now

	User should be Navigated to QTP page
	by clicking on the BuyNow button

Scenario: Clicking on BuyNow button from Home Page
	
	Given Browser is launced
	And Navigated to QualityPoint Application
	When Clicked on Buy Now button
	Then Should be Navigated to "QTP" Page
	And Close the Application