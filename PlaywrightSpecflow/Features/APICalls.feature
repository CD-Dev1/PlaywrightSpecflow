Feature: APITests

    Scenario: Making an API call using Playwright
        Given I have a valid API endpoint
        When I make a GET request using Playwright
        Then the API should respond with a successful status code
        And the response body is as expected