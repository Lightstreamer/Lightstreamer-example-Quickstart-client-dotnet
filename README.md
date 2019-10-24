# Lightstreamer - Quickstart Example - .NET Client #
<!-- START DESCRIPTION lightstreamer-example-quickstart-client-dotnet -->
The *Quickstart Example* provides the source code to build a very simple and basic client application, used to test the capability of the Client APIs to connect and receive data from Lightstreamer Server. The example can be used to familiarize with the Client APIs and as a reference on how to use them, and can be used as a starting point for client application implementations.

This project contains the C# source files of a sample application, which shows how the [Lightstreamer .NET Standard Client API](https://lightstreamer.com/temp/temp_dotnet_unified_docs/) can be used to connect to Lightstreamer Server.
The Client API version in use in this example support the Unified Client API model (since Lightstreamer .NET Standard API 5.0.0).
<!-- END DESCRIPTION lightstreamer-example-quickstart-client-dotnet -->

![screenshot](screen_qs.png)

## Details

The example basically connects to the server and performs a subscription, printing on the console the incoming Item Updates.
Some connection parameters and the type of subscription performed depend on the parameters passed in the command line; which in the right order are:   
 - HOST: the complete hostname of the Lightstreamer server to target. For example to hit our Demos server use https://push.lightstreamer.com
 - MODE: should be 
	* 0 for Stock-List subscription targeting the QUOTE_ADAPTER Data Adapter
	* 1 for Chat subscription targeting the CHAT_ROOM Data Adapter
	* 2 for Portfolio subscription targeting the PORTFOLIO_ADAPTER Data Adapter
 - [MAX_FREQUENCY]: double value in oreder to request to the Lightstreamer server a max frequency (optional)
 - [FORCE_TRANSPORT]: could be WS-STREAMING, HTTP-STREAMING, WS-POLLING, or HTTP-POLLING. If no value passed the STREAM-SENSE algorithm of the Lightstreamer client lib will set-up the connection with the best transport available (optional)
 - [PROXY_ON: 0/1] to use or not to use a http proxy (optional)
 - [PROXY_ADDRESS]: in the case, the ip address of the http proxy (optional)
 - [PROXY_PORT]: in the case, the port to connect the http proxy (optional)
 
### Dig the Code

The application is divided into 6 main classes.

* `QuickStart.cs`: this is the main class, implementing the connection to the Lightstreamer server, the subscription of Items and in case of Chat mode the send of text messages.
* `SystemOutClientListener.cs`: is a very basic custom implementation of the [ClientListener](https://lightstreamer.com/temp/temp_dotnet_unified_docs/api/com.lightstreamer.client.ClientListener.html) interface. An instance of this class, listening to a LightstreamerClient instance (through the addListener method) will print on the standard output informations about the status of the connection and will trigger the subscription request upon the status change event indicating the client session is alive.
* `QuoteListener.cs`, `PortfolioListener.cs`, and `ChatSubscriptionListener.cs`: are very basic custom implementations of the [SubscriptionListener](https://lightstreamer.com/temp/temp_dotnet_unified_docs/api/com.lightstreamer.client.SubscriptionListener.html) interface. Basically just print on the console every event received.
* `Log4NetLoggerWrapper.cs`: this is a wrapper class to allow the client library to log through [NLog](https://www.nuget.org/packages/NLog/).


## Install 

If you want to install a version of this demo pointing to your local Lightstreamer Server, follow these steps:

* you'll need to install the following adapters (depending on which quickstart example you want to run you might not need them all):
	* The *CHAT_ROOM* (see the [Lightstreamer - Basic Chat Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Chat-adapter-java)). 
	* The *QUOTE_ADAPTER* (see the [Lightstreamer - Stock-List Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-StockList-adapter-java)) 
	* The *PORTFOLIO_ADAPTER* ( see the [Lightstreamer - Portfolio Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Portfolio-adapter-java)), 
  Follow the instructions on those projects to get them up and running (in the portfolio case, you'll need the *full version*).
* Since the app is an example of **Framework-Dependent Deployment (FDD)** relies on the presence of a shared system-wide version of .NET Core on the target system.
* Launch Lightstreamer Server.
* Download the `deploy.zip` file that you can find in the [deploy release](https://github.com/Lightstreamer/Lightstreamer-example-Quickstart-client-dotnet/releases) of this project and extract the `deploy_local` folder.
* Execute the `LaunchMe.bat`.


## Build

To build a version of this example, pointing to your local Lightstreamer Server instance, follow the steps below.

* Exactly as in the previous section, you should install in your Lightstreamer server the *CHAT_ROOM* or the *PORTFOLIO_ADAPTER* or the *QUOTE_ADAPTER*. If you want to skip the Adapters installation you could target our Demos server (http://push.lightstreamer.com).
* Create a new C# project: from the "New Project..." wizard, choose the ".NET Core" and then "App Console" template.
* From the "Solution Explorer", delete the default `Program.cs`.
* Add all the files provided in the `sources` folder of this project; from the "Add -> Existing Item" dialog.
* You should complete this project with the [Lightstreamer .NET Standard Client library](https://www.nuget.org/packages/Lightstreamer.DotNetStandard.Client/5.0.0-beta), to be used for the build process, trough NuGet. Follow these steps:
	* In the "Solution Explorer" tab, right click on the project and choose `Manage NuGet Packages ...`
	* In the Search text box enter `Lightstreamer` and be sure to flag the *Include preliminary version* check-box
	* Choose the Lightstreamer.DotNetStandard.Client last version then click `Install` and then `Ok`
	* Check out that among the References of your project Lightstreamer_DotNet_Standard_Client was added.
* As in the previous steps add to your project also the reference to [NLog](https://www.nuget.org/packages/NLog/).
* Build solutions and run the demo.


## See Also

### Lightstreamer Adapters Needed by These Clients 
<!-- START RELATED_ENTRIES -->

* [Lightstreamer - Stock-List Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Stocklist-adapter-java)
* [Lightstreamer - Portfolio Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Portfolio-adapter-java)
* [Lightstreamer - Basic Chat Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Chat-adapter-java))
* [Lightstreamer - Reusable Metadata Adapters - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-ReusableMetadata-adapter-java)

<!-- END RELATED_ENTRIES -->
### Related Projects 

* [Lightstreamer - Basic Stock-List Demo - .NET Client](https://github.com/Lightstreamer/Lightstreamer-example-StockList-client-dotnet)

## Lightstreamer Compatibility Notes

- Compatible with Lightstreamer .NET Standard Client Library version 5.0.0 or newer.
- For instructions compatible with .NET Standard Client library version 4.x, please refer to [this tag](https://github.com/Lightstreamer/Lightstreamer-example-Quickstart-client-dotnet/releases/tag/for_version_4).
- Ensure that .NET Standard Client API is supported by Lightstreamer Server license configuration.
