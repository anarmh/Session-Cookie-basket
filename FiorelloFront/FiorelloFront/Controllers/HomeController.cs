
using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace FiorelloFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
           IEnumerable<Slider> sliders=await _context.Sliders.Where(m=>!m.SoftDelete).ToListAsync();
            SliderInfo sliderInfo= await _context.SliderInfos.Where(m=>!m.SoftDelete).FirstOrDefaultAsync();
            IEnumerable<Blog> blogs=await _context.Blogs.Where(m => !m.SoftDelete).OrderByDescending(m=>m.Id).Take(3).ToListAsync();
            IEnumerable<Category> categories=await _context.Categories.Where(m => !m.SoftDelete).ToListAsync();
            IEnumerable<Product> products = await _context.Products.Include(m=>m.ProductImages).Take(8).Where(m => !m.SoftDelete).ToListAsync();
            About about=await _context.Abouts.Where(m => !m.SoftDelete).FirstOrDefaultAsync();
            IEnumerable<FlowersExpert> flowersExperts = await _context.FlowersExperts.Where(m => !m.SoftDelete).ToListAsync();
            IEnumerable<Say> says = await _context.Says.Where(m => !m.SoftDelete).ToListAsync();
            IEnumerable<Instagram> instagrams = await _context.Instagrams.Where(m => !m.SoftDelete).ToListAsync();
            HomeVM model = new()
            {
                SliderInfo = sliderInfo,
                Sliders = sliders,
                Blogs=blogs,
                Categories= categories,
                Products= products,
               About= about,
               FlowersExperts= flowersExperts,
               Says= says,
               Instagrams= instagrams
            };

            return View(model);
        }

       
    }
}