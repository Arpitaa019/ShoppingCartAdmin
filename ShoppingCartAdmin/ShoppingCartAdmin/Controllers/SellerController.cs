using Microsoft.AspNetCore.Mvc;
using ShoppingCartAdmin.Service.Abstraction.Seller;

namespace ShoppingCartAdmin.Controllers
{
    [Route("Seller")]
    public class SellerController : Controller
    {
        private readonly ISellerDetailsService _service;
        private readonly ICompanyService _companyService;
        private readonly ISellerLoginService _loginService;

        public SellerController(ISellerDetailsService service, ICompanyService companyService, ISellerLoginService sellerLoginService)
        {
            _service = service;
            _companyService = companyService;
            _loginService = sellerLoginService;
        }

         [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("LoadDetailsAsync")]
        public async Task<IActionResult> LoadDetailsAsync()
        {
            var sellers = await _service.GetAllSellersAsync();
            var companies = await _companyService.GetAllAsync();
            var loginService = await _loginService.GetAllLoginAsync();

            return Json(new { success = true, data = new { seller = sellers, company = companies, credentials = loginService } });
        }
    }
}
