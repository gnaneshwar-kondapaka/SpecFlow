Feature: Select Project

	User should be able to select project in report page
	from the project drop down.

Background:
	
	Given Browser is launced
	And Navigated to QualityPoint Application
	And Enter "AdminUserName" in UserName field and "AdminPassword" in Password field
	And Click on login button
	And Should be Navigated to "Report" Page

Scenario: By default the Project field should be populated with "All" value
	
	Given Should be Navigated to "Report" Page
	Then Project field should be populated with value "DefaultValue"
	And Logout from the Application

Scenario: Selecting the Project from the Project drop down
	
	Given Should be Navigated to "Report" Page
	When Click on Project drop down
	And Select Project "ProjectIITM"
	Then Project field should be populated with value "ProjectIITM"
	And Logout from the Application