using ShoppingCartAdmin.Class.Entities.Sellers;

namespace ShoppingCartAdmin.Class.Repository.Abstraction.Sellers
{
    public interface ICompanyRepository
    {
        Task<int> AddCompanyAsync(Company company, int sellerId);
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company> GetCompanyBySellerIdAsync(int sellerId);
        Task<bool> UpdateCompanyAsync(Company company, int sellerId);
        Task<bool> DeleteAsync(int sellerId);
    }

}
