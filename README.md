BackGround:
----------
My primary objective of this project was to:
- Build a dotnet library which would allow me to pass a string, a list of strings and an indicator to indicate if the data contains a header to List<objects>.
- As time went on I decided to add in the ability to specify what Type you want the objects to binded to and this relies on the header row to match the field.
- Lastly once I had taken care of the Serization process I decided to add in De-Serialization and this means that this is now complete library of functionality as it handles conversion in both directions.

Future Plans:
----------
- Build CSVConverter+ which will contain all the same functionality as CSVConverter with the addition of being able to control the ordering of items and also which fields. This will be done by using Dynamic Linq.
- If you find this library is missing something which you would like feel free to raise a github issue and you are more than welcome to create a branch which implements the feature.

Libraries:
----------
- CSVConverter
- CSVConverter+
- CSVConverter-Tests