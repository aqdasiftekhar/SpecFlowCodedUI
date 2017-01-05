Feature: LoginSpecFlowFeature
	In order to test Google Application
	As a software tester
	I want to provide search string to google
	And open the website

@mytag
Scenario: Search nuget In Google
	Given I am on Google Page
	And I have entered nuget in search box
	When I click on Search button
	Then verify that nuget exist in search results
	And google redirect to nuget page
	And verify if nuget website is opened successfully
