using ExamAppWebUI.Models.Implementations;
using ExamAppWebUI.Services.Interfaces;
using ExamAppWebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExamAppWebUI.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var examModels = _examService.GetAll();

            var examViewModel = new ExamViewModel();

            examViewModel.Exams = examModels;

            return View(examViewModel);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            if (id != 0)
            {
                var examModel = _examService.GetById(id);

                if (examModel == null)
                    return NotFound("Exam not found");

                return View(examModel);
            }
            else
            {
                ExamModel examModel = new ExamModel();
                return View(examModel);
            }
        }

        [HttpPost]
        public IActionResult Save(ExamModel examModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(examModel);
            }

            int id = _examService.Save(examModel);

            return RedirectToAction("Get");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var exam = _examService.GetById(id);
            var success = false;
            if (exam != null)
                success = _examService.Delete(exam);

            if (success)
                return Ok();

            return BadRequest();
        }
    }
}
