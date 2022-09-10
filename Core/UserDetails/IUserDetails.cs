using MedicalStoreManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStoreManagementSystem.Core.UserDetails
{
    public interface IUserDetails
    {
        Task<ResponseModel> SignUp(UserDetailsModel userDetailsModel);
        Task<ResponseModel> Login(LoginModel loginModel);
    }
}
