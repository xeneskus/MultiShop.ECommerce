using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        public StatisticController(ICatalogStatisticService catalogStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            var getBrandCount = await _catalogStatisticService.GetBrandCount();
            var getProductCount = await _catalogStatisticService.GetProductCount();
            var getCategoryCount = await _catalogStatisticService.GetCategoryCount();
            var getMaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            var getMinPriceProductName = await _catalogStatisticService.GetMinPriceProductName();

       

            ViewBag.getBrandCount = getBrandCount;
            ViewBag.getProductCount = getProductCount;
            ViewBag.getCategoryCount = getCategoryCount;
            ViewBag.getMaxPriceProductName = getMaxPriceProductName;
            ViewBag.getMinPriceProductName = getMinPriceProductName;

            return View();
        }
    }
}
