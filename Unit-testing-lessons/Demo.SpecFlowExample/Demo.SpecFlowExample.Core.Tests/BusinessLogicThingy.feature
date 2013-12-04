Feature: BusinessLogicThingy
	I want to be able to take a string and make every word that is greater than 3 characters in 
	that string begin with an upper case letter.

@mytag
Scenario: All_words_greater_than_3_characters_begin_with_uppercase_letter
	Given I have the string 'mary had a little lamb'
	When I enforce uppercase rules
	Then the result should be 'Mary had a Little Lamb' on the screen
