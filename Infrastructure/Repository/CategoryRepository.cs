using Core.Entities;
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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

    }
}
