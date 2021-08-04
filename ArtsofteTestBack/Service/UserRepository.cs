using ArtsofteTestBack.Data;
using ArtsofteTestBack.Interfaces;
using ArtsofteTestBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteTestBack.Service
{
    public class UserRepository : IUser
    {
        private UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        //public User GetByPhone(string phone)
        //{
        //    return _context.Users.Where(u => u.Phone == phone).FirstOrDefault();
        //}

        public void Insert(User user)
        {
            _context.Users.Add(user);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
