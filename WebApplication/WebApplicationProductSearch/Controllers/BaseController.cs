using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using MVCLogic;

namespace WebApplicationProductSearch.Controllers
{
	public class BaseController : Controller
	{
		protected ActionResult SucrssResult ( string message ="operate sucessful!", object data =null)
		{
			return Content (new JsonRes (ResultType.Success, message,data).ToJsonCon());
		}

		protected ActionResult ErrorResult(string message = "operate failure!", object data = null)
		{
			return Content(new JsonRes(ResultType.Error, message, data).ToJsonCon());
		}



	}
	// using ajax request data type 
	public class JsonRes
	{
		public JsonRes(ResultType resultType, string message, object data = null)
		{
			this.resultType = resultType;
			this.message = message;
			this.data = data;
		}
		public object resultType { get; set; }
		public string message { get; set; }
		public object data { get; set; }
	}
	public enum ResultType
	{
		Success =1, Error =2, Err
	}

}

