#region License
/*
* Copyright (c) Lightstreamer Srl
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/
#endregion License

using com.lightstreamer.client;
using com.lightstreamer.log;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;

namespace QuickstartClient
{
    /// <summary>
    /// Demonstrates basic Server access support, through LightstreamerClient facade.
    /// 
    /// Opens a connection to Lightstreamer Server and subscribes Items from
    /// QUOTE_ADAPTER, PORTFOLIO_ADAPTER, or CHAT_ROOM Data Adapters depending on 
    /// parameter passed in the command line. In case of CHAT_ROOM it is
    /// also possible to send messages to the CHAT Metadata Adapter by leveraging
    /// the Console.ReadLine utility.
    /// It requires that Lightstreamer Server is running with the
    /// proper Adapter Set, for more details please refer to the GitHub
    /// project (https://github.com/Lightstreamer/Lightstreamer-example-Quickstart-client-dotnet).
    /// 
    /// The test can be invoked with following parameters:
    /// >dotnet QuickStart5.dll HOST MODE [MAX_FREQUENCY] [FORCE_TRANSPORT] [PROXY_ON PROXY_ADDRESS PROXY_PORT]
    ///  - HOST: the complete hostname of the Lightstreamer server to target. For example to hit our 
    ///          Demos server use https://push.lightstreamer.com
    ///  - MODE: should be 0 for STOCK-LIST, 1 for CHAT, 2 for PORTFOLIO
    ///  - MAX_FREQUENCY: double value in oreder to request to the Lightstreamer server a max frequency 
    ///  - FORCE_TRANSPORT: could be WS-STREAMING, HTTP-STREAMING, WS-POLLING, or HTTP-POLLING. If no value passed
    ///                     the STREAM-SENSE algorithm of the Lightstreamer client lib will set-up the connection
    ///                     with the best transport available
    ///  - PROXY_ON: 0/1 to use or not to use a http proxy
    ///  - PROXY_ADDRESS: in the case, the ip address of the http proxy
    ///  - PROXY_PORT: in the case, the port to connect the http proxy
    /// 
    /// </summary>
    class QuickStart
    {
        private static LightstreamerClient ls;

        public static int quick_mode = 0;

        private static double sub_max_freq = 10.0;

        private static int proxy_on = 0;

        private static string proxy_addr = "";

        private static int proxy_port = 80;

        private static string forceT = "no";

        public static void SubscribeStocks()
        {
            Subscription s_stocks = new Subscription("MERGE");
            s_stocks.Fields = new string[3] { "last_price", "time", "stock_name" };
            s_stocks.Items = new string[3] { "item1", "item2", "item16" };
            s_stocks.DataAdapter = "QUOTE_ADAPTER";

            s_stocks.RequestedMaxFrequency = sub_max_freq + "";

            s_stocks.addListener(new QuoteListener());
            
            ls.subscribe(s_stocks);
            
        }

        public static void SubscribeCommand()
        {
            string portfolioId = "portfolio1";
            // portfolio contents; provided by the PORTFOLIO_ADAPTER in COMMAND mode
            string[] fieldList = new string[3]{"key", "command", "qty"};
            string[] secondLevelFieldList = new string[3] { "stock_name", "last_price", "time" };


            Subscription portfolioSubscription = new Subscription("COMMAND", portfolioId, fieldList);
            portfolioSubscription.DataAdapter = "PORTFOLIO_ADAPTER";
            portfolioSubscription.RequestedSnapshot = "yes";

            portfolioSubscription.RequestedMaxFrequency = sub_max_freq + "";

            portfolioSubscription.CommandSecondLevelDataAdapter = "QUOTE_ADAPTER";
            portfolioSubscription.CommandSecondLevelFields = secondLevelFieldList;

            portfolioSubscription.addListener(new PortfolioListener());

            ls.subscribe(portfolioSubscription);
        }

        public static void SubscribeChat()
        {
            Subscription s_chat = new Subscription("DISTINCT");
            s_chat.Fields = new string[3] { "message", "IP", "nick" };
            s_chat.Items = new string[1] { "chat_room" };
            s_chat.DataAdapter = "CHAT_ROOM";
            s_chat.RequestedSnapshot = "20";

            s_chat.RequestedMaxFrequency = sub_max_freq + "";

            s_chat.addListener(new ChatSubscriptionListener());

            ls.subscribe(s_chat);
        }

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            LightstreamerClient.setLoggerProvider(new ConsoleLoggerProvider(ConsoleLogLevel.WARN));
            
            Console.WriteLine("Args passed: " + args.Length);

            string serverAddress = args[0];

            Console.WriteLine("Try connecting to " + serverAddress + " ... ");
            try
            {
                if (args.Length > 1 )
                {
                    quick_mode = Int32.Parse(args[1]);

                    // Max Frequency
                    if (args.Length > 2)
                    {
                        double max_freq = Double.Parse(args[2]);
                        if ((max_freq > 0.0) && (max_freq < 200.0))
                        {

                            Console.WriteLine("Max freq : " + max_freq);

                            sub_max_freq = max_freq;
                        }

                        if (args.Length > 3)
                        {

                            forceT = args[3];

                            Console.WriteLine("Trasport will be forced to: " + forceT);

                            if (args.Length > 6)
                            {
                                if ( !Int32.TryParse(args[4], out proxy_on) )
                                {
                                    proxy_on = 0;
                                }

                                proxy_addr = args[5];

                                if ( !Int32.TryParse(args[6], out proxy_port) )
                                {
                                    proxy_port = 80;
                                }
                            }
                        }
                    }
                } 

                // On push.lightstreamer.com, there is a single Adapter Set, named "DEMO"
                // which is addressed by both the Chat, StockList, and Portfolio demos
                // available @ http://demos.lightstreamer.com/
                // On the other hand, if the Adapter Sets for these demos are installed
                // on a local instance of Lightstreamer Server by following the instructions
                // for the three demo Adapters, then three different Adapter Sets will be
                // configured, with different names.
                // The Data Adapter names of each demo are the same in both cases.

                string adapterSet = null;
                if (serverAddress.Contains("push.lightstreamer.com"))
                {
                    adapterSet = "DEMO";
                }
                else if (quick_mode == 1)
                {
                    adapterSet = "CHAT";
                }
                else if (quick_mode == 2)
                {
                    adapterSet = "FULLPORTFOLIODEMO";
                }
                else if (quick_mode == 0)
                {
                    adapterSet = "DEMO";
                }

                ls = new LightstreamerClient(serverAddress, adapterSet);

                Console.WriteLine(" ... ok ... " + ls.Status);

                ClientListener clientListener = new SystemOutClientListener(ls);
                ls.addListener(clientListener);

                ls.connectionOptions.ReconnectTimeout = 25000;

                if (!forceT.Equals("no", StringComparison.InvariantCultureIgnoreCase))
                {
                    ls.connectionOptions.ForcedTransport = forceT;

                    Console.WriteLine(" ... forced transport to " + forceT + " ... ");
                }

                /*
                 * 
                 * To add custom headers to the http requests, this is the example code.
                 * 
                */
                // Console.WriteLine(" ... add my headers ... ");
                // IDictionary<string, string> myheaders = new Dictionary<string, string>();
                // myheaders.Add("Test-H", "12345hello");
                // ls.connectionOptions.HttpExtraHeaders = myheaders;

                Console.WriteLine("Want Proxy ? " + proxy_on);
                if (proxy_on > 0)
                {
                    ls.connectionOptions.Proxy = new Proxy("HTTP", proxy_addr, proxy_port);

                    Console.WriteLine(" ... set connection proxy to " + proxy_addr + " : " + proxy_port);
                }
            
                ls.connect();
                while (true)
                {
                    string msg = Console.ReadLine();
                    if (quick_mode == 1)
                    {
                        ls.sendMessage("CHAT|" + msg);
                    }
                    if (msg.Contains("Exit")) break;
                }
            } catch (Exception e)
            {
                Console.WriteLine("Fatal Error: " + e.Message);
            }

            Console.WriteLine("Exiting ... ");
            Console.ReadKey();

        }

    }
}
