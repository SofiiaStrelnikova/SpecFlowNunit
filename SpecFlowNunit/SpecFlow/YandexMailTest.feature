Feature: Yandex Mail and Disk Test
	I want to log in to mail, to type a letter and to send it
	And i want log in to disk and to work with picture

Background: 
	Given I have login page and post page

@mailtag
Scenario Outline: Log in to mail and send letter	
	Given I have a user's <login> and <password>
	When I do login-procedure
	Then the exit-link will appeared

	Given To type letter page
	When I type a <login>, a <theme> and a <letter> and click 'Save'
	Then Draft is appeared

	Given I have Drafts page and current draft page
	When I open darfts
	And Click last draft
	And Check a <login>, a <theme> and a <letter> in it
	Then I send it
	And Check the drafts folder is disappeared

	Given Sent page
	When I open sent folder
	And Check the sent letter is appeared
	Then I clear sent folder

	Given Trash page
	When I open trash folder
	Then I clear tarsh folder
	And Exit

	Examples: 
| login                           | password        | theme | letter |
| auto-test-account2020@yandex.ru | autotestaccount | lala  | letter |


#@disktag
#Scenario Outline: Log in to mail, go to Disk and work with picture
#	Given I have a user's <login> and <password>
#	When I login
#	Then the exit-link will appeared
#
#	Given Yandex disk page and trash in yandex disk page
#	When I open yandex disk
#	Then I delete a picture
#	And I restore it
#
#	Examples: 
#| login                           | password        |
#| auto-test-account2020@yandex.ru | autotestaccount |



	

