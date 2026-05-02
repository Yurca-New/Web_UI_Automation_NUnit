Feature: EHU Website Navigation and Search
  As a user of the EHU website
  I want to be able to navigate to the About page and use the search function
  So that I can find relevant information

  @navigation
  Scenario: Navigate to the About page
    Given I open the EHU home page
    When I click on the About link
    Then the page title should contain "About"

  @search
  Scenario Outline: Search for information
    Given I open the EHU home page
    When I search for "<searchWord>"
    Then the page URL should end with "<expectedUrl>"

    Examples:
      | searchWord     | expectedUrl       |
      | study programs | ?s=study+programs |
      | admissions     | ?s=admissions     |