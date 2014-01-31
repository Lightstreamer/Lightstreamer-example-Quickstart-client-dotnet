# Lightstreamer - Quickstart Example - .NET Client #
<!-- START DESCRIPTION lightstreamer-example-quickstart-client-dotnet -->

This project contains the C# source files of a sample application that uses [Lightstreamer .NET Client API](http://www.lightstreamer.com/docs/client_dotnet_api/frames.html) and can be used to test the capability of the Client API to connect and receive data from Lightstreamer Server.
These source files can be used as a starting point for a Client application implementation or as a reference use of the Client API.<br>

![screenshot](screen_qs.png)<br>

TestClient.cs contains the source Main(). Please, refer to the instructions included in this source file in order to configure and run the tests.
The test includes the necessary code and a sample configuration file for Library logging through [Log4Net](http://logging.apache.org/log4net/index.html).
  
<!-- END DESCRIPTION lightstreamer-example-quickstart-client-dotnet -->

# Build #

To recompile the provided source, you just need to create a project for a Console Application target, then include the source and include the following references:
- <b>.NET Client API for Lightstreamer</b> binaries files DotNetClient_N2.dll and DotNetClient_N2.pdb from the [latest Lightstreamer distribution](http://www.lightstreamer.com/download). You can find it in "/DOCS-SDKs/sdk_adapter_dotnet/lib" folder.
- <b>Log4Net</b> dll. You can download  it from [http://logging.apache.org/log4net/download_log4net.cgi](http://logging.apache.org/log4net/download_log4net.cgi).

# Deploy #

The host name and the port number of the Lightstreamer server have to be passed to the application as command line arguments.<br>
The demo is suitable for running with the [QUOTE_ADAPTER](https://github.com/Weswit/Lightstreamer-example-Stocklist-adapter-java) and [PORTFOLIO_ADAPTER](https://github.com/Weswit/Lightstreamer-example-Portfolio-adapter-java) Data Adapters.

# See Also #

## Lightstreamer Adapters Needed by These Demo Clients ##
<!-- START RELATED_ENTRIES -->

* [Lightstreamer - Stock-List Demo - Java Adapter](https://github.com/Weswit/Lightstreamer-example-Stocklist-adapter-java)
* [Lightstreamer - Portfolio Demo - Java Adapter](https://github.com/Weswit/Lightstreamer-example-Portfolio-adapter-java)
* [Lightstreamer - Reusable Metadata Adapters - Java Adapter](https://github.com/Weswit/Lightstreamer-example-ReusableMetadata-adapter-java)

<!-- END RELATED_ENTRIES -->
## Related Projects ##

* [Lightstreamer - Basic Stock-List Demo - .NET Client](https://github.com/Weswit/Lightstreamer-example-StockList-client-dotnet)

# Lightstreamer Compatibility Notes #

- Compatible with Lightstreamer .NET Client Library version 2.1 or newer.
- For Lightstreamer Allegro (+ .NET Client API support), Presto, Vivace.
