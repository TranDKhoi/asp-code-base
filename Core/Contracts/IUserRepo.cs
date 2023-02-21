using asp_code_base.Dtos.User;
using asp_code_base.Models;

namespace asp_code_base.Core.Contracts
{
    public interface IUserRepo
    {
        public Task<(User,String)> Login(LoginDto loginDto);
        public Task<User> GetById(string id);
    }
}
