using Domain;

namespace Application
{ 
    public interface IUnitOfWork
    {
        
        IGenericRepository<Foodplan> footPlans{ get; set; }
        IGenericRepository<Symptoms> symptoms { get; set; }
        IGenericRepository<State> states { get; set; }
       
        Task<int> SaveChangesAsync();
    }
}
    