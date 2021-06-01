using Astec.Data.Infrastructure;
using Astec.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Astec.Data.Repositories
{
    public interface IEmployeeRepository : IRepository<EMPLOYEE>
    {

        EMPLOYEE GetById(int id);

    }

    public class EmployeeRepository : RepositoryBase<EMPLOYEE>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public EMPLOYEE GetById(int id)
        {
            var query = (from f in DbContext.EMPLOYEES
                        where f.Id == id
                        select f).FirstOrDefault();
            return query;
        }
    }
}