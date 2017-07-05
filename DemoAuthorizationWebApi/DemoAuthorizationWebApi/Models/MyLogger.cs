using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAuthorizationWebApi.Models
{
    public class MyLogger : ILogger
    {
        private ILog _log;

        public MyLogger(ILog _log)
        {
            this._log = _log;
        }

        public void Debug(Exception exception)
        {
            this._log.Debug(exception);
        }

        public void Debug(string message)
        {
            this._log.Debug(message);
        }

        public void Debug(string message, Exception exception)
        {
            this._log.Debug(message, exception);
        }

        public void Error(Exception exception)
        {
            this._log.Error(exception);
        }

        public void Error(string message)
        {
            this._log.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            this._log.Error(message, exception);
        }

        public void Info(Exception exception)
        {
            this._log.Info(exception);
        }

        public void Info(string message)
        {
            this._log.Info(message);
        }

        public void Info(string message, Exception exception)
        {
            this._log.Info(message, exception);
        }
    }
}