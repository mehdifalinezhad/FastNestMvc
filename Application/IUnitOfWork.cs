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

        Task<int> SaveChangesAsync();
    }
}
    