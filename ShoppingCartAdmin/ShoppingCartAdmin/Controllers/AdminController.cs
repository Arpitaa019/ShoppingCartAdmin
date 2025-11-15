using Microsoft.AspNetCore.Mvc;

namespace ShoppingCartAdmin.Controllers
{
    public class AdminController : Controller
    {
        public AdminController()
        {
            
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminSellerManagement(int id)
        {
            return View();
        }
        public ActionResult AdminSellerList()
        {
            return View();
        }

        public ActionResult AdminCustomerManagement(int id)
        {
            return View();
        }
        public ActionResult AdminCustomerList()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }
        
    }
}
