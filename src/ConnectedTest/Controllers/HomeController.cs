using Microsoft.AspNet.Mvc;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using Kestrel;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ConnectedTest.Controllers
{
	public class HomeController : Controller
	{
		// GET: /<controller>/

		public static UsbDevice MyUsbDevice;

		#region SET YOUR USB Vendor and Product ID!

		public static UsbDeviceFinder MyUsbFinder =
			new UsbDeviceFinder(0x093A, 0x2700);
		#endregion
		[HttpGet("/")]
		public IActionResult Index()
		{
			MyUsbDevice = UsbDevice.OpenUsbDevice(MyUsbFinder);
			string response;
			// If the device is open and ready
			if (MyUsbDevice == null)
				response = "Device Not Found.";
			else
				response = "Device found";
			var final = response + MyUsbDevice;
			Models.TestModel tm = new Models.TestModel();
			tm.Title = response;
			tm.Content = final;





			
			return View(tm);
			//return new ObjectResult(response + MyUsbDevice);
		} 
		
		

		//[HttpGet("/")]
       // public IActionResult Index()
       // {

			//something();

       //     return View();
       // }
    }
}
