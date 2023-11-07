using mvc11347.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;
using System.Text;

namespace mvc11347.Controllers
{
    public class BikeCategoryController : Controller

    {
        string aws ="http://ec2-3-94-113-35.compute-1.amazonaws.com/";

        // GET: BikeCategory
        public async Task<ActionResult> Index()
        {
            string awsurl = "http://ec2-3-94-113-35.compute-1.amazonaws.com/";
            List<BikeCategory> categories = new List<BikeCategory>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(awsurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/bikecategory");

                if (Res.IsSuccessStatusCode)
                {
                    var responseContent = await Res.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<List<BikeCategory>>(responseContent);
                    return View(categories);
                }
            }

            // Handle the case when no categories are found or an error occurs.
            return HttpNotFound();
        }


        // GET: BikeCategory/Details/5
        public async Task<ActionResult> Details(int id)
        {
            string awsurl = "http://ec2-3-94-113-35.compute-1.amazonaws.com/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(awsurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"api/bikecategory/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var responseContent = await Res.Content.ReadAsStringAsync();
                    var category = JsonConvert.DeserializeObject<BikeCategory>(responseContent);
                    return View(category);
                }
            }

            // Handle the case when the category with the specified ID is not found or an error occurs.
            return HttpNotFound();
        }


        // GET: BikeCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BikeCategory/Create
        [HttpPost]
        public async Task<ActionResult> Create(BikeCategory category)
        {
            try
            {
                string awsurl = "http://ec2-3-94-113-35.compute-1.amazonaws.com/";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(awsurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var categoryJson = JsonConvert.SerializeObject(category);
                    var content = new StringContent(categoryJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage Res = await client.PostAsync("api/bikecategory", content);

                    if (Res.IsSuccessStatusCode)
                    {
                        // Category created successfully, you can redirect to the "Index" action.
                        return RedirectToAction("Index");
                    }
                }

                // If something went wrong with the request, handle the error here.
                return View(category);
            }
            catch
            {
                return View();
            }
        }

        // GET: BikeCategory/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            string awsurl = "http://ec2-3-94-113-35.compute-1.amazonaws.com/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(awsurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"api/bikecategory/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var responseContent = await Res.Content.ReadAsStringAsync();
                    var category = JsonConvert.DeserializeObject<BikeCategory>(responseContent);
                    return View(category);
                }
            }

            // Handle the case when the category with the specified ID is not found or an error occurs.
            return HttpNotFound();
        }

        // POST: BikeCategory/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, BikeCategory category)
        {
            try
            {
                string awsurl = "http://ec2-3-94-113-35.compute-1.amazonaws.com/";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(awsurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var categoryJson = JsonConvert.SerializeObject(category);
                    var content = new StringContent(categoryJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage Res = await client.PutAsync($"api/bikecategory/{id}", content);

                    if (Res.IsSuccessStatusCode)
                    {
                        // Category updated successfully, you can redirect to the "Index" action.
                        return RedirectToAction("Index");
                    }
                }

                // If something went wrong with the request, handle the error here.
                return View(category);
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            string awsurl = "http://ec2-3-94-113-35.compute-1.amazonaws.com/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(awsurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"api/bikecategory/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var responseContent = await Res.Content.ReadAsStringAsync();
                    var category = JsonConvert.DeserializeObject<BikeCategory>(responseContent);
                    return View(category);
                }
            }

            // Handle the case when the category with the specified ID is not found or an error occurs.
            return HttpNotFound();
        }
    }
}
