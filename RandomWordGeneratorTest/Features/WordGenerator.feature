Feature: WordGenerator
    Base functions for getting a word and list of words

Scenario Outline: Word Lists Do Not Have Duplicate Words
	When I get the list of <partOfSpeech>
	Then the list has no duplicates

	Examples:
	| partOfSpeech |
	| adj          |
	| adv          |
	| art          |
	| noun         |
	| verb         |

Scenario: Set Language
	Given I set the language to EN
	When I get a noun
	Then I have a noun

Scenario Outline: Get a Single Word
	When I get a word
	And I check if I have a word
	Then the return value is true

Scenario Outline: Get a Single Word With Part Of Speech
	When I get a <partOfSpeech>
	Then I have a <partOfSpeech>

	Examples:
	| partOfSpeech |
	| adj          |
	| adv          |
	| art          |
	| noun         |
	| verb         |

Scenario Outline: Get Multiple Words
	When I get <x> words
	Then I have words

	Examples:
	| x |
	| 2 |
	| 5 |
	| 8 |

Scenario Outline: Get Multiple Words With Part Of Speech
	When I get <x> <partOfSpeech>
	Then I have <x> <partOfSpeech>

	Examples:
	| x | partOfSpeech |
	| 2 | adj          |
	| 5 | adj          |
	| 2 | adv          |
	| 5 | adv          |
	| 2 | art          |
	| 2 | noun         |
	| 5 | noun         |
	| 2 | verb         |
	| 5 | verb         |
