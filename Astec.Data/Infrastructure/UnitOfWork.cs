using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astec.Data.Infrastructure
{
    public class UnitOfwork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private AstecDbContext dbContext;
        public UnitOfwork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public AstecDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }
        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
