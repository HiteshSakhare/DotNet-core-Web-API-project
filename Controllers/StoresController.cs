using MedicalStoreManagementSystem.Core.StoreDetails;
using MedicalStoreManagementSystem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStoreManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreData storeData;

        public StoresController(IStoreData storeData)
        {
            this.storeData = storeData;
        }
        [HttpGet]
        
        public IActionResult GetStoreDetails()
        {
            return Ok(storeData.GetStoreDetails());
        }
        [HttpGet]
        [Route("api/[controller]/{StoreId}")]
        public IActionResult GetStoreDetails(Guid StoreId)
        {
            var storeDetail = storeData.GetStoreDetail(StoreId);
            if(storeDetail != null)
            {

                return Ok(storeDetail);
            }
            return NotFound($"Store with Id: {StoreId} Not Found.");
        }
        [HttpPost]
        public IActionResult AddStore(StoreModel storeModel)
        {
            storeData.AddStore(storeModel);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + storeModel.StoreId, storeModel);
        }
    }
}
