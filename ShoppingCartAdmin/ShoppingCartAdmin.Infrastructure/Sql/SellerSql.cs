using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartAdmin.Infrastructure.Sql
{
    public static class SellerSql
    {
        public const string InsertSellerDetails = "sp_InsertSellerDetails";
        public const string InsertCompany = "sp_InsertCompany";
        public const string InsertSellerLogin = "sp_InsertSellerLogin";

        public const string UpdateCompanyDetails = "sp_UpdateCompanyDetails";
        public const string UpdateSellerDetails = "sp_UpdateSellerDetails";
        public const string UpdateSellerLoginDetails = "sp_UpdateSellerLogins";

        public const string GetAllSellerDetails = "sp_GetAllSellerDetails";
        public const string GetAllCompanies = "sp_GetAllCompanies";
        public const string GetAllSellerLogins = "sp_GetAllSellerLogins";
        public const string GetSellerDetailsById = "sp_GetSellerDetailsById";

    }
}
