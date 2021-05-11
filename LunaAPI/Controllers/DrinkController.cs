using System.Collections.Generic;
using System.Threading.Tasks;
using LunaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace LunaAPI.Controller {
    
    [ApiController]
    [Route("[controller]")]

    public class DrinkController : ControllerBase {
        private readonly MenyContext _context;
        private readonly IWebHostEnvironment _hosting;

        public DrinkController(MenyContext context, IWebHostEnvironment hosting){
            _context = context;
            _hosting = hosting;
        }

        [HttpGet]
        public async Task<IEnumerable<Drinks>> Get(){
            List<Drinks> drinksList = await _context.Drinks.ToListAsync();
            return drinksList;
        }

        [HttpGet("{id}")]
        public async Task<Drinks> Get(int id) {
            Drinks drinks = await _context.Drinks.FirstOrDefaultAsync ( _drinks => _drinks.Id == id);
            return drinks;
        }
        
        [HttpPost]
        public async Task<Drinks> Post(Drinks newDrinks){
            _context.Drinks.Add(newDrinks);
            await _context.SaveChangesAsync();
            return newDrinks;
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

        [HttpPut]
        public async Task<Drinks> Put(Drinks updateDrinks){
            _context.Update(updateDrinks);
            await _context.SaveChangesAsync();
            return updateDrinks;
        }

        [HttpDelete("{id}")]
        public async Task<Drinks> Delete(int id){
            Drinks drinksToDelete = await _context.Drinks.FirstAsync( drinks => drinks.Id == id);
            _context.Drinks.Remove(drinksToDelete);
            await _context.SaveChangesAsync();
            return drinksToDelete;
        }
        
    }
}