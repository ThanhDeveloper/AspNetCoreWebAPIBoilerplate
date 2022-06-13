using Project.Core.Entities;
using Project.Core.Repositories;

namespace Project.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
