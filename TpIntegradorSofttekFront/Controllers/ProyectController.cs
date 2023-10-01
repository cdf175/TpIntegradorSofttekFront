using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TpIntegradorSofttekFront.ViewModels;

namespace TpIntegradorSofttekFront.Controllers
{
    [Authorize]
    public class ProyectController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public ProyectController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult index()
        {
            return View();
        }
        public async Task<IActionResult> ProyectAddPartial([FromBody] ProyectDto proyect)
        {
            var proyectViewModel = new ProyectViewModel();
            if (proyect != null)
            {
                proyectViewModel = proyect;
            }

            return PartialView("~/Views/Proyect/Partial/ProyectAddPartial.cshtml", proyectViewModel);
        }

        public IActionResult SaveProyect(ProyectDto proyect)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            if (proyect.Id == 0)
            {
                var proyects = baseApi.PostToApi("proyect/create", proyect, token);
            }
            else
            {
                var proyects = baseApi.PutToApi("proyect/update/" + proyect.Id, proyect, token);
            }


            return View("~/Views/Proyect/Index.cshtml");
        }

        public async Task<IActionResult> ProyectDeletePartial([FromBody] ProyectDto proyect)
        {
            var proyectViewModel = new ProyectViewModel();
            if (proyect != null)
            {
                proyectViewModel = proyect;
            }

            return PartialView("~/Views/Proyect/Partial/ProyectDeletePartial.cshtml", proyectViewModel);
        }
        public IActionResult DeleteProyect(ProyectDto proyect)
        {

            if (proyect != null)
            {
                var token = HttpContext.Session.GetString("Token");
                var baseApi = new BaseApi(_httpClient);
                var proyects = baseApi.DeleteToApi("proyect/delete/" + proyect.Id, token);
            }

            return View("~/Views/Proyect/Index.cshtml");

        }

    }
}
