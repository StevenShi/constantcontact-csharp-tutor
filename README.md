constantcontact-csharp-tutor
============================

Constant Contact C# Tutor is an actual working app written in C# to demonstrate integration with Constant Contact Web services API.  This code is provided as is. You are free to copy and reuse it, and it does not carry any warranties, implied or otherwise.

Requires .NET 4 framework to run.

Since this is a working app that integrates with Constant Contact web services API, you will also need your Constant Contact login credentials, which can be obtained for free 

by signing up for a trial from <a href="www.constantcontact.com">www.constantcontact.com</a>

Compiled version of the sample app can be downloaded from the /App directory.  

To read the source code behind how the app is built, look inside the /Code directory.


<b>What is Constant Contact C# Tutor?</b><br>
Constant Contact C# Tutor is a small application developed in .NET that is intended to demonstrate how to use the Constant Contact API. It has basic examples of API calls including GET, POST, PUT, and DELETE.
Beside the actual call the application intercepts and displays the http request and http response in order to show what happens behind the covers.

<b>Get started<br></b>
Clone the git repo and change directory into the /App directory.  
Go ahead and run CSharpTutor.exe

Click on “Get Started” button. This action will display the login control and the request/response display panels. Also a “Restart” button is activated to start the API calls from beginning.

<b>Login<br></b>
The login API call tries to access the Constant Contact main API page. 

For login the user need to enter the user name, password and an API key.  The user can get the API key at: <a href="http://community.constantcontact.com/t5/Documentation/API-Keys/ba-p/25015"> http://community.constantcontact.com/t5/Documentation/API-Keys/ba-p/25015</a>
On the login panel there is a link label that will display the Constant Contact API document for how to obtain an API key for use in integration with Constant Contact web services.

<b>List API Calls<br>
</b>
After login the user has the ability to perform API calls to retrieve  the email lists, add a new list, or remove an existing one. There are 3 buttons to perform these actions.
“Load existing lists” – this button will populate the right side list control with all the email list for the current user.
“Add new list” – this button will display a pop up window where the user can enter the name for the new list.
“Remove selected list” – this button will remove the selected list from the user’s email list collection.

All the buttons have below them a link that will guide the user to Constant Contact API documentation page.
For each action the user can see in the request/response display panels what happens behind the scenes.

<b>Show Contacts in list<br>
</b>
There is a fourth button that will display all the contacts in the selected list. Hitting this button will show all the contacts in the selected list.
Below the “Show contacts in list” button there is a link to the actual Constant Contact API document call for this action.
In the request/response panels the actual web services API call is shown.

<b>Update selected contact<br>
</b>
If the email list contains contacts then this button will be active. You can use this button to update the customer’s name.
Next to this button there is a link to the API documentation for this call.

<b>Go Back<br>
</b>
This button will get the user back to the list API calls panel.
