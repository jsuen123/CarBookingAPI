# CarBookingAPI

Steps to run:
1.	You will need to have Visual Studio 2017 or 2019 installed
  a.	You will need to download and install .NET Core 2.2 SDK from https://dotnet.microsoft.com/download - 
    i.	For Visual Studio 2017 – use “Download .NET Core SDK (Compatible with Visual Studio 2017)” link
    ii.	For Visual Studio 2019 – use “Download .NET Core SDK” link

2.	Go to https://github.com/jsuen123/CarBookingAPI
3.	Click on Clone or download, then Download ZIP
4.	Extract the zip file then run CarBookingAPI.sln
5.	You can import the .json file using Postman in the “Postman Tests” folder, it contains the two requests for this exercise.

Assumptions of things if had more time:
-	User authorization - check if the user who requests the booking is the same as the logged-in user.
-	Global exception handler – can be used for logging exceptions
-	Implement HATEOAS – this will be useful if the client applications are in HATEOAS style and will make the API true RESTful.
-	Paging – improve performance if the car list gets larger
-	Unit testing – I had some issues with Microsoft.Test.Sdk, don’t know if it’s .NET Core 2.2 issue. So I did not get a change to create unit tests, but I would be happy to talk you through my unit test strategies.
-	Postman tests – automated test can be created in Postman to check if requests are responding. 
-	Web API help page – can be done by using tools like Swagger 
