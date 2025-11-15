using ShoppingCartAdmin.Class.Entities.Sellers;
using ShoppingCartAdmin.Class.Repository.Abstraction.Sellers;
using ShoppingCartAdmin.Models.Sellers;
using ShoppingCartAdmin.Service.Abstraction.Seller;

namespace ShoppingCartAdmin.Service.Services.Seller
{
    public class SellerDetailsService : ISellerDetailsService
    {
        private readonly ISellerDetailsRepository _repo;
        private readonly ICompanyService _companyService;
        private readonly ISellerLoginService _loginService;
        public SellerDetailsService(ISellerDetailsRepository repo, ICompanyService companyService, ISellerLoginService loginService)
        {
            _repo = repo;
            _companyService = companyService;
            _loginService = loginService;
        }

        public async Task<int> CreateSellerAsync(SellerDetailsModel model)
        {
            var entity = new SellerDetails
            {
                FullName = model.FullName,
                Email = model.Email,
                Phone = model.Phone,
                Role = model.Role,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "System",
                IsAdmin = model.IsAdmin ?? false
            };
            return await _repo.AddSellerDetailsAsync(entity);
        }

        public async Task<bool> DeleteAsync(int sellerId)
        {
            return await _repo.DeleteSellerAsync(sellerId);
        }

        public async Task<IEnumerable<SellerDetailsModel>> GetAllSellersAsync()
        {
            var sellerEntities = await _repo.GetAllSellerAsync();
            var companies = await _companyService.GetAllAsync();
            var loginEntities = await _loginService.GetAllLoginAsync();
            //var sellerModels = sellerEntities.Select(s => new SellerDetailsModel

            var sellerModels = sellerEntities.Select(s =>
            {
                var company = companies.FirstOrDefault(c => c.SellerId == s.SellerId);
                var login = loginEntities.FirstOrDefault(sl => sl.SellerId == s.SellerId);

                return new SellerDetailsModel
                {
                    SellerId = s.SellerId,
                    FullName = s.FullName,
                    Email = s.Email,
                    Phone = s.Phone,
                    Role = s.Role,
                    CreatedOn = s.CreatedOn,
                    IsActive = s.IsActive,
                    Company = company ?? new CompanyModel(),
                    SellerLogin = login ?? new SellerLoginModel()
                };

            });
            return sellerModels;
        }

        public async Task<SellerDetailsModel> GetSellerByIdAsync(int sellerId)
        {
            var s = await _repo.GetSellerByIdAsync(sellerId);
            var companies = await _companyService.GetAllAsync();
            var company = companies.FirstOrDefault(c => c.SellerId == sellerId);

            var logins = await _loginService.GetAllLoginAsync();
            var login = logins.FirstOrDefault(sl => sl.SellerId == sellerId);

            return new SellerDetailsModel
            {
                SellerId = s.SellerId,
                FullName = s.FullName,
                Email = s.Email,
                Phone = s.Phone,
                Role = s.Role,
                Company = company ?? new CompanyModel(),
                SellerLogin = login ?? new SellerLoginModel()
            };
        }

        public async Task<bool> UpdateSellerAsync(SellerDetailsModel model)
        {
            var entity = new SellerDetails
            {
                SellerId = model.SellerId,
                FullName = model.FullName,
                Email = model.Email,
                Phone = model.Phone,
                Role = model.Role
            };

            return await _repo.UpdateSellerAsync(entity);
        }
    }
}

