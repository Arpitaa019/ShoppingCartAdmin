using ShoppingCartAdmin.Models.Sellers;

namespace ShoppingCartAdmin.Service.Abstraction.Seller
{
    public interface ICompanyService
    {
        Task<int> CreateCompanyAsync(CompanyModel company, int sellerId);
        Task<IEnumerable<CompanyModel>> GetAllAsync();
        Task<CompanyModel> GetCompanyBySellerIdAsync(int sellerId);
        Task<bool> UpdateCompanyAsync(CompanyModel company, int sellerId);
        Task<bool> DeleteCompanyBySellerIdAsync(int sellerId);
    }

}
