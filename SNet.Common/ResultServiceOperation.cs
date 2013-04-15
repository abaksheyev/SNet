using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNet.Common
{
    public class ResultServiceOperation<T> where T : new()
    {
        public bool ISSuccessfulOperation
        {
            get { return Errors.Count > 0; }
        }

        public Dictionary<string, string> Errors = new Dictionary<string, string>();

        public List<string> Messages = new List<string>();

        public List<T> Data = new List<T>();

        public Exception Exception;

        public object DataSingle
        {
            get { return Data.FirstOrDefault(); }
        }

        public ResultServiceOperation()
        {
            Errors = new Dictionary<string, string>();
            Data = new List<T>();
        }
    }
}
