using Microsoft.AspNetCore.Mvc;
using Paycompute.Models;
using Paycompute.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paycompute.Controllers
{
    public class PayController : Controller
    {
        private readonly IPayComputationService _payComputationService;

        public PayController(IPayComputationService payComputationService)
        {
            _payComputationService = payComputationService;
        }

        public IActionResult Index()
        {
            var payRecords = _payComputationService.GetAll().Select(pay => new PaymentRecordIndexViewModel
            {
                Id = pay.Id,
                EmployeeId = pay.EmployeeId,
                Employee = pay.Employee,
                FullName = pay.FullName,
                PayDate = pay.PayDate,
                PayMonth = pay.PayMonth,
                TaxYearId = pay.TaxYearId,
                Year = _payComputationService.GetTaxYearById(pay.TaxYearId).YearOfTax,
                TotalEarnings = pay.TotalEarnings,
                TotalDeduction = pay.TotalDeduction,
                NetPayment = pay.NetPayment
            }) ;
            return View(payRecords);
        }
    }
}
