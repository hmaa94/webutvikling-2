using System.Collections.Generic;
using System.Threading.Tasks;
using LunaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace LunaAPI.Controllers {
    [ApiController]
    [Route("[controller]")]

    public class MenyAdminController : ControllerBase {
        
        private readonly MenyContext _context;
        private readonly IWebHostEnvironment _hosting;

        public MenyAdminController(MenyContext context, IWebHostEnvironment hosting){
            _context = context;
            _hosting = hosting;
        }

        [HttpGet]

        public async Task<IEnumerable<Food>> Get(){
            List<Food> foodList = await _context.Food.ToListAsync();
            return foodList;
        }

        [HttpGet("{id}")]

        public async Task<Food> Get(int id) {
            Food food = await _context.Food.FirstOrDefaultAsync ( food => food.Id == id);
            return food;
        }

        [HttpPost]
        [Route("[action]")]

        public void UploadImage(IFormFile file){
            string webRootPath = _hosting.WebRootPath;
            string absolutePath = Path.Combine($"{webRootPath}/images/{file.FileName}");
            using(var fileStream = new FileStream( absolutePath, FileMode.Create)){
                    file.CopyTo( fileStream );

            }
        }

        /*
      public async Task<Food> Post(Food food){
            _context.Food.Add(food);
            await _context.SaveChangesAsync();
            return food;
        }
        */
        [HttpPut]

        public async Task<Food> Put(Food updateFood){
            _context.Update(updateFood);
            await _context.SaveChangesAsync();
            return updateFood;
        }

        [HttpDelete("{id}")]

        public async Task<Food> Delete(int id){
            Food foodToDelete = await _context.Food.FirstAsync( food => food.Id == id);
            _context.Food.Remove(foodToDelete);
            await _context.SaveChangesAsync();
            return foodToDelete;
        }
    }
}