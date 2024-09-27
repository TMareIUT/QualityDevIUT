Feature: Library

@AddMedia
Scenario: Add one media
	Given Create Library
	And Add this media :
	| m_Titre			| m_NumeroReference | m_NombreExemplairesDisponibles |
	| "Media de test"	| 150291			| 26							 |
	When Add this media in library
	Then The library contain media :
	| m_Titre			| m_NumeroReference | m_NombreExemplairesDisponibles |
	| "Media de test"	| 150291			| 26							 |

@RemoveMedia
Scenario: Remove one media
	Given Create Library
	And Add this media :
	| m_Titre			| m_NumeroReference | m_NombreExemplairesDisponibles |
	| "Media de test"	| 150291			| 1								 |
	When Add this media in library
	And Remove this media :
	| m_Titre			| m_NumeroReference | m_NombreExemplairesDisponibles |
	| "Media de test"	| 150291			| 1								 |
	Then Library are empty

@CreateLoan
Scenario: Loaned one media
	Given Create Library
	And Add this media :
	| m_Titre			| m_NumeroReference | m_NombreExemplairesDisponibles |
	| "Media de test"	| 150291			| 10							 |
	When Add this media in library
	And Loan media with m_NumeroReference is 150291 with user Tony Maré
	Then m_NombreExemplairesDisponibles of 150291 is 9 in library
	And Loans contain one media with m_NumeroReference is 150291 and user is Tony Maré

@ReturnLoan
Scenario: Return an Loan
	Given Create Library
	And Add this media :
	| m_Titre			| m_NumeroReference | m_NombreExemplairesDisponibles |
	| "Media de test"	| 150291			| 10							 |
	When Add this media in library
	And Loan media with m_NumeroReference is 150291 with user "Tony Maré"
	And "Tony Maré" return media whose m_NumeroReference is 150291
	Then the loan of "Tony Maré" with m_NumeroReference 150291 is returned