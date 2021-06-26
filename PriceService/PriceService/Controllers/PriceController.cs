using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using PriceBusinessLayer;

namespace PriceService.Controllers
{
    [Route("api/v1/market/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        PriceBusiness priceBusiness = new PriceBusiness();
        /// <summary>
        /// Adding the prices for the companies
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult> AddPriceAsync(Listpricemodel prices)
        {
            var pricelist = prices.price;
             var result = await priceBusiness.AddPriceAsync(pricelist);
            
            return Ok(new {
                message =HttpStatusCode.OK,
                data = result

            });
        }

        /// <summary>
        /// Getting the prices for the company with Start and end date
        /// </summary>
        /// <param name="CompanyCode"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        [Route("get/{CompanyCode}/{StartDate}/{EndDate}")]
        [HttpGet]
        public ActionResult GetPricedetails(string CompanyCode, string StartDate, string EndDate)
        {
            DateTime convertedstartdate = DateTime.Parse(StartDate);
            DateTime convertedenddate = DateTime.Parse(EndDate);
            var result = priceBusiness.GetPricedetails(CompanyCode, convertedstartdate, convertedenddate);

            return Ok(new
            {
                message = HttpStatusCode.OK,
                data = result

            });
        }

        /// <summary>
        /// Getting Min , Max , Average price for a day
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns></returns>
        [Route("gethistogram/{date}/{Code}")]
        [HttpGet]
        public ActionResult GetHistogram(string date, string Code)
        {
            DateTime converteddate = DateTime.Parse(date);
            var result = priceBusiness.GetHistogramonday(converteddate, Code);
            return Ok(new
            {
                message = HttpStatusCode.OK,
                data = result

            });
        }
    }
}