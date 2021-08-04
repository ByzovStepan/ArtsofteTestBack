using ArtsofteTestBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteTestBack.Interfaces
{
    public interface IUser
    {
        List<User> GetAll();
        User GetById(int id);
        //User GetByPhone(string phone);
        void Insert(User user);
        void Update(User user);
        void Delete(User user);
        void Save();
    }
}
