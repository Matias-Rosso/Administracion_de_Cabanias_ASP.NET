using GestionHotel.WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionHotel.WebApplication.Controllers
{
    public class UsuarioController : Controller
    {

        HttpClient cliente = new HttpClient();

        public UsuarioController()
        {
            cliente.BaseAddress = new Uri("https://localhost:7040/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            if (System.String.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
                return RedirectToAction("Login", "Usuario");

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            //------------------------------

                Uri uriTipos = new Uri(cliente.BaseAddress + "Tipo/");
                HttpRequestMessage solicitudTipos = new HttpRequestMessage(HttpMethod.Get, uriTipos);


                Task<HttpResponseMessage> respuestaTipos = cliente.SendAsync(solicitudTipos);
                respuestaTipos.Wait();
                Task<string> responseTipos = respuestaTipos.Result.Content.ReadAsStringAsync();

                TipoModel[]? tipos = JsonConvert.DeserializeObject<TipoModel[]>(responseTipos.Result);

                ViewBag.Tipos = tipos;
                //---------------

                Uri uriCabanias = new Uri(cliente.BaseAddress + "Cabania/");
                HttpRequestMessage solicitudCabanias = new HttpRequestMessage(HttpMethod.Get, uriCabanias);


                Task<HttpResponseMessage> respuestaCabanias = cliente.SendAsync(solicitudCabanias);
                respuestaCabanias.Wait();
                Task<string> responseCabanias = respuestaCabanias.Result.Content.ReadAsStringAsync();

                CabaniaModel[]? cabanias = JsonConvert.DeserializeObject<CabaniaModel[]>(responseCabanias.Result);

                ViewBag.Cabanias = cabanias;
            //------------------------------

            return View();
        }

        public IActionResult Login()
        {
            HttpContext.Session.Remove("UsuarioLogueado");
            HttpContext.Session.Remove("Token");

            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioModel usuario)
        {
            try
            {

                Uri uri = new Uri(cliente.BaseAddress + "Login/");
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Post, uri);

                string json = JsonConvert.SerializeObject(usuario);
                HttpContent contenido = new StringContent(json, Encoding.UTF8, "application/json");
                solicitud.Content = contenido;

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    UsuarioModel? usuarioResult = JsonConvert.DeserializeObject<UsuarioModel>(response.Result);

                    HttpContext.Session.SetString("UsuarioLogueado", usuarioResult.Email);
                    HttpContext.Session.SetString("Token", usuarioResult.Token);

                    return RedirectToAction(nameof(Index));
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

        /*
        // GET: UsuarioController/ListarUsuarios
        public ActionResult ListarUsuarios()
        {
            return View(repositorio.GetAll());
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                repositorio.Add(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioException e)
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

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
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

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario aEliminar = repositorio.GetById(id);
            return View(aEliminar);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Usuario aEliminar = repositorio.GetById(id);
                repositorio.Delete(aEliminar);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
