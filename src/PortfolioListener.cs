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
using System.Collections.Generic;

namespace QuickstartClient
{
    internal class PortfolioListener : SubscriptionListener
    {
        void SubscriptionListener.onClearSnapshot(string itemName, int itemPos)
        {
            Console.WriteLine("Clear Snapshot for " + itemName + ".");
        }

        void SubscriptionListener.onCommandSecondLevelItemLostUpdates(int lostUpdates, string key)
        {
            Console.WriteLine("Lost Updates for " + key + " (" + lostUpdates + ").");
        }

        void SubscriptionListener.onCommandSecondLevelSubscriptionError(int code, string message, string key)
        {
            Console.WriteLine("Subscription Error for " + key + ": " + message);
        }

        void SubscriptionListener.onEndOfSnapshot(string itemName, int itemPos)
        {
            Console.WriteLine("End of Snapshot for " + itemName + ".");
        }

        void SubscriptionListener.onItemLostUpdates(string itemName, int itemPos, int lostUpdates)
        {
            Console.WriteLine("Lost Updates for " + itemName + " (" + lostUpdates + ").");
        }

        void SubscriptionListener.onItemUpdate(ItemUpdate itemUpdate)
        {
            Console.WriteLine("Item update for ... ");
            Console.WriteLine(" ... " + itemUpdate.ItemName);

            IDictionary<string, string> listc = itemUpdate.ChangedFields;
            foreach (string value in listc.Values)
            {
                Console.WriteLine(" >>>>> " + value);
            }
        }

        void SubscriptionListener.onListenEnd(Subscription subscription)
        {
            // throw new System.NotImplementedException();
        }

        void SubscriptionListener.onListenStart(Subscription subscription)
        {
            // throw new System.NotImplementedException();
        }

        void SubscriptionListener.onRealMaxFrequency(string frequency)
        {
            Console.WriteLine("Real frequency: " + frequency + ".");
        }

        void SubscriptionListener.onSubscription()
        {
            Console.WriteLine("Start subscription.");
        }

        void SubscriptionListener.onSubscriptionError(int code, string message)
        {
            Console.WriteLine("Subscription error: " + message);
        }

        void SubscriptionListener.onUnsubscription()
        {
            Console.WriteLine("Stop subscription.");
        }
    }
}