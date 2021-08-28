Feature: PartOfSpeech
    Functions to get the part of speech of a word

Scenario Outline: Get Parts Of Speech
	When I get the parts of speech of <word>
	Then the parts of speech contains <partOfSpeech>

	Examples:
	| word    | partOfSpeech |
	| tall    | adj          |
	| short   | adj          |
	| quickly | adv          |
	| slowly  | adv          |
	| a       | art          |
	| an      | art          |
	| ball    | noun         |
	| wall    | noun         |
	| pull    | verb         |
	| run     | verb         |

Scenario Outline: IsPartOfSpeech
	When I check if <word> is <partOfSpeech>
	Then the return value is <bool>

	Examples:
	| word    | partOfSpeech | bool  |
	| tall    | adj          | true  |
	| tall    | noun         | false |
	| quickly | adv          | true  |
	| quickly | adj          | false |
	| the     | art          | true  |
	| the     | adv          | false |
	| ball    | noun         | true  |
	| ball    | art          | false |
	| orange  | noun         | true  |
	| orange  | adj          | true  |
	| orange  | verb         | false |
	| orange  | art          | false |
	| orange  | adv          | false |