using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalStoreManagementSystem.Model;
using MedicalStoreManagementSystem.Repository;
using MedicalStoreManagementSystem.Core.UserDetails;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace MedicalStoreManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes=CookieAuthenticationDefaults.AuthenticationScheme)]
    public class UserDetailsController : ControllerBase
    {
        private readonly BasicAuthDBContext _context;
        private readonly IUserDetails userDetails;
        public UserDetailsController(BasicAuthDBContext context,IUserDetails userDetails)
        {
            _context = context;
            this.userDetails = userDetails;
        }
        
        // GET: api/UserDetailsModels
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserDetailsModel>>> GetuserDetailsModels()
        {
            return await _context.userDetailsModels.ToListAsync();
        }

        // GET: api/UserDetailsModels/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserDetailsModel>> GetUserDetailsModel(int id)
        {
            var userDetailsModel = await _context.userDetailsModels.FindAsync(id);

            if (userDetailsModel == null)
            {
                return NotFound();
            }

            return userDetailsModel;
        }

        // PUT: api/UserDetailsModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDetailsModel(int id, UserDetailsModel userDetailsModel)
        {
            if (id != userDetailsModel.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userDetailsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailsModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserDetailsModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseModel>> SignUp([FromBody]UserDetailsModel userDetailsModel)
        {
            try
            {
                var response = await userDetails.SignUp(userDetailsModel);
                return response;
            }
            catch (Exception ex)
            {
                ResponseModel responseModel = new ResponseModel();
                responseModel.Message = ex.Message;
                return responseModel;
            }
        }
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                //await userDetails.Login(loginModel);
                var userDetail = await _context.userDetailsModels.Where(options =>
             options.UserName == loginModel.UserName && options.Password == loginModel.Password).Include(op => op.RolesModel).FirstOrDefaultAsync();
                if (userDetail == null)
                {
                    throw new Exception("Invalid Cardinals...!Enter Correct Data");
                }
                var claims = new List<Claim>
            {
                new Claim(type:ClaimTypes.Name,value:userDetail?.UserName),
                new Claim(type:ClaimTypes.Role,value:userDetail?.RolesModel?.RoleType),
            };
                var idetity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(idetity));
                return Ok("Login SuccessFul...!");

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        // DELETE: api/UserDetailsModels/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<UserDetailsModel>> DeleteUserDetailsModel(int id)
        {
            var userDetailsModel = await _context.userDetailsModels.FindAsync(id);
            if (userDetailsModel == null)
            {
                return NotFound();
            }

            _context.userDetailsModels.Remove(userDetailsModel);
            await _context.SaveChangesAsync();

            return userDetailsModel;
        }

        private bool UserDetailsModelExists(int id)
        {
            return _context.userDetailsModels.Any(e => e.UserId == id);
        }
    }
}
