using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Feauters.Clientes.Commands.CreateClienteCommand
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(p => p.Apellido)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(p => p.FechaNacimiento)
                .NotEmpty().WithMessage("Fecha de Nacimiento no puede estar vacia.");
            RuleFor(p => p.Telefono)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .Matches(@"^\d{4}-\d{4}$").WithMessage("{PropertyName} debe cumplir el formato 0000-0000")
                .MaximumLength(9).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(p => p.Dui)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .Matches(@"^\d{8}-\d{1}$").WithMessage("{PropertyName} debe cumplir el formato 00000000-0")
                .MaximumLength(10).WithMessage("{ PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(p => p.Nit)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .Matches(@"^\d{4}-\d{6}-\d{3}-\d{1}$").WithMessage("{PropertyName} debe cumplir el formato 0000-000000-000-0")
                .MaximumLength(17).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .EmailAddress().WithMessage("{PropertyName} debe ser una direccion de email valida")
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(p => p.Direccion)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres"); 

        }
    }
}
