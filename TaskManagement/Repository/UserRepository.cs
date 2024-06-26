﻿using System.Threading.Tasks;
using TaskManagement.Data;
using TaskManagement.Interfaces;
using TaskManagement.Model;

namespace TaskManagement.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return Save();
        }

        public bool DeleteUser(User User)
        {
            _context.Remove(User);
            return Save();
        }

        public User GetUser(int UserID)
        {
            return _context.Users.Where(e => UserID == UserID).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool Save()
        {
            var Saved = _context.SaveChanges();
            return Saved > 0? true : false;
        }

        public bool UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return true;
        }

        public bool UsersExist(int UserID)
        {
            return _context.Users.Where(e => e.UserID == UserID).Any();
        }
    }
}
