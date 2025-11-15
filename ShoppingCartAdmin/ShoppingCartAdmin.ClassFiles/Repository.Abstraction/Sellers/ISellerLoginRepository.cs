using ShoppingCartAdmin.Class.Entities.Sellers;

namespace ShoppingCartAdmin.Class.Repository.Abstraction.Sellers
{
    public interface ISellerLoginRepository
    {
        Task AddLoginAsync(SellerLogin login, int sellerId);
        Task<IEnumerable<SellerLogin>> GetAllAsync();
        Task<SellerLogin> GetLoginBySellerIdAsync(int sellerId);
        Task<bool> UpdateLoginAsync(SellerLogin login, int sellerId);
    }

}
