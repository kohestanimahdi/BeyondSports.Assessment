using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.Assessment.Infrastructure.Persistance.UnitOfWorks
{
    public class FootbalUnitOfWork : IFootbalUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public FootbalUnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
