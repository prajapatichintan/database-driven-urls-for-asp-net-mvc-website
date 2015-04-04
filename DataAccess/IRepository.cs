using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
  public interface IRepository
    {
      Company GetComapnyDetailBySeoUrl(string SeoString);
      Company GetCompanyById(int id);
    }
}
