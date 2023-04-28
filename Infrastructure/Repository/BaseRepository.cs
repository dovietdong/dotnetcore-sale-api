using Core.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Dapper;

namespace Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        protected readonly string connectionString = "server=127.0.0.1;uid=root;pwd=1234;database=database-ban-hang";
        protected MySqlConnection _connection;

        public int Delete(Guid id)
        {
            return 123;
        }

        public IEnumerable<T> GetAll()
        {
            using (_connection = new MySqlConnection(connectionString))
            {
                //lấy tên table
                string className = typeof(T).Name;
                string tableName = className.ToLower();

                //2. lấy dữ liệu
                //khai báo câu lệnh SQL lấy dữ liệu
                var sqlCommand = $"SELECT * FROM {tableName}";

                //thực hiện lấy dữ liệu
                var res = _connection.Query<T>(sql: sqlCommand);

                return res;
            }
        }

        public IEnumerable<T> GetById(Guid id)
        {
            using (_connection = new MySqlConnection(connectionString))
            {
                //lấy tên table
                string className = typeof(T).Name;
                string tableName = className.ToLower();

                //2. lấy dữ liệu
                //khai báo câu lệnh SQL lấy dữ liệu
                var sqlCommand = $"SELECT * FROM {tableName} WHERE {className}Id = '{id}'";

                //thực hiện lấy dữ liệu
                var res = _connection.Query<T>(sql: sqlCommand);

                return res;
            }
        }

        public int Insert(T entity)
        {
            using (_connection = new MySqlConnection())
            {
                return 201;
            }
        }

        public int Update(T entity, Guid id)
        {
            return 12;
        }
    }
}
