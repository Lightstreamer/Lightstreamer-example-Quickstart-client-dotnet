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

using Lightstreamer.DotNet.Logging.Log;
using System.Collections.Generic;

namespace QuickstartClient
{
    class Log4NetLoggerWrapper : ILogger
    {
        private NLog.ILogger wrapped;

        public Log4NetLoggerWrapper(NLog.ILogger wrapped)
        {
            this.wrapped = wrapped;
        }

        public void Error(string line)
        {
            this.wrapped.Error(line);
        }

        public void Error(string line, System.Exception exception)
        {
            this.wrapped.Error(line, exception);
        }

        public void Warn(string line)
        {
            this.wrapped.Warn(line);
        }

        public void Warn(string line, System.Exception exception)
        {
            this.wrapped.Warn(line, exception);
        }

        public void Info(string line)
        {
            this.wrapped.Info(line);
        }

        public void Info(string line, System.Exception exception)
        {
            this.wrapped.Info(line, exception);
        }

        public void Debug(string line)
        {
            this.wrapped.Debug(line);
        }

        public void Debug(string line, System.Exception exception)
        {
            this.wrapped.Debug(line, exception);
        }

        public void Fatal(string line)
        {
            this.wrapped.Fatal(line);
        }

        public void Fatal(string line, System.Exception exception)
        {
            this.wrapped.Fatal(line, exception);
        }

        public bool IsDebugEnabled
        {
            get { return this.wrapped.IsDebugEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return this.wrapped.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return this.wrapped.IsWarnEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return this.wrapped.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return this.wrapped.IsFatalEnabled; }
        }
    }

    class Log4NetLoggerProviderWrapper : ILoggerProvider
    {
        private static IDictionary<string, Log4NetLoggerWrapper> logInstances = new Dictionary<string, Log4NetLoggerWrapper>();

        public ILogger GetLogger(string category)
        {
            lock (logInstances)
            {
                if (!logInstances.ContainsKey(category))
                {
                    logInstances[category] = new Log4NetLoggerWrapper(NLog.LogManager.GetLogger(category));
                }
                return logInstances[category];
            }
        }

    }
}