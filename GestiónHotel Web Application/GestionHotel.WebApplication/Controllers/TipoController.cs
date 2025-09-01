
using GestionHotel.WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionHotel.WebApplication.Controllers
{
    public class TipoController : Controller
    {

        HttpClient cliente = new HttpClient();

        public TipoController()
        {
            cliente.BaseAddress = new Uri("https://localhost:7040/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: TipoController
        public ActionResult Index()
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
                return View(tipos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // GET: TipoController/Details/5
        public ActionResult Details(string nombre)
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
;

            try
            {
                if (System.String.IsNullOrEmpty(nombre))
                    throw new Exception("El nombre no puede ser vacío");

                Uri uri = new Uri(cliente.BaseAddress + "Tipo/" + nombre);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);


                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    TipoModel? tipoDetalle = JsonConvert.DeserializeObject<TipoModel>(response.Result);

                    return View(tipoDetalle);
                }

                string? mensaje = JsonConvert.DeserializeObject<string>(response.Result);
                throw new Exception(mensaje);

            }
            catch (Exception e)
            {
                ViewBag.NombreError = e.Message;
                return View();
            }
        }
        
        // GET: TipoController/Create
        public ActionResult Create()
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            return View();
        }

        // POST: TipoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoModel tipo)
        {
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {
                Uri uri = new Uri(cliente.BaseAddress + "Tipo/");
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Post, uri);

                string json = JsonConvert.SerializeObject(tipo);
                HttpContent contenido = new StringContent(json, Encoding.UTF8, "application/json");
                solicitud.Content = contenido;

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    TipoModel? tipoResult = JsonConvert.DeserializeObject<TipoModel>(response.Result);

                    return RedirectToAction(nameof(Index));
                }

                string? mensaje = JsonConvert.DeserializeObject<string>(response.Result);
                throw new Exception(mensaje);

            }
            catch (Exception e)
            {
                ViewBag.NombreError = e.Message.ToString();
                return View();
            }
        }


        // GET: TipoController/Edit/5
        public ActionResult Edit(string nombre)
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {

                Uri uri = new Uri(cliente.BaseAddress + "Tipo/" + nombre);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);


                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                TipoModel? aEditar = JsonConvert.DeserializeObject<TipoModel>(response.Result);
                return View(aEditar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // POST: TipoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string nombre, IFormCollection collection, TipoModel tipo)
        {
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {
                Uri uri = new Uri(cliente.BaseAddress + "Tipo/" + nombre);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Put, uri);

                string json = JsonConvert.SerializeObject(tipo);
                HttpContent contenido = new StringContent(json, Encoding.UTF8, "application/json");
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

        // GET: TipoController/Delete/5
        public ActionResult Delete(string nombre)
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {

                Uri uri = new Uri(cliente.BaseAddress + "Tipo/" + nombre);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                TipoModel? aEliminar = JsonConvert.DeserializeObject<TipoModel>(response.Result);
                return View(aEliminar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // POST: TipoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string nombre, IFormCollection collection)
        {
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            try
            {
                Uri uri = new Uri(cliente.BaseAddress + "Tipo/" + nombre);
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

    }
}
