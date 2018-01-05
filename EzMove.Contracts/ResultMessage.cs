using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Contracts
{
    public class ResultMessage
    {
        public ResultMessage(Exception ex)
        {
            Success = false;
            StatusMessage = ex.Message;
            ErrorStackTrace = ex.StackTrace;
        }

        public string ErrorStackTrace { get; set; }
        public string StatusMessage { get; set; }
        public bool Success { get; set; }
    }
}
