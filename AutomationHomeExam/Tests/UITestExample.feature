Feature: UI Test Example
	Simple example of UI test.

@SmokeTest
Scenario: Run the following steps
	Given Go to "https://www.amazon.com/"
	When Search for "Bluetooth Portable Speaker"	
	And In the sidebar under "Portable Bluetooth Speaker Features" check the "Ultra-Portable"
	And In the sidebar under "Customer Reviews Say" check the "Good Portability"
	And Click "OontZ Angle 3 (3rd Gen)"
	And Choose color: "blue"
	And Click the "Buy Now" button