using Microsoft.AspNetCore.Mvc;
using WebCalculator.Extensions;
using WebCalculator.Interfaces;
using WebCalculator.Models;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExpressionAnalysisService _expressionAnalysisService;
        private readonly IExpressionFactory _expressionFactory;
        public HomeController(IExpressionAnalysisService expressionAnalysisService, IExpressionFactory expressionFactory)
        {
            _expressionAnalysisService = expressionAnalysisService;
            _expressionFactory = expressionFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IndexModel indexModel = new IndexModel();
            return View(indexModel);
        }

        [HttpPost]
        public IActionResult CalculateExpression(IndexModel model)
        {
            //if (!model.IsValid())
            //    return Response(model, "Строка пуста или содержит недопустимые символы.");

            model.Expression = model.Expression.SanitizeInput();

            try
            {
                var components = _expressionAnalysisService.GetComponentsExpressions(model.Expression);
                var sequenceСomponents = _expressionAnalysisService.CreateSequence(components);
                var expression = _expressionFactory.BuildExpressionTree(sequenceСomponents);
                return Response(model, $"Ответ: {expression.Сalculate()}");
            }
            catch(ArgumentException ex)
            {
                return Response(model, ex.Message);
            }
            catch (Exception ex) 
            {
                return Response(model, "Произошла непредвиденная ошибка");
            }
        }

        private IActionResult Response(IndexModel indexModel, string message)
        {
            indexModel.Resultado = message;
            return View("Index", indexModel);
        }
    }
}
