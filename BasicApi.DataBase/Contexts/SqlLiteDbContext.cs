using Dapper;
using System.Data;
using System.Data.SQLite;

namespace BasicApi.DataBase.Contexts
{
    public class SQLiteDbContext : IDisposable
    {
        private readonly SQLiteConnection _dbConn;
        private string _connectionString = "";

        public SQLiteDbContext()
        {
            _connectionString = "Data Source=C:\\Users\\Augusto\\AppData\\Roaming\\database.db;Version=3;";
            _dbConn = new SQLiteConnection(_connectionString, true);

            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public void Delete(string sql, object parameters = null)
        {
            using (_dbConn)
            {
                Open();
                _dbConn.Execute(sql, parameters);
            }
        }

        public int Insert<T>(string sql, object poco)
        {
            using (_dbConn)
            {
                Open();
                return _dbConn.ExecuteScalar<int>(sql, (T)poco);
            }
        }

        public T Select<T>(string sql, object parameters = null) where T : new()
        {
            using (_dbConn)
            {
                Open();
                return _dbConn.Query<T>(sql, parameters).FirstOrDefault();
            }
        }

        public void Update<T>(string sql, object poco)
        {
            using (_dbConn)
            {
                Open();
                _dbConn.Execute(sql, (T)poco);
            }
        }

        #region helpers
        public void Dispose()
        {
            _dbConn.Close();
            _dbConn.Dispose();
        }
        public void Open()
        {
            if (_dbConn.State == ConnectionState.Closed)
                _dbConn.Open();
        }
        #endregion
    }
}