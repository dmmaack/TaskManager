using System.ComponentModel;

namespace TaskManager.Core.Enums;

public enum StatusEnum : int
{
    [Description("Pendente")]
    Pending = 1,
    [Description("Em Progresso")]
    InProgress = 2,
    [Description("Concluído")]
    Concluded = 3,
}