

using DataAccess.Context;
using System.Data;

namespace DataAccess
{
    public abstract class BaseRepository
    {
        protected readonly EFDataContext _context;
        protected readonly IDbConnection _dbConnection;

        public BaseRepository(EFDataContext context)
        {
            _context = context;
        }

        public BaseRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
    }
}
