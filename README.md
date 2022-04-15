# nunit_testing
# CloudQA

Purpose:  Writing script for automating testing.

Tools, Libraries, Frameworks used:
Nunit ( unit testing framework )
.NET 6.0 - C#
Selenium

Discription of Project:

-There is a total of 14 forms that need to be tested. 

-Iframes and ShadowDOMs have been used in the webpage.

-After clicking the submit button we can see the responses field by the user. These same responses have been sent to the server

-Created One TestCase for testing each form

Testing Parameter:
Are the responses filled by the user and the responses sent to the server same?


Fields which I tested:
(i) for the froms 1-12, I tested: 
       (a)"first name", 
       (b)"last Name", 
       (c)"Date of Birth", 
       (d)"check box for accepting terms and conditions"

Test Case for form 1-12:
First name: Akshat
Last Name: Gadhwal
DoB : 1999-12-12
Terms & condition box checked

(ii) for the forms 13 & 14, I tested:
       (a) "First Name"
       (b) "Second Name"
       (c) "Gender"

Test Case for form 1-12:
First name: Akshat
Last Name: Gadhwal
Gender : Male 

Result I got: 
   -Number of forms passed: 13
   -Number of forms failed: 1

Logs:
(i) In case of Failure, It will print out the response which has been sent to the server

#Nunit Testing
#.NET 6.0
#Selenium
#C#
