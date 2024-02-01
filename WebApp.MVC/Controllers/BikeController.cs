using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebApp.Domain.Models;

namespace WebApp.MVC.Controllers
{
    public class BikeController : Controller
    {

        Uri baseAddress = new Uri("https://api.jcdecaux.com/vls/v1/stations?contract=Dublin&apiKey=3aa66c7d23f6a40af417fc87ba25d34c2d285d4a");

        private readonly HttpClient _httpClient;

        public BikeController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        // GET: BikeController
        public ActionResult Index()
        {
            List<BikeStation> bikeStations = new();

            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(baseAddress).Result;


            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                bikeStations = JsonConvert.DeserializeObject<List<BikeStation>>(data);
            }


            return View(bikeStations);
        }

        // GET: BikeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BikeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BikeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BikeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BikeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BikeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BikeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
