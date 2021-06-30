Feature: Login

	User should be allowed to login only with valid
	credentials.

Scenario: Logging in with valid credentials
	
	Given Browser is launced
	And Navigated to QualityPoint Application
	When Enter "AdminUserName" in UserName field and "AdminPassword" in Password field
	And Click on login button
	Then Should be Navigated to "Report" Page
	And Logout from the Application

Scenario: Logging in with Invalid credentials
	
	Given Browser is launced
	And Navigated to QualityPoint Application
	When Enter "InCorrectUser" in UserName field and "InCorrectPassword" in Password field
	And Click on login button
	Then "LoginFailedMessage" error message should be displayed in Login Page
	And Close the Application