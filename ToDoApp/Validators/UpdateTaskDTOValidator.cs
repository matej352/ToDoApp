using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Validators
{
    public class UpdateTaskDTOValidator : AbstractValidator<UpdateTaskDTO>
    {
        public UpdateTaskDTOValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("Potrebno je unjeti naziv zadatka!");

            RuleFor(t => t.Text)
                .NotEmpty().WithMessage("Potrebno je unjeti opis zadatka!");

            RuleFor(t => t.MarkAsDone)
                .Equals(true || false);

            RuleFor(t => t.Id)
                .NotEmpty().WithMessage("Id zadatka mora biti poslan!");


        }
    }
}
