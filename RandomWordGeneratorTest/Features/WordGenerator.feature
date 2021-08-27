Feature: WordGenerator

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

Scenario Outline: Get a Single Word With Global Part Of Speech
	Given I set the part of speech to <partOfSpeech>
	When I get a word
	Then I have a <partOfSpeech>

	Examples:
	| partOfSpeech |
	| adj          |
	| adv          |
	| art          |
	| noun         |
	| verb         |

Scenario: Get a Single Word With No Global Part Of Speech
	When I get a word
	Then I do not have a word

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

Scenario Outline: Get Multiple Words With Global Part Of Speech
	Given I set the part of speech to <partOfSpeech>
	When I get <x> words
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

Scenario: Get Multiple Words With No Global Part Of Speech
	When I get 3 words
	Then I do not have words

Scenario Outline: Get A Single Pattern
	Given I set the pattern to adv,adj,noun
	And I set the delimiter to <delimiter>
	When I get a pattern
	Then I have one pattern with 3 words and <delimiter> delimiter

	Examples:
	| delimiter |
	| ,         |
	| _         |

Scenario Outline: Get Multiple Patterns
	Given I set the pattern to adv,adj,noun
	And I set the delimiter to <delimiter>
	When I get <quantity> patterns
	Then I have <quantity> patterns with 3 words and <delimiter> delimiter

	Examples:
	| quantity | delimiter |
	| 3        | ,         |
	| 5		   | ,         |
	| 3        | _         |
	| 5		   | _         |

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