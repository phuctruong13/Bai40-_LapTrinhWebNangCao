using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogAPI.Data;
using blogAPI.Dto.User;
using blogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace blogAPI.Responsitories
{
   public class UserRepository
    {
        private readonly AppDBContext _context;
        public UserRepository(AppDBContext context)
        {
            _context = context;
        }
        public UserDto InsertUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            var result = new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                DateOfBirth = user.DateOfBirth
            };
            return result;
        }
        public async Task<List<UserDto>> GetListUser()
        {
            try
            {
                var result = await _context.Users.AsNoTracking().Select(user => new UserDto()
                {
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    ID = user.ID,
                    Phone = user.Phone,
                    Address = user.Address,
                    DateOfBirth = user.DateOfBirth,
                }).ToListAsync();
                return result;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteUser(Guid Id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.ID == Id);

            if (user == null)
            {
                return false;
            };

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;

        }


        public async Task<UserDto> EditUser(Guid Id, User userNew)
        {

            var userExist = await _context.Users.FirstOrDefaultAsync(user => user.ID == Id);

            if (userExist == null)
            {
                return null;
            };
            userExist.DisplayName = userNew.DisplayName;
            userExist.Email = userNew.Email;
            userExist.Phone = userNew.Phone;
            userExist.Address = userNew.Address;
            userExist.DateOfBirth = userNew.DateOfBirth;

            await _context.SaveChangesAsync();

            return new UserDto()
            {
                DisplayName = userExist.DisplayName,
                Email = userExist.Email,
                ID = userExist.ID,
                Phone = userExist.Phone,
                Address = userExist.Address,
                DateOfBirth = userExist.DateOfBirth,
            };
        }
    }
}