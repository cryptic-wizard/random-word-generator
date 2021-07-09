Feature: WordGenerator

Scenario Outline: Get a Single Word
	When I get a <partOfSpeech>
	Then I have a <partOfSpeech>

	Examples:
	| partOfSpeech |
	| noun         |
	| adj          |
	| adv          |

Scenario Outline: Get Multiple Words
	When I get <x> <partOfSpeech>
	Then I have <x> <partOfSpeech>

	Examples:
	| x | partOfSpeech |
	| 2 | noun         |
	| 5 | noun         |
	| 2 | adj          |
	| 5 | adj          |
	| 2 | adv          |
	| 5 | adv          |


Scenario Outline: Get Part of Speech
	When I get the part of speech of <word>
	Then the part of speech is <partOfSpeech>

	Examples:
	| word    | partOfSpeech |
	| ball    | noun         |
	| wall    | noun         |
	| tall    | adj          |
	| short   | adj          |
	| quickly | adv          |
	| slowly  | adv          |