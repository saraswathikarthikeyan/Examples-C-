# OnlineShopping

# Objective
An online shop offers various products for sale. 
As a user of the online shop you have a fixed budget dedicated for purchases. 
To maximize the value of your purchases, you assign a Value attribute to each product of interest available in the shop. 
Write a program that receives a list of products (defined by Id, Name, Price and Value) and a fixed budget, and produces the most valuable selection of products that fits within the budget, without exceeding it. 

## Technologies
Project is created with:

 IDE : Microsoft Visual Studio 2017 
 
.Net Framework Version: 4.7

Language: C#

## Setup
To run the project in local, download the project as zipped folder from git using the link provided / or git clone to the local folder

https://github.com/saraswathikarthikeyan/OnlineShopping.git

$ Place the folder in the local path/ your development environemnt.

$ Inside the folder, open the solution file "OnlineShopping.sln" in the in Visual Studio 

$ To Run the project - press the functional key : F5 (or)
                  - Debug -> Start debugging
                  
$ Console window will be prompted diplaying the output.

## Example use : HardCoded Inside the Code
Product Name: P1, P2, P3, P4
Product Cost : 1 , 2 , 3 , 4
Product Value: 200, 40, 60, 200
Budget: 4

##Output: 

Maximum Value of product purchased: :260, Cost Spent : 4CHF , Product purchased: P1 and P3

## Unit Testing
Unit test for the project is written in the folder "OnlineShoppingTest" . To run the test go to the tab: 
  Test -> Windows -> Test Explorer
 
 $ On the test explorer window click the link "Run All" to run the test cases.
 
 $ The window will display test cases and its status.
 
 ## Other Info
 If the project is not running or if you face any other errors:
 
$ In the "Solution Explorer" window check all the project references are resolved. 
If not add the references using the "Manage Nuget Manager.

$ check the target .Net framework. The code is developed using target framework 4.5.2
