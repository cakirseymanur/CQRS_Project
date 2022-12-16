using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Project.CQRS.Commands.StudentCommands
{
    public class RemoveStudentCommand
    {
        public RemoveStudentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
