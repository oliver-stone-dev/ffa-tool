# Film Friendly Airports Database Tool

## Introduction
The purpose of this application is to provide a graphical user interface for accessing data stored on the Film Friendly Airports SQL database.

This tool allows users to search for a specific airport and view its data. Terminals associated with that airport are also displayed and can be modified, or new terminals added.

## Development 
The application is written in C# using .NET 8, utilising the WPF framework. 

### Building and Running Application

Clone or download the project files, and open up the project in Visual Studio.

You must then link an SQL database to the software using a connection string. The connection string is stored in json file in the project directory.

Create text file called **DatabaseSettings.json** and place it the root directory. Inside that file add the following, replacing the X with your database connection string

```
{
  "ConnectionString": "X"
}
```
