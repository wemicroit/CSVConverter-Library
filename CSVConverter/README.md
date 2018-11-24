CSVConverter - https://www.nuget.org/packages/WeMicroIt.Utils.CSVConverter/
===========

How To Install:
****
The simpliest way to install this library is by using the following command in the NuGet package manager
"Install-Package WeMicroIt.Utils.CSVConverter'
Alternatively you can use this command in the dotnet tools window
"dotnet add package WeMicroIt.Utils.CSVConverter"

---

How To Configure:
****
There are 2 approaches you can take in setting up this library and I will explain both of them.

<h3>Use Dependency Injection (Prefered)</h3>
****
- Install Package (as per above)
- Add using statement to your startup class
<pre><code>using WeMicroIt.Utils.CSVConverter;</code></pre>
- Add the CSVConverter to the configure services section
<pre><code>services.AddCSV(new CSVSettings());</code></pre>
- Add using statement to your class
<pre><code>using WeMicroIt.Utils.CSVConverter;</code></pre>
- Call Interface in the constructor on each class you wish to have access to the library
<pre><code>
    private readonly ICSVConverter _csvConverter;

    public Class(
        ICSVConverter csvConverter,
        ....)
        {
            _csvConverter = csvConverter;
        }
</code></pre>

<h3>Use local variables</h3>
****
- Install Package (as per above)
- Add using statement to your class
<pre><code>using WeMicroIt.Utils.CSVConverter;</code></pre>
- Create variable of type CSVConverter 
<pre><code>CSVConverter csv = new CSVConverter();</code></pre>
- Configure your CSVConverter by using the set options method
<pre><code>csv.SetOptions(new CSVSettings());</code></pre>

----

How To Use:
****
Once the library has been configured you can now call the methods to perform the manipulation

<h3>Serialize</h3>
****
<h4>SerializeBlock</h4>
<pre><code>
    List<string> var = SerializeBlock<T>(Data); //Use a list of items of a specified type & create a list of csv lines with a default header
    List<string> var = SerializeBlock(Data); //Use a list of generic objects & create a list of csv lines with a default header
    List<string> var = SerializeBlock<T>(Data, Header); //Use a list of items of a specified types & create a list of csv lines with a predefined header
    List<string> var = SerializeBlock<T>(Data); //Use a list of generic objects & create a list of csv lines with a predefined header
</code></pre>

<h4>SerializeLines</h4>
<pre><code>
    List<string> var = SerializeLines<T>(Data); //Use a list of items of a specified type & create a list of csv lines
    List<string> var = SerializeLines(Data); //Use a list of generic objects & create a list of csv lines
</code></pre>

<h4>SerializeHeader</h4>
<pre><code>
    string var = SerializeHeader<T>(Data); //Construct a csv header using the specified type
    string var = SerializeHeader(Data); //Construct a csv header using the generic object
    string var = SerializeHeader<T>(Data, Header); //If supplied header is null/empty, construct a header using the specified type
    string var = SerializeHeader(Data, header); //If supplied header is null/empty construct a header using the generic object
</code></pre>

<h4>SerializeLine</h4>
<pre><code>
    string var = SerializeLine<T>(Data); //Construct a csv line using the specified type
    string var = SerializeLine(Data); //Construct a csv line using the generic object
</code></pre>

<h3>DeSerialize</h3>
****
public List<object> DeSerializeBlock(string Data)
<pre><code>
    List<object> var = SerializeHeader<T>(Data)
</code></pre>

public List<T> DeSerializeBlock<T>(string Data)
<pre><code>
    string var = SerializeHeader<T>(Data)
</code></pre>

public List<object> DeSerializeBlock(string Data, bool Headers)
public List<T> DeSerializeBlock<T>(string Data, bool Headers)
public List<object> DeSerializeLines(string Data)
public List<object> DeSerializeLines(List<string> Data)
public List<T> DeSerializeLines<T>(string Data)
public List<T> DeSerializeLines<T>(List<string> Data)
public List<object> DeSerializeLines(string Data, bool Headers)
public List<object> DeSerializeLines(List<string> Data, bool Headers)
public List<T> DeSerializeLines<T>(string Data, bool Headers)
public List<T> DeSerializeLines<T>(List<string> Data, bool Headers)
public object DeSerializeLine(string Data)
public T DeSerializeLine<T>(string Data)