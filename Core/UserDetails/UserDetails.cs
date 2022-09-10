using MedicalStoreManagementSystem.Model;
using MedicalStoreManagementSystem.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MedicalStoreManagementSystem.Core.UserDetails
{
    public class UserDetails : IUserDetails
    {
        private readonly BasicAuthDBContext basicAuthDBContext;

        public UserDetails(BasicAuthDBContext basicAuthDBContext)
        {
            this.basicAuthDBContext = basicAuthDBContext;
        }

        public Task<ResponseModel> Login(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> SignUp(UserDetailsModel userDetailsModel)
        {
            try
            {
                var res = await basicAuthDBContext.userDetailsModels.AddAsync(userDetailsModel);
                await basicAuthDBContext.SaveChangesAsync();
                if(res != null)
                {
                    ResponseModel responseModel = new ResponseModel();
                    responseModel.Message = "Registration SuccessFull...!";
                    return responseModel;
                }
                else
                {
                    throw new Exception("Registration Failed...!");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
