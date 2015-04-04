using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository : IRepository
    {
        DataDataContext objContext = new DataDataContext();
        public Company GetComapnyDetailBySeoUrl(string SeoString)
        {
            return objContext.Companies.Where(o => o.SeoFriendlyName.ToLower().Trim() == SeoString.Trim()).FirstOrDefault();
        }
        public Company GetCompanyById(int id)
        {
            return objContext.Companies.Where(o => o.Id == id).FirstOrDefault();
        }
    }
}
