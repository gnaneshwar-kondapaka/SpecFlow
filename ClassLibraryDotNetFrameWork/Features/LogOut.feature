Feature: LogOut 

	User should be able to logout from the application
	by clicking on the logout option

Background:
	
	Given Browser is launced
	And Navigated to QualityPoint Application
	And Enter "AdminUserName" in UserName field and "AdminPassword" in Password field
	And Click on login button
	And Should be Navigated to "Report" Page

Scenario: Clicking on Logout option from Report page

	Given Should be Navigated to "Report" Page
  	When Clicked on Logout option
	Then Should be Navigated to "Login" Page
	And "LogoutMessage" logout message should be displayed
	And Close the Application