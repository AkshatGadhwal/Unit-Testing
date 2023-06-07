# Unit Testing

This repository contains code for automating testing using NUnit, a unit testing framework for .NET 6.0 with C# and Selenium.

## Project Description

The project aims to automate the testing of 14 forms. The webpages include the usage of iframes and ShadowDOMs. After clicking the submit button, the user's responses are displayed and sent to the server.

Each form has been assigned a separate test case. The tested fields of the form include:

- First name
- Last name
- Date of Birth
- Checkbox for accepting terms and conditions

For forms 1-12, the following test case was used:

- First name: Akshat
- Last name: Gadhwal
- Date of Birth: 1999-12-12
- Terms and conditions checkbox checked

For forms 13 & 14, the following test case was used:

- First name
- Second name
- Gender

## Test Results

The testing results are as follows:

- Number of forms passed: 13
- Number of forms failed: 1

In case of failure, the logs will display the response sent to the server.

## Technologies Used

- NUnit Testing
- .NET 6.0
- Selenium
- C#

Please refer to the code in this repository for more details.

## How to Use

To run the unit tests, follow these steps:

1. Clone the repository: `git clone https://github.com/AkshatGadhwal/unit-testing.git`
2. Open the project in your preferred development environment.
3. Ensure you have the necessary dependencies and frameworks installed.
4. Run the unit tests using your testing framework or IDE.

## Contributions

Contributions to this project are welcome. If you have any improvements or additional test cases, feel free to open a pull request.

## License

This repository is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

Happy testing!
