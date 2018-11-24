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


<h3>DeSerialize</h3>
****
