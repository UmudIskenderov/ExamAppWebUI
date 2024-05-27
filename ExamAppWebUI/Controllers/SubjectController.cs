using ExamAppWebUI.Models.Implementations;
using ExamAppWebUI.Services.Interfaces;
using ExamAppWebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExamAppWebUI.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var subjectModels = _subjectService.GetAll();

            var subjectViewModel = new SubjectViewModel();

            subjectViewModel.Subjects = subjectModels;

            return View(subjectViewModel);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            if (id != 0)
            {
                var subjectModel = _subjectService.GetById(id);

                if (subjectModel == null)
                    return NotFound("Subject not found");

                return View(subjectModel);
            }
            else
            {
                SubjectModel subjectModel = new SubjectModel();
                return View(subjectModel);
            }
        }

        [HttpPost]
        public IActionResult Save(SubjectModel subjectModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(subjectModel);
            }

            int id = _subjectService.Save(subjectModel);

            return RedirectToAction("Get");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var subject = _subjectService.GetById(id);
            var success = false;
            if (subject != null)
                success = _subjectService.Delete(subject);

            if (success)
                return Ok();

            return BadRequest();
        }
    }
}
