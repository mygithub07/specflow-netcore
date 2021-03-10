Feature: Demo
		As a User,
		I can find information about libraries this demo uses



#Scenario: scenario to test binding class instance
	#Given I have "testString"

#Scenario: Google Search - FluentAssertions
	#Given I am on "http://www.google.com"

#Scenario Outline: examples with step argument
 #Given I am on "http://www.google.com"
 #Given we have '<Webelements>'
  
 #Examples:
 #| Webelements | 
 #|     Gmail   |

#Scenario: Firefox tests
#Given I am on "http://www.google.com" on firefox

Scenario: doc string test with general parameter
Given a string with quotes in doc string and "Random" as general parameter
  """
  string with quotes "quotes" 
  """

Scenario: doc string only test 
Given a string with quotes in doc string
  """
  doc string only "quotes" 
  """