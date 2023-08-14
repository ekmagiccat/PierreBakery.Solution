# Pierre's Bakery

### By: Eva Kemp

## Technologies Used

- C#
- .NET6
- MySQL Workbench
- Razor
- ASP.NET Core MVC
- VS Code
- Entity Framework Core
- Identity

## Description

This is an application that allows an authorized user to create, edit, or delete treats and flavors in Pierre's Bakery. It uses a many-to-many database relationship.

## How To Run This Project

### Install Tools

Install the tools that are introduced in [this series of lessons on LearnHowToProgram.com](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c).

### Clone Project

- Clone the repository from GitHub by navigating to the main page of the repository.
- Above the list of files on the repository, click "Code".
- Then click "Download ZIP".
- After downloading, open the file in VS Code.
- Navigate to this project's production directory called "HairSalon" using the command `cd Bakery` in the command line.
- Run `dotnet build` to compile the application.

### Set Up and Run Project

1. Open the terminal and navigate to this project's production directory called "Bakery".
2. Within the production directory "Bakery", create a new file called `appsettings.json`.
3. Within `appsettings.json`, put in the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=eva_kemp_bakery;uid=[YOUR-USERNAME];pwd=[YOUR-PASSWORD];"
  }
}
```

4. Check the .gitignore file to ensure that `appsettings.json` is listed and remains hidden.
5. Navigate to the production directory "Bakery", run `dotnet ef database update` to instantiate the database in My SQL.
6. Within the production directory "Bakery", run `dotnet watch run` in the command line to start the project in development mode with a watcher.
7. Open the browser to _https://localhost:5001_. If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this lesson: [Redirecting to HTTPS and Issuing a Security Certificate](https://www.learnhowtoprogram.com/lessons/redirecting-to-https-and-issuing-a-security-certificate).

## Known Bugs

- None known

## License

MIT License

Copyright (c) _2023_ Eva Kemp

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
