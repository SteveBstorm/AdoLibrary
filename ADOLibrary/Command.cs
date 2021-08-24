using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOLibrary
{
    public class Command
    {
        internal string Query { get; private set; }
        internal bool IsStoredProcedure { get; private set; }
        internal Dictionary<string, object> Parameters { get; private set; }

        public Command(string query, bool isStoredProcedure = false)
        {
            if(string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("'query' n\'est pas une requête valide");
            }

            Query = query;
            Parameters = new Dictionary<string, object>();
            IsStoredProcedure = isStoredProcedure;
        }

        public void AddParameter(string parameterName, object value)
        {
            Parameters.Add(parameterName, value ?? DBNull.Value);
        }
    }
}
