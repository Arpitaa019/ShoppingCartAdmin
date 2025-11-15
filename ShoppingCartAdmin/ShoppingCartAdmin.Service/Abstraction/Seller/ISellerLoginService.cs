using ShoppingCartAdmin.Models.Sellers;

namespace ShoppingCartAdmin.Service.Abstraction.Seller
{
    public interface ISellerLoginService
    {
        Task CreateLoginAsync(SellerLoginModel model, int sellerId);
        Task<IEnumerable<SellerLoginModel>> GetAllLoginAsync();
        Task<SellerLoginModel> GetLoginBySellerIdAsync(int sellerId);
        Task<bool> UpdateLoginAsync(SellerLoginModel model, int sellerId);
    }

}
