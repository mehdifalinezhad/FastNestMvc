using Domain;

namespace Application
{ 
    public interface IUnitOfWork
    {
        
        IGenericRepository<Foodplan> footPlans{ get; set; }
      //  IIndexGetData footPlans{ get; set; }
       
        Task<int> SaveChangesAsync();
    }
}
    