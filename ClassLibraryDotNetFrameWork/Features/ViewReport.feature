Feature: ViewReport

	In view report page when user clicks on veiew report 
	option, all the reports in the specified time frame 
	should be displayed.


Background:
	
	Given Browser is launced
	And Navigated to QualityPoint Application
	And Enter "AdminUserName" in UserName field and "AdminPassword" in Password field
	And Click on login button
	And Should be Navigated to "Report" Page

@Reports
Scenario: Viewing reports with default time frame
	
	Given Should be Navigated to "Report" Page
	When Click on View Report option
	Then Reports should be displayed with in the default time frame
	And Logout from the Application

@Reports
Scenario: Viewing reports with specifing the time frame
	
	Given Should be Navigated to "Report" Page
	When Enter starting date as "ProjectStartingDate"
	And Enter ending date as "ProjectEndingDate"
	And Click on View Report option
	Then Reports should be displayed with in the specified time frame
	And Logout from the Application
	 