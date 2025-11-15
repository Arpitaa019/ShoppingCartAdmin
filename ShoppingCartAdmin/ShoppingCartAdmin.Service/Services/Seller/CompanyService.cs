using ShoppingCartAdmin.Class.Entities.Sellers;
using ShoppingCartAdmin.Class.Repository.Abstraction.Sellers;
using ShoppingCartAdmin.Models.Sellers;
using ShoppingCartAdmin.Service.Abstraction.Seller;

namespace ShoppingCartAdmin.Service.Services.Seller
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repo;
        public CompanyService(ICompanyRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> CreateCompanyAsync(CompanyModel company, int sellerId)
        {
            var companyEntity = new Company
            {
                SellerId = sellerId,
                Name = company.Name,
                GSTIN = company.GSTIN,
                City = company.City,
                State = company.State,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "System",
                IsActive = true
            };
            return await _repo.AddCompanyAsync(companyEntity, sellerId);
        }

        public async Task<bool> DeleteCompanyBySellerIdAsync(int sellerId)
        {
            throw new NotImplementedException();
            // return await _repo.DeleteAsync(sellerId);
        }

        public async Task<IEnumerable<CompanyModel>> GetAllAsync()
        {
            var companyEntities = await _repo.GetAllAsync();
            var companyModels = companyEntities.Select(c => new CompanyModel
            {
                CompanyId = c.CompanyId,
                SellerId = c.SellerId,
                Name = c.Name,
                GSTIN = c.GSTIN,
                City = c.City,
                State = c.State

            }).ToList();
            return companyModels;
        }

        public async Task<CompanyModel> GetCompanyBySellerIdAsync(int sellerId)
        {
            throw new NotImplementedException();
            //return await _repo.DeleteAsync(sellerId);
        }

        public async Task<bool> UpdateCompanyAsync(CompanyModel company, int sellerId)
        {
            var entity = new Company
            {
                CompanyId = company.CompanyId,
                SellerId = company.SellerId,
                Name = company.Name,
                GSTIN = company.GSTIN,
                City = company.City,
                State = company.State
            };

            return await _repo.UpdateCompanyAsync(entity, sellerId);
        }
    }
}
