using DoodleGone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoodleGone.Controllers
{
    public class EraserCatalogueController : Controller
    {
        public IActionResult Index()
        {
            // Sample data for erasers
            var erasers = new List<Eraser>
            {
                new Eraser { Id = 1, Name = "Premium Rubber Eraser", Colour = "Pink", Size = "Large", Durability = "High", Price = 2.99m },
                new Eraser { Id = 2, Name = "Eco-Friendly Eraser", Colour = "Green", Size = "Medium", Durability = "Medium", Price = 3.99m },
                new Eraser { Id = 3, Name = "Artist's Precision Eraser", Colour = "White", Size = "Small", Durability = "High", Price = 4.49m },
                new Eraser { Id = 4, Name = "Classic School Eraser", Colour = "Pink", Size = "Medium", Durability = "Low", Price = 1.99m },
                new Eraser { Id = 5, Name = "Highlighter Eraser", Colour = "Yellow", Size = "Medium", Durability = "Medium", Price = 3.49m }
            };

            return View(erasers); // Pass the list of erasers to the view
        }
    }
}