using Application;
using Application.Dto;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using persistant;
using Persistant.Migrations;
using System.Linq;
namespace Persistant
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        public IGenericRepository<Foodplan> footPlans { get; set; }
        public IGenericRepository<Symptoms> symptoms { get; set; }
        public IGenericRepository<State> states { get; set; }
        public IGenericRepository<UserInfo> userInfoAdd { get; set; }
        public IGetCityRepository getCityRepository { get; set; }
        public IGetUserInfoByUserId userInfo { get; set; }
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

        public ICollection<Symptoms> SymsonIdToSymsons(List<int> sysmsonsIds)
        {
            var sysmsonsObject = _context.Symptoms.Where(s => sysmsonsIds.Contains(s.Id)).ToList();

            return sysmsonsObject;
        }
        public async Task<DashBoardDto> GetUserAndUserInfo(string UserId)
        {
         
                Guid userGuid = Guid.Parse(UserId);
              User? dashUser =_userManager.Users.Where(c => c.Id == userGuid).FirstOrDefault();
            //UserInfo userInfo =await userInfoAdd.GetByIdAsync(1);
            var result = await _context.UserInfo.Where(o => o.UserId == userGuid)
             .Include(c => c.Symptoms).FirstOrDefaultAsync();
            
            //.Select(a => new DashBoardDto()
            //{\
            //  userInfo = new UserInfo()
            //  {
            //      age = a.age,
            //      weight = a.weight,
            //      BirthDay = a.BirthDay,
            //      ImageUrls = a.ImageUrls
            //  },
            //}).FirstOrDefaultAsync();
            DashBoardDto returnDto = new()
            { 
            
            userInfo=result
            };

            return returnDto;
         }
        
    }
}