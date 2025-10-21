using Application.Dto;
using Domain;

namespace Application
{ 
    public interface IUnitOfWork
    {
        
        IGenericRepository<Foodplan> footPlans{ get; set; }
        IGenericRepository<Symptoms> symptoms { get; set; }
        IGenericRepository<State> states { get; set; }
        IGenericRepository<UserInfo> userInfoAdd { get; set; }
        IGetCityRepository getCityRepository { get; set; }
        IGetUserInfoByUserId userInfo { get; set; }
        public User GetUserByUserId(string UserId);
        public List<User> GetUsers();
        public ICollection<Symptoms> SymsonIdToSymsons(List<int> susmsonsIds);
        Task<int> SaveChangesAsync();
        public Task<DashBoardDto> GetUserAndUserInfo(string UserId);
    }
}
    