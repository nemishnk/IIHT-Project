using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyDataLayer;
namespace CompanyBusinessLayer
{
    public class CompanyBL
    {
        CompanyDL datalayer = new CompanyDL();
        public async Task<CompanyModel> RegisterCompanyAsync(CompanyModel model)
        {
            
            var result =  await datalayer.RegisterCompanyAsync(model);
            
            return result;
        }

        public string GenerateCompanyCode(CompanyModel model)
        {
            
            return "s";
        }

        public CompanyModel GetCompanyInfo(string CompanyCode)
        {
            var result = datalayer.GetCompanyInfo(CompanyCode);
            return result;
        }

        public List<CompanyModel> GetAllCompany()
        {
            var result = datalayer.GetAllCompany();
            return result;
        }

        public async Task<long> DeleteCompanyAsync(string CompanyCode)
        {
            var result = await datalayer.DeleteCompanyAsync(CompanyCode);
            
            return result;
        }

        

    }
}
