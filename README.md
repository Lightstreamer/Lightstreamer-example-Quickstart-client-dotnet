# Lightstreamer - Quickstart Example - .NET Client #
<!-- START DESCRIPTION lightstreamer-example-quickstart-client-dotnet -->
The *Quickstart Example* provides the source code to build a very simple and basic client application, used to test the capability of the Client APIs to connect and receive data from Lightstreamer Server. The example can be used to familiarize with the Client APIs and as a reference on how to use them, and can be used as a starting point for client application implementations.

This project contains the C# source files of a sample application, which shows how the [Lightstreamer .NET PCL Client API](http://www.lightstreamer.com/api/ls-pcl-client/latest/) can be used to connect to Lightstreamer Server.
<!-- END DESCRIPTION lightstreamer-example-quickstart-client-dotnet -->

## Details

The `TestClient.cs` file contains the source `Main()`. It basically connects to the server and performs a subscription, printing on the console the incoming Item Updates.

![screenshot](screen_qs.png)

The test includes the necessary code and a sample configuration file for Library logging through [Log4Net](http://logging.apache.org/log4net/index.html).


## Build

To build and install a version of this demo, pointing to your local Lightstreamer Server instance, follow the steps below.

* The *Quickstart Example* needs both the *PORTFOLIO_ADAPTER* (see the [Lightstreamer - Portfolio Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Portfolio-adapter-java)), and the *QUOTE_ADAPTER* (see the [Lightstreamer - Stock-List Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-StockList-adapter-java)). Therefore, as a prerequisite, the full version of the [Lightstreamer - Portfolio Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Portfolio-adapter-java) has to be deployed on your local Lightstreamer Server instance. Please follow the instruction in [Install the Portfolio Demo](https://github.com/Lightstreamer/Lightstreamer-example-Portfolio-adapter-java#install-the-portfolio-demo) to install it.
* Get the  binaries files of the library (`Lightstreamer_DotNet_PCL_Client.dll` and `Lightstreamer_DotNet_PCL_Client.pdb`) from NuGet [Lightstreamer.DotNet.Client](https://www.nuget.org/packages/Lightstreamer.DotNet.Client/) or use directly the Package Manager Console `Install-Package Lightstreamer.DotNet.Client`. Then copy them into the `lib` directory of the project.
* Get the `Log4Net.dll`, from [http://logging.apache.org/log4net/download_log4net.cgi](http://logging.apache.org/log4net/download_log4net.cgi), and copy it into the `lib` directory of the project.
* Create a new C# project (we used Microsoft's [Visual Studio 2015](http://www.visualstudio.com/it-it/products/visual-studio-express-vs)): from the "New Project..." wizard, choose the "Console Application" template, and use "quickstart" as project name.
* Choose as `Target framework` .NET Framework 4.5.
* From the "Solution Explorer", delete the default `Program.cs`.
* Add a reference to the Lightstreamer .NET PCL Client library and the Log4net library: go to the "Browse" tab of the "Add Reference" dialog and point to the `Lightstreamer_DotNet_PCL_Client.dll` and `Log4Net.dll` files in the `lib` folder.
* Add the `TestClient.cs`, `TestConnectionListener.cs`, `TestTableListener.cs`, and the `Log4NetLogging.cs` files from the "Add -> Existing Item" dialog.
* Build the `quickstart.exe` file: from the Build menu, choose "Build Solution".
* Run the demo. The host name and the port number of the Lightstreamer server have to be passed to the application as command line arguments.<BR/>
`> quickstart.exe localhost 8080`

*Please refer to the instructions included in the source file for more details on how to configure and run the test.*

## See Also

### Lightstreamer Adapters Needed by These Clients 
<!-- START RELATED_ENTRIES -->

* [Lightstreamer - Stock-List Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Stocklist-adapter-java)
* [Lightstreamer - Portfolio Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Portfolio-adapter-java)
* [Lightstreamer - Reusable Metadata Adapters - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-ReusableMetadata-adapter-java)

<!-- END RELATED_ENTRIES -->
### Related Projects 

* [Lightstreamer - Basic Stock-List Demo - .NET Client](https://github.com/Lightstreamer/Lightstreamer-example-StockList-client-dotnet)

## Lightstreamer Compatibility Notes

- Compatible with Lightstreamer .NET PCL Client Library version 3.0.0 or newer.
- For Lightstreamer Allegro (+ .NET Client API support), Presto, Vivace.
