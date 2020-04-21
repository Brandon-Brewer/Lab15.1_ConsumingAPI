﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lab151_ConsumingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab151_ConsumingAPI.Controllers
{
    public class CardsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Hand()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://deckofcardsapi.com");

            var response = await client.GetAsync("api/deck/pwaiymjs4tqy/draw/?count=5");
  
            var cards = await response.Content.ReadAsAsync<Hand>();

            return View(cards);
        }
    }
}