using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.DTOs;

namespace ToDoApp.Validators
{
    public class CreateTaskDTOValidator : AbstractValidator<CreateTaskDTO>
    {
        public CreateTaskDTOValidator()
        {

            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("Potrebno je unjeti naziv zadatka!");

            RuleFor(t => t.Text)
                .NotEmpty().WithMessage("Potrebno je unjeti opis zadatka!");
        
        }

    }
}
