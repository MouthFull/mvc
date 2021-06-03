# Mouthfull 

Mouthfull is an open source recipe exploration service, helping users to reduce food waste, and find creative culinary solutions based on their input. The mission is to provide a set of services to support personalized recommendations based on what ingredients are already in their fridge, and browse recipes that have been viewed by other users.

## Technologies Used

-  Angular     - version 11.0
- .NET webapi - version 5.0
- .Net MVC    - version 5.0

## Features

### Current features available on Mouthfull 

- Search for recipes by ingredients in your fridge.
- Save a history of all viewed recipes.
- View a summary of the recipe including nutrition, rating, and other information.


### To-do list:
- Add more support for returning more detailed recipe from the API.
- Add an end-point for data validation on the ingredient list.

## Getting started

git clone https://github.com/MouthFull/mvc.git

### Development server

Run `dotnet run` for a dev server. Navigate to `http://localhost:5000/home/index`. 

### Build

Run `dotnet build` to build the project. The build artifacts will be stored in the `dist/` directory. 
### Running unit tests

Run `dotnet test` to execute the unit tests via [Xunit](https://github.com/xunit/xunit).

## Usage

- Navigate the main page at localhost:5000/home/index
- input an ingredient and click the "+" button to include it in your list
- click "search" when you are ready to search for recipes
![image](https://user-images.githubusercontent.com/67556178/120580811-68ee9b80-c3ef-11eb-9fcd-16cf4e04a98d.png)

- click on a meal idea to navigate to the recipe summary

- click on "history" in the nav bar to view recipes other users have visited


## Contributors
- Elwyn Palmerton
- Glenn Edinbourgh
- Phuc Bao Pham

## License

This project uses the following license: MIT
