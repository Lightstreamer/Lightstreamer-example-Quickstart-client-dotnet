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
    public class OrderMessageListener : ClientMessageListener
    {
        void ClientMessageListener.onAbort(string originalMessage, bool sentOnNetwork)
        {
            if (sentOnNetwork)
            {
                Console.WriteLine("message " + originalMessage + " was aborted; is not known if it reached the server");
            }
            else
            {
                Console.WriteLine("message " + originalMessage + " was aborted and will not be sent to the server");
            }
        }

        void ClientMessageListener.onDeny(string originalMessage, int code, string error)
        {
            Console.WriteLine("message " + originalMessage + " was denied by the server because of error " + code + ": " + error);
        }

        void ClientMessageListener.onDiscarded(string originalMessage)
        {
            Console.WriteLine("message " + originalMessage + " was discarded by the server because it was too late when it was received");
        }

        void ClientMessageListener.onError(string originalMessage)
        {
            Console.WriteLine("message " + originalMessage + " was not correctly processed by the server");
        }

        void ClientMessageListener.onProcessed(string originalMessage, string response)
        {
            Console.WriteLine("message " + originalMessage + " sent with response: " + response);
        }
    }
}