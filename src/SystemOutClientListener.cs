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
using System;

namespace QuickstartClient
{
    public class SystemOutClientListener : ClientListener
    {
        private LightstreamerClient client;

        private bool resub = true;

        public SystemOutClientListener(LightstreamerClient client)
        {
            this.client = client;
        }

        public void onListenEnd()
        {
        }

        public void onListenStart()
        {
        }

        public void onPropertyChange(string property)
        {
            Console.WriteLine("Property " + property + " changed: ");
            if ( this.client != null )
            {
                if (property.Equals("serverInstanceAddress"))
                {
                    Console.WriteLine(this.client.connectionDetails.ServerAddress);
                }
                if (property.Equals("sessionId"))
                {
                    Console.WriteLine(this.client.connectionDetails.SessionId);
                }    
                
            }
        }

        public void onServerError(int errorCode, string errorMessage)
        {
            Console.WriteLine("Server Error - " + errorMessage + " - " + errorCode);
        }

        public void onStatusChange(string status)
        {
            Console.WriteLine(" >>>>>>>>>>>>>>>>>> " + status + " - ");

            if ((status.StartsWith("CONNECTED:WS") || status.StartsWith("CONNECTED:HT")) && (resub) )
            {
                if (QuickStart.quick_mode == 1)
                {
                    QuickStart.SubscribeChat();
                }
                else if (QuickStart.quick_mode == 2)
                {
                    QuickStart.SubscribeCommand();
                }
                else if (QuickStart.quick_mode == 0)
                {
                    QuickStart.SubscribeStocks();
                }
                resub = false;
            }
        }
    }
}