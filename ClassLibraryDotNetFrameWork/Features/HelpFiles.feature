Feature: Help Files

	User should be Navigated to Help Files page
	by clicking on the Help Files button from Home page

Scenario: Clicking on Help Files button from Home page

	Given Browser is launced
	And Navigated to QualityPoint Application
	When Clicked on Help Files button
	Then Should be Navigated to "HelpFiles" Page
	And Close the Application