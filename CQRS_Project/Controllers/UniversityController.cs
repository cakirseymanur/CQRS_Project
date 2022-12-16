﻿using CQRS_Project.CQRS.Commands.UniversityCommands;
using CQRS_Project.CQRS.Queries.UniversityQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Project.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IMediator _mediator;

        public UniversityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllUniversityQuery());
            return View(values);
        }
        public async Task<IActionResult> UpdateUniversity(int id)
        {
            var values = await _mediator.Send(new GetUniversityByIdQuery(id));
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUniversity(UpdateUniversityCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddUniversity()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUniversity(CreateUniversityCommand createUniversityCommand)
        {
             await _mediator.Send(createUniversityCommand);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteUniversity(int id)
        {
            await _mediator.Send(new RemoveUniversityCommand(id));
            return RedirectToAction("Index");
        }
    }
}
