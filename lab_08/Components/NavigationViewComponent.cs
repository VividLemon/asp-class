using Microsoft.AspNetCore.Mvc;
namespace Lab_06.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
