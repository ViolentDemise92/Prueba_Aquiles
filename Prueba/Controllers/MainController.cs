using System;
using Microsoft.AspNetCore.Mvc;
using Prueba.Management;

namespace Prueba.Controllers
{
    [Route("api/home")]
    public class MainController : Controller
    {
		[HttpGet, Route("GetCombo")]
		public ActionResult GetCombo(string cadena)
		{
			try
			{
				string result = ComboManager.CombinationLength(cadena);
				return Content(result);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet, Route("GetOrdenacion")]
		public ActionResult GetOrdenacion(string cadena)
		{
			try
			{
				string result = OrdenacionManager.OrdenacionPedido(cadena);
				return Content(result);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}
