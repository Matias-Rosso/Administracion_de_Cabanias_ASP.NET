using GestionHotel.WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionHotel.WebApplication.Controllers
{
    public class CabaniaController : Controller
    {

        HttpClient cliente = new HttpClient();

        public CabaniaController()
        {
            cliente.BaseAddress = new Uri("https://localhost:7040/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: CabaniaController
        public ActionResult Index()
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {

                Uri uri = new Uri(cliente.BaseAddress + "Cabania/");
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);


                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                CabaniaModel[]? cabanias = JsonConvert.DeserializeObject<CabaniaModel[]>(response.Result);
                return View(cabanias);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }

        }

        
        // GET: CabaniaController/ListarHabilitadas
        public ActionResult ListarHabilitadas()
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {

                Uri uri = new Uri(cliente.BaseAddress + "Cabania/CabaniasHabilitadas");
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);


                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                CabaniaModel[]? cabaniasHabilitadas = JsonConvert.DeserializeObject<CabaniaModel[]>(response.Result);
                return View(cabaniasHabilitadas);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }

        }
        // GET: CabaniaController/BuscarPorNombre
        public ActionResult BuscarPorNombre(string nombre)
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {

                Uri uri = new Uri(cliente.BaseAddress + "Cabania/PorNombre/" + nombre);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);


                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                CabaniaModel[]? cabaniasPorNombre = JsonConvert.DeserializeObject<CabaniaModel[]>(response.Result);
                return View(cabaniasPorNombre);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // GET: CabaniaController/BuscarPorTipo
        public ActionResult BuscarPorTipo(string nombreTipo)
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {

                Uri uri = new Uri(cliente.BaseAddress + "Cabania/PorTipo/" + nombreTipo);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);


                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                CabaniaModel[]? cabaniasPorTipo = JsonConvert.DeserializeObject<CabaniaModel[]>(response.Result);

                ViewBag.Tipo = nombreTipo;
                return View(cabaniasPorTipo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // GET: CabaniaController/BuscarPorCupos
        public ActionResult BuscarPorCupos(int cupos)
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {

                Uri uri = new Uri(cliente.BaseAddress + "Cabania/PorCupos/" + cupos.ToString());
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);


                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                CabaniaModel[]? cabaniasPorCupos = JsonConvert.DeserializeObject<CabaniaModel[]>(response.Result);

                ViewBag.Cupos = cupos;
                return View(cabaniasPorCupos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // GET: CabaniaController/Details/5
        public ActionResult Details(string nombre)
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {

                Uri uri = new Uri(cliente.BaseAddress + "Cabania/" + nombre);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);


                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                CabaniaModel? cabaniaDetalle = JsonConvert.DeserializeObject<CabaniaModel>(response.Result);
                return View(cabaniaDetalle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }
        // GET: CabaniaController/Create
        public ActionResult Create()
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {

                Uri uri = new Uri(cliente.BaseAddress + "Tipo/");
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);


                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                TipoModel[]? tipos = JsonConvert.DeserializeObject<TipoModel[]>(response.Result);

                ViewBag.Tipos = tipos;
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // POST: CabaniaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CabaniaModel cabania)
        {
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {
                Uri uri = new Uri(cliente.BaseAddress + "Cabania/");
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Post, uri);

                string json = JsonConvert.SerializeObject(cabania);
                HttpContent contenido = new StringContent(json, Encoding.UTF8, "application/json");
                solicitud.Content = contenido;

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    CabaniaModel? cabaniaResult = JsonConvert.DeserializeObject<CabaniaModel>(response.Result);

                    return RedirectToAction(nameof(Index));
                }

                string? mensaje = JsonConvert.DeserializeObject<string>(response.Result);
                throw new Exception(mensaje);

            }
            catch (Exception e)
            {
                Uri uri = new Uri(cliente.BaseAddress + "Tipo/");
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);


                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                TipoModel[]? tipos = JsonConvert.DeserializeObject<TipoModel[]>(response.Result);

                ViewBag.Tipos = tipos;
                ViewBag.NombreError = e.Message;
                return View();
            }
        }

        // GET: CabaniaController/AgregarMantenimiento
        public ActionResult AgregarMantenimiento(string nombreCabania)
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {
                return RedirectToAction("Create", "Mantenimiento", new { nombreCabania });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }
        // GET: CabaniaController/Delete/5
        public ActionResult Delete(string nombre)
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {

                Uri uri = new Uri(cliente.BaseAddress + "Cabania/" + nombre);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);


                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                CabaniaModel? aEliminar = JsonConvert.DeserializeObject<CabaniaModel>(response.Result);
                return View(aEliminar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // POST: CabaniaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string nombre, IFormCollection collection)
        {
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {
                Uri uri = new Uri(cliente.BaseAddress + "Cabania/" + nombre);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Delete, uri);


                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }
        /*
        // GET: CabaniaController/Edit/5
        public ActionResult Edit(string nombre)
        {
            try
            {

                Uri uri = new Uri(cliente.BaseAddress + "Cabania/" + nombre);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);


                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                CabaniaModel aEditar = JsonConvert.DeserializeObject<CabaniaModel>(response.Result);

                return View(aEditar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
            //return View();
        }
        // POST: CabaniaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(string nombre, IFormCollection collection)
        public ActionResult Edit(CabaniaModel cabania, IFormCollection collection)
        {
            try
            {
                Uri uri = new Uri(cliente.BaseAddress + "Cabania/" + cabania.Nombre);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Put, uri);

                string json = JsonConvert.SerializeObject(cabania);
                HttpContent contenido =
                new StringContent(json, Encoding.UTF8, "application/json");
                solicitud.Content = contenido;

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
