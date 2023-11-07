using mvc11347.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace mvc11347.Controllers
{
    public class BikeController : Controller
    {
        // GET: Bike
        public async Task<ActionResult> Index()
        {
            string awsurl = "http://ec2-3-94-113-35.compute-1.amazonaws.com/";
            List<Bike> BikeInfo = new List<Bike>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(awsurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new
                    MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/bike");

                if (Res.IsSuccessStatusCode)
                {
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;
                    BikeInfo = JsonConvert.DeserializeObject<List<Bike>>(PrResponse);
                }
                    return View(BikeInfo);
            }
        }

        // GET: Bike/Details/5
        public async Task<ActionResult> Details(int id)
        {
            string awsurl = "http://ec2-3-94-113-35.compute-1.amazonaws.com/";
            Bike bike = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(awsurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"api/bike/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;
                    bike = JsonConvert.DeserializeObject<Bike>(PrResponse);
                }
            }

            if (bike != null)
            {
                return View(bike);
            }
            else
            {
                return HttpNotFound(); // Handle the case when the bike with the specified ID is not found.
            }
        }


        // GET: Bike/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bike/Create
        [HttpPost]
        public async Task<ActionResult> Create(Bike bike)
        {
            try
            {
                string awsurl = "http://ec2-3-94-113-35.compute-1.amazonaws.com/";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(awsurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var bikeJson = JsonConvert.SerializeObject(bike);
                    var content = new StringContent(bikeJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage Res = await client.PostAsync("api/bike", content);

                    if (Res.IsSuccessStatusCode)
                    {
                        // Bike created successfully, you can redirect to the "Index" action.
                        return RedirectToAction("Index");
                    }
                }

                // If something went wrong with the request, handle the error here.
                return View(bike);
            }
            catch
            {
                return View();
            }
        }




        // GET: Bike/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            string awsurl = "http://ec2-3-94-113-35.compute-1.amazonaws.com/";
            Bike bike = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(awsurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"api/bike/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;
                    bike = JsonConvert.DeserializeObject<Bike>(PrResponse);
                }
            }

            if (bike != null)
            {
                return View(bike);
            }
            else
            {
                return HttpNotFound(); 
            }
        }

        // POST: Bike/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Bike bike)
        {
            try
            {
                string awsurl = "http://ec2-3-94-113-35.compute-1.amazonaws.com/";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(awsurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var bikeJson = JsonConvert.SerializeObject(bike);
                    var content = new StringContent(bikeJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage Res = await client.PutAsync($"api/bike/{id}", content);

                    if (Res.IsSuccessStatusCode)
                    {
                        // Bike updated successfully, you can redirect to the "Index" action.
                        return RedirectToAction("Index");
                    }
                }

                return View(bike);
            }
            catch
            {
                return View();
            }
        }



        // GET: Bike/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            string awsurl = "http://ec2-3-94-113-35.compute-1.amazonaws.com/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(awsurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"api/bike/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var responseContent = await Res.Content.ReadAsStringAsync();
                    var bike = JsonConvert.DeserializeObject<Bike>(responseContent);
                    return View(bike);
                }
            }

            // Handle the case when the bike with the specified ID is not found.
            return HttpNotFound();
        }

    }
}
