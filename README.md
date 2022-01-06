
# Secret Santa 🎅 <br> [![SecretSanta Build And Tests](https://github.com/TechGlue/SecretSantaApp/actions/workflows/dotnet.yml/badge.svg?branch=master)](https://github.com/TechGlue/SecretSantaApp/actions/workflows/dotnet.yml)


What started as a a long term assignment in my .Net class, turned into a project.
The purpose of the project is for me to have a development space to mess around with a variety of technologies. As well as creating a safe space for me to fail, try my best to learn and implement a solution.
The main functionality of the program is to generate random gift assignments in a group of users. 

This build is reserved for new features and more like a playground type build. 

## Features

- Clean and easy to use UI.
- User's and Group's page for simple add and removals.
- MVC pattern.

## Running the project.

Clone the project

```bash
  git clone https://github.com/TechGlue/SecretSantaApp
```

Go to the project directory. Then go into the src folder.

```bash
  cd SecretSantaApp
  cd SecretSanta
  cd src
```

From here you have to build and run the API and the Web View in seperate terminals.

## API

```bash
  cd SecretSanta.Api
  dotnet run 
```
Once executed the API should be running. Now switch over to setting up the Web view.

## Web View

```bash
  cd SecretSanta.Web
  npm install
  npm run build:prod
```
ctrl + c to exit once webpack compiled. Now compile and run the Web view. 

```bash
  dotnet run
```
Once ran you can open up Chrome and find the application at the following local host address. http://localhost:5001/

## Demo

Coming soon...

## Acknowledgements

 - [My original fork](https://github.com/TechGlue/EWU-CSCD379-2021-Spring)
 - [Credit to IntelliTect Spokane](https://github.com/IntelliTect-Samples/EWU-CSCD379-2021-Spring)

