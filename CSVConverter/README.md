<h1>CSVConverter</h1>
<h2>How To Install:</h2>
The simpliest way to install this library is by using the following command in the NuGet package manager
<pre><code>Install-Package WeMicroIt.Utils.CSVConverter</code></pre>
Alternatively you can use this command in the dotnet tools window
<pre><code>dotnet add package WeMicroIt.Utils.CSVConverter</code></pre>

---

<h2>How To Configure:</h2>
There are 2 approaches you can take in setting up this library and I will explain both of them.

<h3>Use Dependency Injection (Prefered)</h3>
- Install Package (as per above)
- Add using statement to your startup class
<pre><code>using WeMicroIt.Utils.CSVConverter;</code></pre>
- Add the CSVConverter to the configure services section and optionally pass in an options delegate which is used to configure the service
<pre><code>services.AddCSV(options => options => {
        options.settings.NewLine = "\r\n";
        options.settings.Deliminator = ',';
    });
    </code></pre>
- Add using statement to your class
<pre><code>using WeMicroIt.Utils.CSVConverter;</code></pre>
- Call Interface in the constructor on each class you wish to have access to the library
<pre><code>private readonly ICSVConverter _csvConverter;

    public Class(
        ICSVConverter csvConverter,
        ....)
        {
            _csvConverter = csvConverter;
        }
</code></pre>

<h3>Use local variables</h3>
- Install Package (as per above)
- Add using statement to your class
<pre><code>using WeMicroIt.Utils.CSVConverter;</code></pre>
- Create variable of type CSVConverter 
<pre><code>CSVConverter csv = new CSVConverter();</code></pre>
- Configure your CSVConverter by using the set options method
<pre><code>csv.SetOptions(new CSVSettings());</code></pre>

----

<h2>How To Use:</h2>
Once the library has been configured you can now call the methods to perform the manipulation

<h3>Serialize</h3>
<h4>SerializeBlock(string Data, string? Headers)</h4>
<pre><code>List<string> var = SerializeBlock<T>(Data); //Construct a list of csv lines based upon the specified type & add a default header
    List<string> var = SerializeBlock(Data); //Construct a list of csv lines based upon a generic object & add a default header
    List<string> var = SerializeBlock<T>(Data, Header); //Construct a list of csv lines based upon the specified type & use the provided if valid or generate one
    List<string> var = SerializeBlock(Data, Header); //Construct a list of csv lines based upon a generic object & use the provided if valid or generate one
</code></pre>

<h4>SerializeLines(string Data)</h4>
<pre><code>List<string> var = SerializeLines<T>(Data); //Construct a list of csv lines based upon the specified type
    List<string> var = SerializeLines(Data); //Construct a list of csv lines based upon a generic object
</code></pre>

<h4>SerializeHeader(string Data, string? Headers)</h4>
<pre><code>string var = SerializeHeader<T>(Data); //Construct a csv header using the specified type
    string var = SerializeHeader(Data); //Construct a csv header using the generic object
    string var = SerializeHeader<T>(Data, Header); //If supplied header is null/empty, construct a header using the specified type otherwise return header
    string var = SerializeHeader(Data, header); //If supplied header is null/empty construct a header using the generic object otherwise return header
</code></pre>

<h4>SerializeLine(string Data)</h4>
<pre><code>string var = SerializeLine<T>(Data); //Construct a csv line using the specified type
    string var = SerializeLine(Data); //Construct a csv line using the generic object
</code></pre>

<h3>DeSerialize</h3>
<h4>DeSerializeBlock(string Data, bool? Headers)</h4>
<pre><code>List<T> var = SerializDeSerializeBlock<T>(Data); //Construct a list of specific types of objects from the input data
    List<object> var = DeSerializeBlock(Data); //Construct a list of generic objects from the input data
    List<T> var = DeSerializeBlock<T>(Data, Headers); //Construct a list of specific types of objects from the input data, optionally ignoring the first row
    List<object> var = DeSerializeBlock(Data, Headers); //Construct a list of generic objects from the input data and optionally use the first row to determine the properties
</code></pre>

<h4>DeSerializeLines(List<string> Data, string? Headers)</h4>
<pre><code>List<T> var = DeSerializeLines<T>(Data); //Construct a list of specific types of objects from the input list
    List<object> var = DeSerializeLines(Data); //Construct a list of generic objects from the input list
    List<T> var = DeSerializeLines<T>(Data, Headers); //Construct a list of specific types of objects from the input list optionally ignoring the header row
    List<object> var = DeSerializeLines(Data, Headers); //Construct a list of generic objects from the input list optionally ignoring the header row
</code></pre>

<h4>DeSerializeLines(string Data, string? Headers)</h4>
<pre><code>List<T> var = DeSerializeLines<T>(Data); //Construct a list of specific types of objects from the input string
    List<object> var = DeSerializeLines(Data); //Construct a list of generic objects from the input list string
    List<T> var = DeSerializeLines<T>(Data, Headers); //Construct a list of specific types of objects from the input string optionally ignoring the header row
    List<object> var = DeSerializeLines(Data, Headers); //Construct a list of generic objects from the input string optionally ignoring the header row
</code></pre>

<h4>DeSerializeLine(string Data)</h4>
<pre><code>T var = DeSerializeLine<T>(Data); //Construct specific object based upon the csv input
    object var = DeSerializeLine( Data); //Construct generic object based upon the csv input
</code></pre>
=======
CSVConverter
https://www.nuget.org/packages/WeMicroIt.Utils.CSVConverter/

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
