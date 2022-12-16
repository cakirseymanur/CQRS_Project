using CQRS_Project.CQRS.Commands.StudentCommands;
using CQRS_Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Project.CQRS.Handlers.StudentHandlers
{
    public class RemoveStudentCommandHandler
    {
        private readonly ProductContext _context;

        public RemoveStudentCommandHandler(ProductContext context)
        {
            _context = context;
        }

        public void Handle(RemoveStudentCommand command)
        {
            var values = _context.Students.Find(command.Id);
            _context.Students.Remove(values);
            _context.SaveChanges();
        }
    }
}
