Feature: Select Employee

	User should be able to select employee in report page
	from the employees drop down.

Background:
	
	Given Browser is launced
	And Navigated to QualityPoint Application
	And Enter "AdminUserName" in UserName field and "AdminPassword" in Password field
	And Click on login button
	And Should be Navigated to "Report" Page

Scenario: By default the Employee field should be populated with "All" value

	Given Should be Navigated to "Report" Page
	Then Employee field should be populated with value "DefaultValue"
	And Logout from the Application

Scenario: Select an Employee from the employee drop down.

	Given Should be Navigated to "Report" Page
	When Click on employee drop down
	And Select employee "Suvathi"
	Then Employee field should be populated with value "Suvathi"
	And Logout from the Application