using Core.IRepository;
using Core.Model;
using Repository.Data;
using Repository.UnitOfWork;


namespace Repository.Repositories
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UserRepository(IUnitOfWorkFactory unitOfWorkFactory, BaseDbContext context)
        {
            base.context = context;
            base.dbSet = context.Set<Users>();
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public override async Task Insert(Users entity)
        {
            await base.Insert(entity);
            SaveChanges();
        }

        public Users GetUserNameByEmail(string email)
        {
            var  query = base.Query(x => x.Email == email);
            Console.WriteLine(query);
            var users = query.FirstOrDefault();
            return users;
        }

    }
}
