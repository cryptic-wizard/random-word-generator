﻿Feature: WordGenerator

Scenario Outline: Word Lists Do Not Have Duplicate Words
	When I get the list of <partOfSpeech>
	Then the list has no duplicates

	Examples:
	| partOfSpeech |
	| noun         |
	| adj          |
	| adv          |
	| art          |

Scenario Outline: Get a Single Word With Part Of Speech
	When I get a <partOfSpeech>
	Then I have a <partOfSpeech>

	Examples:
	| partOfSpeech |
	| noun         |
	| adj          |
	| adv          |
	| art          |

Scenario Outline: Get a Single Word With Global Part Of Speech
	Given I set the part of speech to <partOfSpeech>
	When I get a word
	Then I have a <partOfSpeech>

	Examples:
	| partOfSpeech |
	| noun         |
	| adj          |
	| adv          |
	| art          |

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
	| 2 | art          |

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
	| 2 | art          |

Scenario: Get Multiple Words With No Global Part Of Speech
	When I get 3 words
	Then I do not have words

Scenario Outline: Get Parts Of Speech
	When I get the parts of speech of <word>
	Then the parts of speech contains <partOfSpeech>

	Examples:
	| word    | partOfSpeech |
	| ball    | noun         |
	| wall    | noun         |
	| tall    | adj          |
	| short   | adj          |
	| quickly | adv          |
	| slowly  | adv          |
	| a       | art          |
	| an      | art          |