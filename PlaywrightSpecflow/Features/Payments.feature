Feature: PaymentApp

@smoke
Scenario: Login to the application
	Given I navigate to the payment application
	And I login with the following details
	| UserName  | Password     |
	| Merchant1 | password123! |
	Then  I am able to select a payment method
	
	
Scenario: Send a UK Bank Payment(Single Approval)
		Given I navigate to the payment application
		And I login with the following details
		  | UserName  | Password     |
		  | Merchant1 | password123! |
		Then  I am able to select UK Bank as payment method
		And I can enter the bank details
			| firstname | surname | sortcode | accountnumber |
			| test      | user    | 111111   | 12345678      |
   		And submit the payment
   		Then I can see the single approval status
   		Then I can send a API call to the bank using POST
   
   		
Scenario: Send a International Bank Payment(Multiple Approvals)
		Given I navigate to the payment application
		And I login with the following details
		  | UserName  | Password     |
		  | Merchant1 | password123! |
		Then  I am able to select International Bank as payment method
		And I can enter the international bank details
		  | firstname | surname | IBAN |  
		  | test      | user    | 1234567890   |
		And submit the payment
		Then I can see the multiple approval status
		Then I can send a API call to the bank using SOAP