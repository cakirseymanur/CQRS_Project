using CQRS_Project.CQRS.Commands.StudentCommands;
using CQRS_Project.CQRS.Handlers.StudentHandlers;
using CQRS_Project.CQRS.Queries.StudentQueries;
using CQRS_Project.CQRS.Results.StudentResuls;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Project.Controllers
{
    public class StudentController : Controller
    {
        private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        private readonly GetAllStudentQueryHandler _getAllStudentQueryHandler;
        private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        private readonly GetStudentByIDQueryHandler _getStudentByIDQueryHandler;
        private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;

        public StudentController(CreateStudentCommandHandler createStudentCommandHandler, GetAllStudentQueryHandler getAllStudentQueryHandler, RemoveStudentCommandHandler removeStudentCommandHandler, UpdateStudentCommandHandler updateStudentCommandHandler, GetStudentByIDQueryHandler getStudentByIDQueryHandler)
        {
            _createStudentCommandHandler = createStudentCommandHandler;
            _getAllStudentQueryHandler = getAllStudentQueryHandler;
            _removeStudentCommandHandler = removeStudentCommandHandler;
            _updateStudentCommandHandler = updateStudentCommandHandler;
            _getStudentByIDQueryHandler = getStudentByIDQueryHandler;
        }
        public IActionResult Index()
        {
            var values = _getAllStudentQueryHandler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(CreateStudentCommands command)
        {
            _createStudentCommandHandler.Handle(command);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteStudent(int id)
        {
            _removeStudentCommandHandler.Handle(new RemoveStudentCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            var values=_getStudentByIDQueryHandler.Handle(new GetStudentByIDQuery(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult AddStudent(UpdateStudentCommand command)
        {
            _updateStudentCommandHandler.Handle(command);

            return RedirectToAction("Index");
        }
    }
}
