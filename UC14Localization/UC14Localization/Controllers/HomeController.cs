using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Globalization;
using UC14Localization.Models;

namespace UC14Localization.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;


        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var model = new ViewModel
            {
                Dates = GetFormattedDateTimes(),
                Numbers = GetFormatedNumbers(),
                Units = GetFormatedUnitsOfMeasurement(),
                Greeting = _localizer["Greeting"],
                DatesDescription = _localizer["DatesDescription"],
                NumbersDescription = _localizer["NumbersDescription"],
                UnitsDescription = _localizer["UnitsDescription"]
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static List<string> GetFormattedDateTimes()
        {
            var currentCulture = CultureInfo.CurrentCulture;
            return new List<string>
            {
                DateTime.Now.ToString("MM/dd/yyyy", currentCulture.DateTimeFormat),
                DateTime.Now.ToString("dddd, dd MMMM yyyy", currentCulture.DateTimeFormat),
                DateTime.Now.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT", currentCulture.DateTimeFormat),
                DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:s", currentCulture.DateTimeFormat),

            };

        }

        private static List<string> GetFormatedNumbers()
        {
            var random = new Random();

            return new List<string>
            {
            string.Format(CultureInfo.CurrentCulture, "{0:C}", random.NextDouble()*5),
            string.Format(CultureInfo.CurrentCulture, "{0:C0}", random.NextDouble()*1000),
            string.Format(CultureInfo.CurrentCulture, "{0:C1}", random.NextDouble()*10000),
            string.Format(CultureInfo.CurrentCulture, "{0:C2}", random.NextDouble()*1000000)
            };

        }

        private List<string> GetFormatedUnitsOfMeasurement()
        {
            var random = new Random();

            return new List<string>
            {
            string.Format(CultureInfo.CurrentCulture, "{0:f}", random.NextDouble()*10) + $" {_localizer["WeightMeasurement"]}" ,
            string.Format(CultureInfo.CurrentCulture, "{0:f1}", random.NextDouble()*100) + $" {_localizer["HeightMeasurment"]}",
            string.Format(CultureInfo.CurrentCulture, "{0:f2}", random.NextDouble()*1000) + $" {_localizer["VolumeMeasurment"]}",
            };

        }
    }
}