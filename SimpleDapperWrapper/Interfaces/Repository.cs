﻿using Dapper;
using SimpleDapperWrapper.Interfaces;
using System.Collections.Generic;

namespace SimpleDapperWrapper
{
    public class Session : ISession
    {
        private readonly IDapperContext _context;

        public Session(string connectionString)
        {
            _context = new DapperContext(connectionString);
        }

        public Session(IDapperContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> Query<T>(string query, object param)
        {
            return _context.Transaction(transaction =>
            {
                var result = _context.Connection.Query<T>(query, param, transaction);
                return result;
            });
        }

        public void Execute(string sql, DynamicParameters parameters)
        {
            _context.Transaction(transaction => _context.Connection.Execute(sql, parameters, transaction, null, System.Data.CommandType.StoredProcedure));
        }
    }
}
