using FluentValidation;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Validators;

public class ProjectEntityValodator : AbstractValidator<ProjectEntity>
{
    public ProjectEntityValodator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage($"A Entidade {nameof(ProjectEntity)} não pode ser vazia.")
            .NotNull().WithMessage($"A Entidade {nameof(ProjectEntity)} não pode ser Nula.")
            .WithName(nameof(ProjectEntity));

        RuleFor(x => x.ProjectName)
            .NotNull().WithMessage("O Nome do Projeto não pode ser nulo.")
            .NotEmpty().WithMessage("O Nome do Projeto não pode ser vazio.")
            .MinimumLength(10).WithMessage("O Nome do Projeto deve conter no mínimo 10 caracteres.")
            .MaximumLength(150).WithMessage("O Nome do Projeto deve conter no máximo 150 caracteres.")
            .WithName(nameof(ProjectEntity.ProjectName));

        RuleFor(x => x.RegisterDate)
            .NotNull().WithMessage("A Data de Registro não pode ser nula.")
            .NotEmpty().WithMessage("A Data de Registro não pode ser vazia.")
            .WithName(nameof(ProjectEntity.RegisterDate));
            
        RuleFor(x => x.StartDate)
            .NotNull().WithMessage("O Projeto não pode ter uma Data Inicial nula.")
            .NotEmpty().WithMessage("O Projeto deve ter uma Data Inicial.")
            .WithName(nameof(ProjectEntity.RegisterDate));

        RuleFor(x => x.EndDate)
            .NotNull().WithMessage("O Projeto não pode ter uma Data Final nula.")
            .NotEmpty().WithMessage("O Projeto deve ter uma Data Final.")
            .WithName(nameof(ProjectEntity.RegisterDate));

        RuleFor(x => x.IsActive)
            .NotNull().WithMessage("O Projeto deve ter um estado Ativo ou Inativo.")
            .NotEmpty().WithMessage("O Projeto deve estar Ativo ou Inativo.")
            .WithName(nameof(ProjectEntity.IsActive));
    }
}