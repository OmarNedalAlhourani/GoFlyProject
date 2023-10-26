using GoFly.BL.Models.ContactPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFly.BL.IRepositories
{

    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();


        void Add(T model);
		//public string AddMessage(Message message );
        void Update(int id, T model);
        void Delete(int id);


        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();




        void SaveData();
	}
}
