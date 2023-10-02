using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TpIntegradorSofttekFront.Models;
using TpIntegradorSofttekFront.ViewModels;

namespace TpIntegradorSofttekFront.Controllers
{
	[Authorize]
	public class ServiceController : Controller
	{
		private readonly IHttpClientFactory _httpClient;
		public ServiceController(IHttpClientFactory httpClient)
		{
			_httpClient = httpClient;
		}
		public IActionResult index()
		{
			return View();
		}

		public async Task<IActionResult> ServiceAddPartial([FromBody] ServiceDto service)
		{
			var serviceViewModel = new ServiceViewModel();
			if (service != null)
			{
				serviceViewModel = service;
			}

			return PartialView("~/Views/Service/Partial/ServiceAddPartial.cshtml", serviceViewModel);
		}

		public IActionResult SaveService(ServiceDto service)
		{
			var token = HttpContext.Session.GetString("Token");
			var baseApi = new BaseApi(_httpClient);

			if (service.Id == 0)
			{
				var services = baseApi.PostToApi("service/create", service, token);
			}
			else
			{
				var services = baseApi.PutToApi("service/update/" + service.Id, service, token);
			}


			return View("~/Views/Service/Index.cshtml");
		}

		public async Task<IActionResult> ServiceDeletePartial([FromBody] ServiceDto service)
		{
			var serviceViewModel = new ServiceViewModel();
			if (service != null)
			{
				serviceViewModel = service;
			}

			return PartialView("~/Views/Service/Partial/ServiceDeletePartial.cshtml", serviceViewModel);
		}
		public IActionResult DeleteService(ServiceDto service)
		{

			if (service != null)
			{
				var token = HttpContext.Session.GetString("Token");
				var baseApi = new BaseApi(_httpClient);
				var services = baseApi.DeleteToApi("service/delete/" + service.Id, token);
			}

			return View("~/Views/Service/Index.cshtml");

		}

	}
}
