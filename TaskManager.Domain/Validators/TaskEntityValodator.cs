using FluentValidation;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Validators;

public class TaskEntityValodator : AbstractValidator<TaskEntity>
{
    public TaskEntityValodator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage($"A Entidade {nameof(TaskEntity)} não pode ser vazia.")
            .NotNull().WithMessage($"A Entidade {nameof(TaskEntity)} não pode ser Nula.")
            .WithName(nameof(TaskEntity));

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage($"O Título da Tarefa não pode ser vazio.")
            .NotNull().WithMessage($"O Título da Tarefa não pode ser nulo.")
            .MinimumLength(10).MaximumLength(150).WithMessage("O Título das Tarefa deve ter entre 10 e 150 caracteres.")
            .WithName(nameof(TaskEntity.Title));

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage($"A Descrição da Tarefa não pode ser vazia.")
            .NotNull().WithMessage($"A Descrição da Tarefa não pode ser nula.")
            .MinimumLength(3).MaximumLength(5000).WithMessage("A Descrição das Tarefa deve ter entre 3 e 5000 caracteres.")
            .WithName(nameof(TaskEntity.Description));

        RuleFor(x => x.RegisterDate)
            .NotNull().NotEmpty().WithMessage("A Tarefa deve ter uma Data de Registro.")
            .WithName(nameof(TaskEntity.RegisterDate));
        
        RuleFor(x => x.StartDate)
            .NotNull().NotEmpty().WithMessage("A Tarefa deve ter uma Data de Início.")
            .WithName(nameof(TaskEntity.RegisterDate));
        
        RuleFor(x => x.EndDate)
            .NotNull().NotEmpty().WithMessage("A Tarefa deve ter uma Data Final.")
            .WithName(nameof(TaskEntity.RegisterDate));

        RuleFor(x => x.Status)
            .NotNull().NotEmpty().WithMessage("A Tarefa deve ter um Status definido")
            .WithName(nameof(TaskEntity.RegisterDate));

    }
}