using System;
using System.Data.SqlClient;

namespace FootBallData
{
    public class FootBallDbConnectionBase : IDisposable
    {
        public SqlConnection Connection { get; }
            

        public FootBallDbConnectionBase()
        {
            Connection = new SqlConnection(@"Data Source=DIRK-PC\SQLEXPRESS; Initial Catalog=FootBall; User id=FootBallData; Password=test123");
            Connection.Close();
            Connection.Open();
        }

        
        ~FootBallDbConnectionBase()
        {
            Connection.Close();
            Connection.Dispose();
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}