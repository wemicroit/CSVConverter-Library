CSVCOnverter

How To Install:
----------
The simpliest way to install this library is by using the following command in the NuGet package manager
"Install-Package WeMicroIt.Utils.CSVConverter'
Alternatively you can use this command in the dotnet tools window
"dotnet add package WeMicroIt.Utils.CSVConverter"

How To Configure:
----------
There are 2 approaches you can take in setting up this library and I will explain both of them.

Use Dependency Injection (Prefered)
----------
- Install Package (as per above)
- Add using statement to your startup class
- Create variable of type CSVConverter
- Configure your CSVConverter by using the set options method
- Add using statement to your class
- Call Interface in the constructor on each class you wish to have access to the library

Use local variables
----------
- Install Package (as per above)
- Add using statement to your class
- Create variable of type CSVConverter 
- Configure your CSVConverter by using the set options method

How To Use:
----------
Once the library has been configured you can now call the methods to perform the manipulation

Serialize
----------


DeSerialize
----------
