using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TpIntegradorSofttekFront.ViewModels;

namespace TpIntegradorSofttekFront.Controllers
{
    [Authorize]
    public class WorkController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public WorkController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult index()
        {
            return View();
        }

        public async Task<IActionResult> WorkAddPartial([FromBody] WorkDto work)
        {
            var workViewModel = new WorkViewModel();
            if (work != null)
            {
                workViewModel = work;
            }

            return PartialView("~/Views/Work/Partial/WorkAddPartial.cshtml", workViewModel);
        }

        public IActionResult SaveWork(WorkDto work)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            if (work.Id == 0)
            {
                var works = baseApi.PostToApi("work/create", work, token);
            }
            else
            {
                var works = baseApi.PutToApi("work/update/" + work.Id, work, token);
            }


            return View("~/Views/Work/Index.cshtml");
        }

        public async Task<IActionResult> WorkDeletePartial([FromBody] WorkDto work)
        {
            var workViewModel = new WorkViewModel();
            if (work != null)
            {
                workViewModel = work;
            }

            return PartialView("~/Views/Work/Partial/WorkDeletePartial.cshtml", workViewModel);
        }
        public IActionResult DeleteWork(WorkDto work)
        {

            if (work != null)
            {
                var token = HttpContext.Session.GetString("Token");
                var baseApi = new BaseApi(_httpClient);
                var works = baseApi.DeleteToApi("work/delete/" + work.Id, token);
            }

            return View("~/Views/Work/Index.cshtml");

        }

    }
}
