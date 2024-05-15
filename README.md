Interview – Practical
The following elements will be the areas of focus during this exercise:
•Understanding and following Instructions;
•“Coding Elegance”;
•Consistency;
•Naming Conventions / Best Practices;
•Architecture / Design Patterns Utilized;
•Class Structure;
•Encapsulation; and
•Algorithm Cleanliness.
Objective Develop a web-based survey application that assesses how a Software Development team distributes their time between the different areas that they are exposed to during a productive week. The averages of these results then need to be compared to the objectives set by the team manager, which will show the “expectation gap” (e.g. how the team as a whole, compares to the manager’s expectation). Use https://formbuilder.online/ to allow a user to build his own survey form.
Bonus Objective
Build a Unit Test that populates the survey results for all 5 respondents with the team manager’s objectives and then validate your results.
Submission
Submit a zipped file to the sender of this practical. This file should contain:
•Your source code;
•Backup of your database; and
•A Text file containing your answer to the theory question.
Data Provided
3 Text files are provided. These text files need to be imported/replicated into their designated tables in the database.
1.Respondents.txt – to be saved in the “Respondent” table.
Contains 5 respondents, with their username and passwords.
2.Questions.txt – to be saved in the “Question” table.
List of all the questions (focus areas).
3.Expectations.txt – to be saved in the “Objective” table.
The team manager’s objective percentage by focus area.
Components and Workflow
The application requires the following Screens:
1. Login
2. User Survey
3. Submission confirmation
4. Results
The workflow should be as follows:
1. The landing page is the login screen.
Authentication (basic, no complex authentication “model” is required) should be done with the username and password combination provided.
There should also be a custom “admin” account hard-coded into the system. The user logging in with this account will be taken to the Results screen.
2. On successful (respondent) login, the respondent will be presented with the Survey. The survey form needs to list the questions with input boxes next to them.
Submission should only be possible if the inputs are valid. The respondent should “weight” every focus area. The total “weighting” should equal 100. E.g. Allocate the percentage of time spent on an area.
The order in which the questions are presented should be randomized.
Each respondent’s results should be saved in the Respondent Result table.
3. This is followed by a confirmation screen that informs the respondent that their survey has been submitted successfully.
4. The Results screen should only be visible when logging in with the “admin” account.
This screen needs to average out every question and compare it to the manager’s objective “weighting”. The difference (expectation gap) also needs to be displayed with the “objective weighting” and an “accuracy” column. Example:
Implementation Directive
• Create a new Database called “Survey”.
• Create 4 tables:
o Respondent;
o Question;
o Respondent Result; and
o Objective.
• Replicate the content in Respondents.txt into the Respondent table.
• Replicate the content in Questions.txt into the Question table.
• Store the objective values from Objectives.txt in the Objective table. It must collate with the relevant question.
• Use Visual Studio or Visual Studio Code for the project implementation.
o You can use the CLI as you see fit during the development of your project.
• The project should be done in C# and be an ASP.NET Core Web App, using Blazor for the front-end.
• Use Entity Framework Core to communicate with your Database.
• Build your Model in the same project.
• To save time, it is advised to use SQLite, but you can also use MySQL or Microsoft SQL Server.
Theory
Elaborate on 1 of the Design Patterns used in your solution.
