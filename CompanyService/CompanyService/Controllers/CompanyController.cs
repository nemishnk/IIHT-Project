using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CompanyBusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using MongoDB.Driver;

namespace CompanyService.Controllers
{
    [Route("api/v1/market/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        CompanyBL CompanyBusiness = new CompanyBL();
        /// <summary>
        /// For Registering the New company
        /// </summary>
        /// <returns></returns>
        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult> RegisterCompanyAsync(CompanyModel Model)
        {
            var result =  await CompanyBusiness.RegisterCompanyAsync(Model);
            return Ok(new {Message = HttpStatusCode.OK, data= Model });
        }



        /// <summary>
        /// Get Company details if the company ID is provided
        /// </summary>
        /// <param name="CompanyCode"></param>
        /// <returns></returns>
        [Route("info/{CompanyCode}")]
        [HttpGet]
        public ActionResult GetCompanyInfo(string CompanyCode)
        {
            var result = CompanyBusiness.GetCompanyInfo(CompanyCode);

            return Ok(new { Message = HttpStatusCode.OK, data = result });
        }


        /// <summary>
        /// Retuns all companies from the DB
        /// </summary>
        /// <returns></returns>
        [Route("Getall")]
        [HttpGet]
        public ActionResult GetAllCompany()
        {

            var result = CompanyBusiness.GetAllCompany();

            return Ok(new { Message = HttpStatusCode.OK, data = result });
        }

        /// <summary>
        /// Detete the complete details of the company
        /// </summary>
        /// <param name="CompanyCode"></param>
        /// <returns></returns>
        [Route("Delete/{CompanyCode}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteCompanyAsync( string CompanyCode)
        {
            var result = await CompanyBusiness.DeleteCompanyAsync(CompanyCode);

            return Ok(new { Message = HttpStatusCode.OK, data = result });
        }


        

    }
}