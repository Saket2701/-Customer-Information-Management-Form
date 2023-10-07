using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

using WebApplication1.Models;

using WebAPI;

using Newtonsoft.Json;

namespace WebApplication1.Controllers

{
    public class HomeController : Controller

    {
        string BaseURL = "http://localhost:52452/";

        public async Task<IActionResult> GetAllProducts()

        {

            List<WebAPI.Customer> Customers = new List<WebAPI.Customer>();

            using (var client = new HttpClient())

            {

                client.BaseAddress = new Uri(BaseURL);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Customers");

                if (Res.IsSuccessStatusCode)

                {

                    var Result = Res.Content.ReadAsStringAsync().Result;

                    Customers = JsonConvert.DeserializeObject<List<Customer>>(Result);



                }

            }

            return View(Customers);

        }



        [HttpGet]

        public async Task<IActionResult> GetProduct(int id)

        {

            Customer Custo = new Customer();

            List<WebAPI.Customer> Customers = new List<WebAPI.Customer>();

            using (var client = new HttpClient())

            {

                client.BaseAddress = new Uri(BaseURL);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Customers/" + id);

                if (Res.IsSuccessStatusCode)

                {

                    var Result = Res.Content.ReadAsStringAsync().Result;

                    Custo = JsonConvert.DeserializeObject<Customer>(Result);



                }

            }

            return View(Custo);

        }



        public async Task<IActionResult> AddProduct()

        {

            return View();

        }



        [HttpPost]

        public async Task<IActionResult> AddProduct(Customer pr)

        {

            using (var client = new HttpClient())

            {

                client.BaseAddress = new Uri(BaseURL);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = client.PostAsJsonAsync(BaseURL + "api/Customers", pr).Result;

                if (Res.IsSuccessStatusCode)

                {

                    ViewBag.msg = "Submitted Succesfully";

                    ModelState.Clear();

                }

                else

                {

                    ViewBag.msg = "Oops.....Something Went Wrong";



                }

            }

            return View();

        }



        [HttpGet]

        public async Task<IActionResult> UpdateProduct(int id)

        {

            Customer Custo = new Customer();

            List<WebAPI.Customer> Customers = new List<WebAPI.Customer>();

            using (var client = new HttpClient())

            {

                client.BaseAddress = new Uri(BaseURL);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Customers/" + id);

                if (Res.IsSuccessStatusCode)

                {

                    var Result = Res.Content.ReadAsStringAsync().Result;

                    Custo = JsonConvert.DeserializeObject<Customer>(Result);



                }

            }

            return View(Custo);

        }



        [HttpPost]

        public IActionResult UpdateProduct(Customer custo)

        {

            using (var client = new HttpClient())

            {

                client.BaseAddress = new Uri(BaseURL);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = client.PutAsJsonAsync(BaseURL + "api/Customers/" + custo.Customer_ID, custo).Result;

                if (Res.IsSuccessStatusCode)

                {

                    ViewBag.msg = "Updated Succesfully";

                    ModelState.Clear();

                }

                else

                {

                    ViewBag.msg = "Oops.....Something Went Wrong";



                }

            }

            return View();

        }



        [HttpGet]

        public async Task<IActionResult> DeleteProduct(int id)

        {

            Customer Custo = new Customer();

            List<WebAPI.Customer> Customers = new List<WebAPI.Customer>();

            using (var client = new HttpClient())

            {

                client.BaseAddress = new Uri(BaseURL);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Customers/" + id);

                if (Res.IsSuccessStatusCode)

                {

                    var Result = Res.Content.ReadAsStringAsync().Result;

                    Custo = JsonConvert.DeserializeObject<Customer>(Result);



                }

            }

            return View(Custo);







        }



        [HttpPost]

        public IActionResult DeleteProduct(Customer custo)

        {

            using (var client = new HttpClient())

            {

                client.BaseAddress = new Uri(BaseURL);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = client.DeleteAsync(BaseURL + "api/Customers/" + custo.Customer_ID).Result;

                if (Res.IsSuccessStatusCode)

                {

                    ViewBag.msg = "Deleted Succesfully";

                    ModelState.Clear();

                }

                else

                {

                    ViewBag.msg = "Oops.....Something Went Wrong";



                }

            }

            return View();



        }

        private readonly ILogger<HomeController> _logger;



        public HomeController(ILogger<HomeController> logger)

        {

            _logger = logger;

        }



        public IActionResult Index()

        {

            return View();

        }



        public IActionResult Privacy()

        {

            return View();

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()

        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }

    }

}