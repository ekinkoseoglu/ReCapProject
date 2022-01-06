using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Data.SqlClient;

namespace Backbone.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {

        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value,int duration);
        void Remove(string key);
        void RemoveByPattern(string pattern);
        bool isAdd(string key);
    }
}
