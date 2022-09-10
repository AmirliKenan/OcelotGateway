using UserApi.Data;
using UserApi.Model;

namespace UserApi.Services.Impl
{
    public class UserService:IUserService
    {
        private readonly UserContext _context;

        public UserService(UserContext dbContext)
        {
            _context = dbContext;
        }

        public User AddUser(User product)
        {
            var result = _context.Users.Add(product);
            _context.SaveChanges();
            return result.Entity;
        }

        public bool DeleteUser(int Id)
        {
            var filteredData = _context.Users.Where(x => x.UserId == Id).FirstOrDefault();
            var result = _context.Remove(filteredData);
            _context.SaveChanges();
            return result != null ? true : false;
        }

        public User GetUserById(int id)
        {
            return _context.Users.Where(x => x.UserId == id).FirstOrDefault();
        }

        public IEnumerable<User> GetUserList()
        {
            return _context.Users.ToList();
        }

        public User UpdateUser(User product)
        {
            var result = _context.Users.Update(product);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}

