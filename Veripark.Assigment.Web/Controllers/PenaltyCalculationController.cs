using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Veripark.Assigment.Data.Repository.Interfaces;
using Veripark.Assigment.Data.Services.Abstract;
using Veripark.Assigment.Data.ViewModels;

namespace Veripark.Assigment.Web.Controllers
{
    public class PenaltyCalculationController : Controller
    {
        private readonly ILogger<PenaltyCalculationController> _logger;
        private readonly ICountryRepository _countryRepository;
        private readonly IPenaltyCalculationProcessor _penaltyCalculationProcessor;
        public PenaltyCalculationController(ILogger<PenaltyCalculationController> logger, ICountryRepository countryRepository, IPenaltyCalculationProcessor penaltyCalculationProcessor)
        {
            _logger = logger;
            _countryRepository = countryRepository;
            _penaltyCalculationProcessor = penaltyCalculationProcessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            GetDropDownListForCountry();

            ViewBag.ShowResult = false;

            return View();
        }

        [HttpPost]
        public IActionResult Index(PenaltyCalculationViewModel model)
        {
            GetDropDownListForCountry();

            if (ModelState.IsValid)
            {
                var _country = _countryRepository.GetCountryById(model.Country.Id);
                model.Country = _country;

                var item = _penaltyCalculationProcessor.Process(model);

                if (item != null)
                {
                    ViewBag.BusinessDays = item.BusinessDays;
                    ViewBag.Penalty = item.TotalPrice;
                    ViewBag.CurrencySymbol = item.CurrencySymbol;
                    ViewBag.ShowResult = true;
                }
                return View(model);
            }
            return View(model);
        }

        private void GetDropDownListForCountry()
        {
            var _countryList = _countryRepository.AllCountries.ToList();
            ViewBag.countryList = _countryList;
        }

    }
}
