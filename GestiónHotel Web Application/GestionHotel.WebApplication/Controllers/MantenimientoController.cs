
using GestionHotel.WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionHotel.WebApplication.Controllers
{
    public class MantenimientoController : Controller
    {

        HttpClient cliente = new HttpClient();

        public MantenimientoController()
        {
            cliente.BaseAddress = new Uri("https://localhost:7040/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: MantenimientoController/ListarEntreDosFechas
        public ActionResult ListarEntreDosFechas(string nombreCabania, DateTime fecha1, DateTime fecha2)
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {

                Uri uri = new Uri(cliente.BaseAddress + "Mantenimiento?nombreCabania=" + nombreCabania + "&fecha1=" + fecha1.ToString() + "&fecha2=" + fecha2.ToString());
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);


                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                MantenimientoModel[]? mantenimientos = JsonConvert.DeserializeObject<MantenimientoModel[]>(response.Result);

                ViewBag.nombreCabania = nombreCabania;
                ViewBag.fecha1 = fecha1;
                ViewBag.fecha2 = fecha2;

                return View(mantenimientos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // GET: MantenimientoController/Create
        public ActionResult Create(string nombreCabania)
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            ViewBag.NombreCabania = nombreCabania;
            return View();
        }

        // POST: MantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MantenimientoModel mantenimiento)
        {
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {
                Uri uri = new Uri(cliente.BaseAddress + "Mantenimiento/");
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Post, uri);

                string json = JsonConvert.SerializeObject(mantenimiento);
                HttpContent contenido = new StringContent(json, Encoding.UTF8, "application/json");
                solicitud.Content = contenido;

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    MantenimientoModel? mantenimientoResult = JsonConvert.DeserializeObject<MantenimientoModel>(response.Result);

                    return RedirectToAction("Index", "Cabania");
                }

                string? mensaje = JsonConvert.DeserializeObject<string>(response.Result);
                throw new Exception(mensaje);

            }
            catch (Exception e)
            {
                ViewBag.NombreError = e.Message;
                return Create(mantenimiento.CabaniaNombre);
            }
        }
        /*
        // GET: MantenimientoController
        public ActionResult Index()
        {
            return View(repositorio.GetAll());
        }

        // GET: MantenimientoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MantenimientoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MantenimientoController/Edit/5
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

        // GET: MantenimientoController/Delete/5
        public ActionResult Delete(int id)
        {
            Mantenimiento aEliminar = repositorio.GetById(id);
            return View(aEliminar);
        }

        // POST: MantenimientoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Mantenimiento aEliminar = repositorio.GetById(id);
                repositorio.Delete(aEliminar);
                return RedirectToAction(nameof(Index));
            }
            catch (MantenimientoException e)
            {
                ViewBag.NombreError = e.Message;
                return View();
            }
            catch (Exception e)
            {
                ViewBag.NombreError = e.Message;
                return View();
            }
        }
        */
    }

}
