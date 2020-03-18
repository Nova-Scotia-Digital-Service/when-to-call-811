using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineAssessment.Models;
using OnlineAssessment.Utils;
using OnlineAssessment.Resources;
using Microsoft.AspNetCore.Localization;

namespace OnlineAssessment.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class HomeController : Controller
    {
        private string _currentLanguage;
        private string DEFAULT_TITLE = StringResource.Index_PageTitle;

        //Get requested language
        private string CurrentLanguage
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentLanguage))
                {
                    return _currentLanguage;
                }

                if (string.IsNullOrEmpty(_currentLanguage))
                {
                    var feature = HttpContext.Features.Get<IRequestCultureFeature>();
                    var requestedLang = HttpContext.Request.Path.Value.Split('/')[1]?.ToString();
                    if (!string.IsNullOrWhiteSpace(requestedLang) && requestedLang.Equals(feature.RequestCulture.Culture.TwoLetterISOLanguageName.ToLower(), StringComparison.InvariantCultureIgnoreCase))
                        _currentLanguage = feature.RequestCulture.Culture.TwoLetterISOLanguageName.ToLower();
                    else
                        _currentLanguage = requestedLang;
                }

                return _currentLanguage;
            }
        }

        #region IActionResult

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TravelInfo()
        {
            ViewBag.Title = FormatPageTitle(StringResource.TravelInfo_PageTitle);
            return View();
        }

        public IActionResult SymptomsWithTravel()
        {
            ViewBag.Title = FormatPageTitle(StringResource.Symptoms_PageTitle);
            return View();
        }

        public IActionResult SymptomsWithoutTravel()
        {
            ViewBag.Title = FormatPageTitle(StringResource.Symptoms_PageTitle);
            return View();
        }

        public IActionResult ContactWithConfirmedCase()
        {
            ViewBag.Title = FormatPageTitle(StringResource.ContactWithConfirmedCase_PageTitle);
            return View();
        }
        public IActionResult ContactWithSymptoms()
        {
            ViewBag.Title = FormatPageTitle(StringResource.ContactWithSymptoms_PageTitle);
            return View();
        }

        public IActionResult NoCallTo811()
        {
            ViewBag.Title = FormatPageTitle(StringResource.NoCallTo811_PageTitle);
            return View();
        }

        public IActionResult NoCallRightNow()
        {
            ViewBag.Title = FormatPageTitle(StringResource.NoCallRightNow_PageTitle);
            return View();
        }

        public IActionResult Call811()
        {
            ViewBag.Title = FormatPageTitle(StringResource.Call811_PageTitle);
            return View();
        }


        public IActionResult RedirectToDefaultLanguage()
        {
            var lang = CurrentLanguage;
            if (string.IsNullOrWhiteSpace(lang))
                lang = "en";

            return RedirectToAction("Index", new { lang });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion IActionResult

        #region private methods

        /// <summary>
        /// Format title on each page
        /// </summary>
        /// <param name="currentPageTitle"></param>
        /// <returns></returns>
        private string FormatPageTitle(string currentPageTitle)
        {
            string title = string.Format("{0} - {1}", currentPageTitle, DEFAULT_TITLE);
            return title;
        }
        #endregion private method
    }
}
