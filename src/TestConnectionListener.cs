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

using System;

namespace Lightstreamer.DotNet.Client.Test {

	class TestConnectionListener : IConnectionListener {
		private long bytes = 0;

		public TestConnectionListener() {}

		public void OnConnectionEstablished() {
			Console.WriteLine("connection established");
		}

		public void OnSessionStarted(bool isPolling) {
            if (isPolling) {
    			Console.WriteLine("smart polling session started");
            } else {
    			Console.WriteLine("streaming session started");
            }
		}

		public void OnNewBytes(long newBytes) {
			this.bytes += newBytes;
		}

		public void OnDataError(PushServerException e) {
			Console.WriteLine("data error");
			Console.WriteLine(e);
		}

		public void OnActivityWarning(bool warningOn) {
			if (warningOn) {
				Console.WriteLine("connection stalled");
			} else {
				Console.WriteLine("connection no longer stalled");
			}
		}

		public void OnClose() {
			Console.WriteLine("total bytes: " + bytes);
		}

		public void OnEnd(int cause) {
			Console.WriteLine("connection forcibly closed");
		}

		public void OnFailure(PushServerException e) {
			Console.WriteLine("server failure");
			Console.WriteLine(e);
		}

		public void OnFailure(PushConnException e) {
			Console.WriteLine("connection failure");
			Console.WriteLine(e);
		}
	}

}
