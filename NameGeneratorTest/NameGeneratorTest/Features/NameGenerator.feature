Feature: NameGenerator

Scenario: Get a Single Name
	When I get a name
	Then I have a name

Scenario Outline: Get Multiple Names
	When I get <x> names
	Then I have <x> names

	Examples:
	| x |
	| 2 |
	| 8 |