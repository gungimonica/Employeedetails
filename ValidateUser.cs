using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi
{
    public class ValidateUser
    {
        private readonly EmployeeDbcontext _dbcontext;
        
        
        public ValidateUser(EmployeeDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        
        public bool IsValidUser(string username, string password)
        {
           return _dbcontext.Userdetails.Any(u => u.username == username && u.password == password);

        }

    }
}

