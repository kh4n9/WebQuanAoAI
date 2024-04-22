using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebQuanAoAI.Repository.Components
{
    public class BrandsViewComponent : ViewComponent 
    {
        private readonly ApplicationDbContext _datacontext;
        public BrandsViewComponent(ApplicationDbContext context)
        {
            _datacontext = context;
        }
        public async Task<IViewComponentResult> InvokeAsync() => View(await _datacontext.Brands.ToListAsync());
    }
}
