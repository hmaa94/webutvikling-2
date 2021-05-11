using LunaAPI.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace LunaAPI.Controller {

    [ApiController]
    [Route("[controller]")]

    public class MenyController : ControllerBase {
        private readonly MenyContext _context;
        /* private readonly IWebHostEnvironment _hosting;*/
        public MenyController(MenyContext context, IWebHostEnvironment hosting) {
            _context = context;
            /*_hosting = hosting;*/
        }

        [HttpGet("{id}")]
        public async Task<Food> Get(int id) {
            Food food = await _context.Food.FirstOrDefaultAsync ( _food => _food.Id == id);
            return food;
        }

        [HttpGet]
        public async Task<IEnumerable<Food>> Get() {
            List<Food> foodList = await _context.Food.ToListAsync();
            return foodList;
        }

        [HttpPost]

        public async Task<Food> Post(Food newFood){
            _context.Food.Add(newFood);
            await _context.SaveChangesAsync();
            return newFood;
        }


        [HttpPut]

        public async Task<Food> Put(Food food){
            _context.Update(food);
            await _context.SaveChangesAsync();
            return food;
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