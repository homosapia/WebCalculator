using Microsoft.AspNetCore.Mvc;
using WebCalculator.Interfaces;

namespace WebCalculator.Controllers
{
    public class OperationController : Controller
    {
        private readonly IOperator _operator;
        public OperationController(IOperator @operator) 
        {
            _operator = @operator;
        }

        [HttpGet]
        [Route("listOperation")]
        public IActionResult GetListOperation()
        {
            return PartialView("ListOperation", _operator.GetModelsToView());
        }

        [HttpGet]
        [Route("switch")]
        public void СhangeStatus(string operatorType)
        {
            if (string.IsNullOrEmpty(operatorType))
                return;

            _operator.ToggleStatus(operatorType);
        }
    }
}
