# Lightstreamer - Quickstart Example - .NET Client #
<!-- START DESCRIPTION lightstreamer-example-quickstart-client-dotnet -->
The *Quickstart Example* provides the source code to build a very simple and basic client application, used to test the capability of the Client APIs to connect and receive data from Lightstreamer Server. The example can be used to familiarize with the Client APIs and as a reference on how to use them, and can be used as a starting point for client application implementations.

This project contains the C# source files of a sample application, which shows how the [Lightstreamer .NET Standard Client API](https://lightstreamer.com/api/ls-dotnetstandard-client/latest/) can be used to connect to Lightstreamer Server.
The Client API version in use in this example support the Unified Client API model.
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
 - [MAX_FREQUENCY]: double value in oreder to request to the Lightstreamer server a max frequency, 0.0 means unlimited (optional)
 - [FORCE_TRANSPORT]: could be WS-STREAMING, HTTP-STREAMING, WS-POLLING, or HTTP-POLLING. If no value passed or 'no' string passed the STREAM-SENSE algorithm of the Lightstreamer client lib will set-up the connection with the best transport available (optional)
 - [PROXY_ON]: 0/1 flag to use or not to use an http proxy (optional)
 - [PROXY_ADDRESS]: in the case, the ip address of the http proxy (optional)
 - [PROXY_PORT]: in the case, the port to connect the http proxy (optional)
 
### Dig the Code

The application is divided into 6 main classes.

* `QuickStart.cs`: this is the main class, implementing the connection to the Lightstreamer server, the subscription of Items and in case of Chat mode the send of text messages.
* `SystemOutClientListener.cs`: is a very basic custom implementation of the [ClientListener](https://lightstreamer.com/api/ls-dotnetstandard-client/latest/api/com.lightstreamer.client.ClientListener.html) interface. An instance of this class, listening to a LightstreamerClient instance (through the addListener method) will print on the standard output information about the status of the connection and will trigger the subscription request upon the status change event indicating the client session is alive.
* `QuoteListener.cs`, `PortfolioListener.cs`, and `ChatSubscriptionListener.cs`: are very basic custom implementations of the [SubscriptionListener](https://lightstreamer.com/api/ls-dotnetstandard-client/latest/api/com.lightstreamer.client.SubscriptionListener.html) interface. Basically just print on the console every event received.

## Install 

If you want to install a version of this demo pointing to our Demo Server, follow these steps:


* Since the app is an example of **Framework-Dependent Deployment (FDD)** relies on the presence of a shared system-wide version of .NET Core on the target system.
* Download the `deploy.zip` file that you can find in the [deploy release](https://github.com/Lightstreamer/Lightstreamer-example-Quickstart-client-dotnet/releases) of this project and extract the `deploy_local` folder.
* Execute the `LaunchMe.bat`.


## Build

To build a version of this example, pointing to your local Lightstreamer Server instance, follow the steps below.

* you'll need to install the following adapters (depending on which quickstart example you want to run you might not need them all):
	* The *CHAT_ROOM* (see the [Lightstreamer - Basic Chat Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Chat-adapter-java)). 
	* The *QUOTE_ADAPTER* (see the [Lightstreamer - Stock-List Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-StockList-adapter-java)) 
	* The *PORTFOLIO_ADAPTER* ( see the [Lightstreamer - Portfolio Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Portfolio-adapter-java)), 
  Follow the instructions on those projects to get them up and running (in the portfolio case, you'll need the *full version*).
  <i>[If you want to skip the Adapters installation you could target our Demos server (see below)]</i>
* Launch the Lightstreamer Server.
* Create a new C# project: from the "New Project..." wizard, choose the ".NET Core" and then "App Console" template.
* From the "Solution Explorer", delete the default `Program.cs`.
* Add all the files provided in the `src` folder of this project; from the "Add -> Existing Item" dialog.
* You should complete this project with the [Lightstreamer .NET Standard Client library](https://www.nuget.org/packages/Lightstreamer.DotNetStandard.Client/), to be used for the build process, trough NuGet. Follow these steps:
	* In the "Solution Explorer" tab, right click on the project and choose `Manage NuGet Packages ...`
	* In the Search text box enter `Lightstreamer`
	* Choose the <b>Lightstreamer.DotNetStandard.Client</b> last version then click `Install` and then `Ok`
	* Check out that among the References of your project <i>Lightstreamer.DotNetStandard.Client</i> was added.
* Build solution.
* In the "Launch profiles" add as "Command Line Arguments" suitable values for the quickstart example you want to run (see above).
  The HOST argument should be `http://localhost`; however, if you skipped the Adapter installation, you could address our Demo Server: `https://push.lightstreamer.com`
* Run the demo.


## See Also

### Lightstreamer Adapters Needed by These Clients 
<!-- START RELATED_ENTRIES -->

* [Lightstreamer - Stock-List Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Stocklist-adapter-java)
* [Lightstreamer - Portfolio Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Portfolio-adapter-java)
* [Lightstreamer - Basic Chat Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Chat-adapter-java))
* [Lightstreamer - Reusable Metadata Adapters - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-ReusableMetadata-adapter-java)

<!-- END RELATED_ENTRIES -->
### Related Projects 

* [Lightstreamer .NET Standard Client SDK](https://github.com/Lightstreamer/Lightstreamer-lib-client-haxe)
* [Lightstreamer - Basic Stock-List Demo - .NET Client](https://github.com/Lightstreamer/Lightstreamer-example-StockList-client-dotnet)

## Lightstreamer Compatibility Notes

- Compatible with Lightstreamer .NET Standard Client Library version 6 or newer.
- For a version of this demo compatible with Lightstreamer .NET Standard Client Library version 5.x, please refer to [this tag](https://github.com/Lightstreamer/Lightstreamer-example-Quickstart-client-dotnet/releases/tag/for_version_5).
- For a version of this demo compatible with .NET Standard Client library version 4.x, please refer to [this tag](https://github.com/Lightstreamer/Lightstreamer-example-Quickstart-client-dotnet/releases/tag/for_version_4).
- Ensure that .NET Standard Client API is supported by Lightstreamer Server license configuration.
