using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.SharedKernel.DTOs
{
    public class OperationResult
    {
        public OperationResult(bool success, string messag, dynamic payload)
        {
            this.Success = success;
            this.Message = messag;
            this.Payload = payload;
        }
        public bool Success { get; set; }
        public string Message { get; set; }

        public dynamic Payload { get; set; }

        public static OperationResult Succeeded(string msg = "Operation Completed Successfully!.", dynamic payload = null)
        {
            return new OperationResult(true, msg, payload);
        }
        public static OperationResult NotFound(string msg = "Item Not Found!.", dynamic payload = null)
        {
            return new OperationResult(false, msg, payload);
        }
        public static OperationResult Failed(string msg = "Operation Failed!.", dynamic payload = null)
        {
            return new OperationResult(false, msg, payload);
        }

        public static OperationResult Existed(string msg = "Item Already Exisited!.", dynamic payload = null)
        {
            return new OperationResult(false, msg, payload);
        }

        // Add More Results .......

    }
}
