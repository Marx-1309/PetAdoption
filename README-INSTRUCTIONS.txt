Hey,
Thank you for showing interest in this project's source code.

Here are the instructions to setup and running the project.

1. Extract the code
2. Modify the Connection String in appsettings.Development.json in PetAdoption.Api project
3. Rebuild the Api project
4. Run the Api project, It will generate the database automatically

5. Setup the Dev Tunnel using https://learn.microsoft.com/en-us/aspnet/core/test/dev-tunnels?view=aspnetcore-7.0
6. Copy the DevTunnel URL to the BaseApiUrl in AppConstants.cs in PetAdoption.Shared project
7. Run the MAUI project

If something does not work, Feel free to email me on abhayprince@outlook.com

If you do not want to use Dev Tunnels
Here are Alternative Approaches 
1. If you can host/deploy Api Project somewhere, and the use that url in PetAdoption.Shared.AppConstants.BaseApiUrl constants
2. You can use localhost, but then you will need extra effort to make MAUI app to Connect with this Localhost Api
 You will need to use your own custom code to allow MAUI app to use localhost api for the Android.iOS Emulators/Simulators
Here are useful links to show how you can do this

https://youtu.be/-SP-2qJ88dE?si=NM-2Tn1GgJd98bkS
https://www.youtube.com/playlist?list=PLlgYGDJXMjDYhv8YaxH06WyMkcIYuW8CK

Happy Coding

Abhay Prince
https://www.youtube.com/@abhayprince
