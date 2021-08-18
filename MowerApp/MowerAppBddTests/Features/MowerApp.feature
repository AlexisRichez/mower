Feature: MowerApp

Scenario: Move mower according to its initial location and movements
	Given a working surface with a top right limit position with X equal to 5 and Y equal to 5
	And a mower is initially oriented to N
	And with a position with X equal to 1 and Y equal to 2
	When movements sequence LFLFLFLFF is sent to the mower
	And treatment is launched
	Then the mower is finally oriented to N
	And is having a final position of X equal to 1 and Y equal to 3