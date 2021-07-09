﻿Feature: WordGenerator

Scenario Outline: Get a Single Word With Part Of Speech
	When I get a <partOfSpeech>
	Then I have a <partOfSpeech>

	Examples:
	| partOfSpeech |
	| noun         |
	| adj          |
	| adv          |

Scenario Outline: Get a Single Word With Global Part Of Speech
	Given I set the part of speech to <partOfSpeech>
	When I get a word
	Then I have a <partOfSpeech>

	Examples:
	| partOfSpeech |
	| noun         |
	| adj          |
	| adv          |

Scenario: Get a Single Word With No Global Part Of Speech
	When I get a word
	Then I do not have a word

Scenario Outline: Get Multiple Words With Part Of Speech
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

Scenario Outline: Get Multiple Words With Global Part Of Speech
	Given I set the part of speech to <partOfSpeech>
	When I get <x> words
	Then I have <x> <partOfSpeech>

	Examples:
	| x | partOfSpeech |
	| 2 | noun         |
	| 5 | noun         |
	| 2 | adj          |
	| 5 | adj          |
	| 2 | adv          |
	| 5 | adv          |

Scenario: Get Multiple Words With No Global Part Of Speech
	When I get 3 words
	Then I do not have words

Scenario Outline: Get Part Of Speech
	When I get the parts of speech of <word>
	Then the part of speech is <partOfSpeech>

	Examples:
	| word    | partOfSpeech |
	| ball    | noun         |
	| wall    | noun         |
	| tall    | adj          |
	| short   | adj          |
	| quickly | adv          |
	| slowly  | adv          |