# Test-Q

## Overview
Test Q is a desktop application that comprises several microgames which asses the user’s cognitive abilities (reaction time, number memory and verbal memory). It can be accessed by downloading and lunching the Test Q.exe executable. 

## Tools and technologies
The application was built using the Microsoft Visual Studio 2017 development environment using the C# and MySQL programming languages. The app utilizes an online hosted database created with the free plan offered by GearHost and the management of all the tables was accomplished using the SQL Server Management Studio. 

## System requirements 
The application runs using resources from the Microsoft .NET Framework (version 2.0) which comes preinstalled with all Windows version starting with Windows 7. Test Q also requires a stable internet connection.

## Key features
* Test Q has an intuitive GUI which enables any user to navigate readily between all the different sections of the app. This is accomplished by using a minimalist and friendly design which takes advantage of a simple color palette, suggestive images, nonambiguous instructions and a reduced number of buttons programmed to execute simple functions.

* Users can create a personal account which is used to track their future progress.

* The database structure is optimized and efficient. 

* From the menu users can access four tabs: *Select a test*, *Statistics*, *Your Friends* and *Your profile*. The first one directs the client to a new page where they can choose to complete any of the 3 possible tests:

  * **Reaction time test** – this microgame measures the time interval (in milliseconds) needed for the user to press the mouse button after they notice a sudden change in the color of the screen, from blue to green. This color change takes place after a random amount of time and sets on a timer which stops when a click event is triggered. The mean time interval is computed using 5 consecutive attempts. 

  * **Number memory test** – the user needs to memorize a random number which is displayed on the screen for 30 seconds and then is asked to type the number in a textbox. With each level the length of the numbers increases by one digit and the final score is equal to the number of correct answers. The test ends when the user gives a wrong answer.

  * **Verbal memory test** – at each level, the user is shown a word randomly extracted from a preexisting list and is asked to decide if the word has previously appeared in the game. The final score is equal to the number of correct responses and the test ends after 3 wrong answers.

* In the *Statistics page* clients can see, for each of the 3 tests, data collected about the scores of other players. These statistics include graphs of the distributions of scores obtained by all the members of the platform, the maximum/mean scores, and rankings of the top 100 users.

* The *Your Friends* section allows the client to easily manage their friendship relations with other users. This page comprises 3 different functionalities: (1) add a friend using their username (the action is completed only after the other user accepts the friend request which is displayed as a notification on their *Your Friends* page), (2) delete a friend selected from your friends list and (3) check the profile of one of your friends. 

* *Your profile* enables the user to (1) see their personal data saved in the database, (2) delete their account, (3) track the evolution of their scores using different charts/parameters and (4) send the statistics about their progress to their email address for future reference. 

## Screenshots

<div align="center">
  <img width="600" src="https://github.com/Valentin0709/Test-Q/blob/master/Images/login.PNG">
  <p>Authentication page - top: username and password fields, bottom: Create account button</p>
</div>

<div align="center">
  <img width="600" src="https://github.com/Valentin0709/Test-Q/blob/master/Images/register.png">
  <p>Create account page - the name, surname, birthday, email adress, username and password fields need to be filled in order to complete the registration</p>
</div>

<div align="center">
  <img width="600" src="https://github.com/Valentin0709/Test-Q/blob/master/Images/select_a_test.png">
  <p>Select a test page, left: Menu, top: Reaction time test, bottom: Number memory test, right: next page button</p>
</div>

<div align="center">
  <img width="600" src="https://github.com/Valentin0709/Test-Q/blob/master/Images/reaction_time.png">
  <p>Reaction time test page - middle: the score of the last attempt, bottom left: current average score, bottom right: number of attempts completed (out of 5)</p>
</div>

<div align="center">
  <img width="600" src="https://github.com/Valentin0709/Test-Q/blob/master/Images/number_memory.png">
  <p>Number memory test page - middle: number to memorize, bottom left: timer, bottom right: current score</p>
</div>


<div align="center">
  <img width="600" src="https://github.com/Valentin0709/Test-Q/blob/master/Images/verbal_memory.png">
  <p>Verbal memory test page - middle: word to memorize, bottom: score + attempts left + SEEN button + NEW button</p>
</div>

<div align="center">
  <img width="600" src="https://github.com/Valentin0709/Test-Q/blob/master/Images/statistics1.png">
  <p>Statistics page - top: graph of the distribution of scores obtained by all the users in the Reaction time test, bottom: best score + mean score</p>
</div>

<div align="center">
  <img width="600" src="https://github.com/Valentin0709/Test-Q/blob/master/Images/statistics2.png">
  <p>Statistics page - ranking of top 100 scores in the Reaction time test</p>
</div>

<div align="center">
  <img width="600" src="https://github.com/Valentin0709/Test-Q/blob/master/Images/your_friends.png">
  <p>Your friends page - top left: friend list, top right: Check profile button + Delete friend button, bottom: Add friend button + field for typing their username</p>
</div>

<div align="center">
  <img width="600" src="https://github.com/Valentin0709/Test-Q/blob/master/Images/your_profile.png">
  <p>Your profile page - top: personal details, bottom: Delete account button + Send statistics to email button</p>
</div>

<div align="center">
  <img width="600" src="https://github.com/Valentin0709/Test-Q/blob/master/Images/email.png">
  <p>Email example, the attachments are graphs which track the user's score evolution in all three tests</p>
</div>




