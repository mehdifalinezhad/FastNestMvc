using Application;
using Domain;
using Microsoft.AspNetCore.Identity;
using persistant;
namespace Persistant
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        public IGenericRepository<Foodplan> footPlans { get; set;}
        public IGenericRepository<Symptoms> symptoms { get; set; }
        public IGenericRepository<State> states { get; set; }
        public IGenericRepository<UserInfo> userInfoAdd { get; set; }
        public IGetCityRepository getCityRepository { get; set; }
        public IGetUserInfoByUserId userInfo { get; set;}
        public UnitOfWork(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            footPlans = new GenericRepository<Foodplan>(_context);
            symptoms = new GenericRepository<Symptoms>(_context);
            states = new GenericRepository<State>(_context);
            userInfoAdd = new GenericRepository<UserInfo>(_context);
            getCityRepository = new GetCityRepository(_context);
            userInfo = new GetUserInfoByUserId(_context);
            _userManager = userManager;
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync(); 
        }

        public User GetUserByUserId(string UserId)
        {
            var UserLoged = _userManager.Users.Where(z => z.Id.ToString() == UserId).FirstOrDefault();
            if (UserLoged == null)
            {
                return new User();
            
            }
            return UserLoged;
        }

        public List<User> GetUsers()
        {
            var Userss = _userManager.Users.ToList();
            return Userss;
        }

        public ICollection<Symptoms> SysmsonIdToSymsons(List<int> sysmsonsIds)
        {
            var sysmsonsObject=_context.Symptoms.Where(s => sysmsonsIds.Contains(s.Id)).ToList();
           
            return sysmsonsObject;
        }

    }
}
