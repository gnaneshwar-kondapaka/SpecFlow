Feature: Admin Registration
	
	User should be Navigated to Admin registration page
	by clicking on the Admin Registration button from Home page

Scenario: Clicking on Admin Registration button from Home page
	
	Given Browser is launced
	And Navigated to QualityPoint Application
	When Click on Admin Registration button
	Then Should be Navigated to "AdminRegistration" Page
	And Close the Application