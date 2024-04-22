using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebQuanAoAI.Repository.Components
{
    public class CategoriesViewComponent : ViewComponent 
    {
        private readonly ApplicationDbContext _datacontext;
        public CategoriesViewComponent(ApplicationDbContext context)
        {
            _datacontext = context;
        }
        public async Task<IViewComponentResult> InvokeAsync() => View(await _datacontext.Categories.ToListAsync());
    }
}
