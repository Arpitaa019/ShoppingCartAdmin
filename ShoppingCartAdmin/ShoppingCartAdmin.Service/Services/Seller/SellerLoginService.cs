using ShoppingCartAdmin.Class.Entities.Sellers;
using ShoppingCartAdmin.Class.Repository.Abstraction.Sellers;
using ShoppingCartAdmin.Models.Sellers;

namespace ShoppingCartAdmin.Service.Abstraction.Seller
{
    public class SellerLoginService : ISellerLoginService
    {
        private readonly ISellerLoginRepository _repo;
        public SellerLoginService(ISellerLoginRepository repo)
        {
            _repo = repo;
        }
        public async Task CreateLoginAsync(SellerLoginModel model, int sellerId)
        {

            var loginEntity = new SellerLogin
            {
                SellerId = sellerId,
                Email = model.Email,
                Password = model.Password

            };
            await _repo.AddLoginAsync(loginEntity, sellerId);

        }

        public async Task<IEnumerable<SellerLoginModel>> GetAllLoginAsync()
        {
            var loginEntities = await _repo.GetAllAsync();

            var loginModels = loginEntities.Select(login => new SellerLoginModel
            {
                LoginId = login.LoginId,
                SellerId = login.SellerId,
                Email = login.Email,
                Password = login.Password
            });

            return loginModels;

        }

        public Task<SellerLoginModel> GetLoginBySellerIdAsync(int sellerId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateLoginAsync(SellerLoginModel model, int sellerId)
        {
            var entity = new SellerLogin
            {
                LoginId = model.LoginId,
                SellerId = model.SellerId,
                Email = model.Email,
                Password = model.Password
            };

            return await _repo.UpdateLoginAsync(entity, sellerId);
        }
    }
}
