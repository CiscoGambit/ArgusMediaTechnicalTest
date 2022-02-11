Feature: Checkout

This feature will calculate the total bill from the new endpoint

@Calculation
Scenario Outline: Calculate bill successfully with and without discount applied
	Given A group of Four people orders '4' starters, '4' mains and '4' drinks '<Condition type>' 1900
	When the order is sent to the endpoint the total is calculated
	Then the final  bill should be £'<Expected Results>'

Examples:
	| Expected Results | Condition type |
	| 55.40            | Before         |
	| 58.40            | After          |

	

Scenario: Calculate bill successffully when adding aditional orders after discount time range
	Given A group of Two people orders '1' starters, '2' mains and '2' drinks 'Before' 1900
	When the order is sent to the endpoint the total is calculated
	And are joined by Two people orders '0' starters, '2' mains and '2' drinks 'After' 2000
	And the order is sent to the endpoint the total is calculated
	Then the final  bill should be £'<Expected Results>'

Examples:
	| Expected Results |
	| 43.70            |
  
 
Scenario: Calculate bill successfully when part of order is cancelled
	Given A group of Four people orders '4' starters, '4' mains and '4' drinks
	And the order is sent to the endpoint the total is calculated
	When One person cancels their order, the updated order is now '3' starters, '3' mains and '3' drinks
	And the order is sent to the endpoint the total is calculated
	Then the final  bill should be £'43.80'