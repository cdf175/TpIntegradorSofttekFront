﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Data.Base
{
	public class BaseApi:ControllerBase
	{
		private readonly IHttpClientFactory _httpClient;

		public BaseApi(IHttpClientFactory httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IActionResult> GetToApi(string controllerName, string token = "")
		{
			try { 
				var client = _httpClient.CreateClient("userApi");

				if(token != "")
				{
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",token);
				}

				var response = await client.GetAsync(controllerName);

				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					return Ok(content);
				}
			
				return Unauthorized();
			}catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

        public async Task<IActionResult> PostToApi(string controllerName, object model, string token = "")
        {
            try
            {
                var client = _httpClient.CreateClient("userApi");

                if (token != "")
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                }

                var response = await client.PostAsJsonAsync(controllerName, model);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public async Task<IActionResult> PutToApi(string controllerName, object model, string token = "")
        {
            try
            {
                var client = _httpClient.CreateClient("userApi");

                if (token != "")
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                }

                var response = await client.PutAsJsonAsync(controllerName, model);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public async Task<IActionResult> DeleteToApi(string controllerName, string token = "")
        {
            try
            {
                var client = _httpClient.CreateClient("userApi");

                if (token != "")
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                }

                var response = await client.DeleteAsync(controllerName);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
