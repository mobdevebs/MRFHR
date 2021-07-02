using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Application.DataAccess.DataContext
{
    public abstract class DatabaseContext
    {
        private readonly AppConfiguration appConfiguration;

        protected DatabaseContext(AppConfiguration appConfiguration)
        {
            this.appConfiguration = appConfiguration;
        }

        protected IDbConnection GetConnection()
        {
            return new SqlConnection(this.appConfiguration.sqlConnectionString);
        }
    }
}
