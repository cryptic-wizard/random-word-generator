Feature: Patterns
    Word Generator Patterns

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