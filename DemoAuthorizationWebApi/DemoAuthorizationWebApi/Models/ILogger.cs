using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAuthorizationWebApi.Models
{
    public interface ILogger
    {
        void Debug(string message);
        void Debug(string message, Exception exception);
        void Debug(Exception exception);

        void Info(string message);
        void Info(string message, Exception exception);
        void Info(Exception exception);

        void Error(string message);
        void Error(string message, Exception exception);
        void Error(Exception exception);
    }
}
