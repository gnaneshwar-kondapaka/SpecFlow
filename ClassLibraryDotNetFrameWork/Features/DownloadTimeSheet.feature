Feature: Download Time Sheet

	User should be able to download Time sheet 
	in pdf format by clicking on the download pdf option.

Background:
	
	Given Browser is launced
	And Navigated to QualityPoint Application
	And Enter "AdminUserName" in UserName field and "AdminPassword" in Password field
	And Click on login button
	And Should be Navigated to "Report" Page

Scenario: Clicking on download pdf option from Report page

	Given Should be Navigated to "Report" Page
  	When Click on download Time sheet option
	Then Report should be downloaded
	And Logout from the Application
