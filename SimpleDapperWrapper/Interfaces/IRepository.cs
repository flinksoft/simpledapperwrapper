using Dapper;
using System.Collections.Generic;

namespace SimpleDapperWrapper.Interfaces
{
    public interface ISession
    {
        IEnumerable<T> Query<T>(string query, object param = null);
        void Execute(string sql, DynamicParameters parameters);
    }
}
