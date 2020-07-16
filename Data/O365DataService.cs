using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazor_base.Data
{
    public class O365DataService
    {
        public Task<O365Data> GetO365DataAsync()
        {
            return Task.FromResult(new O365Data
            {
            });
        }
    }
}


