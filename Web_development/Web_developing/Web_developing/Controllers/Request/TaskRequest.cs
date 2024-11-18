namespace Web_developing.Controllers.Request
{
    public record TaskRequest
    (
        DateTime DateCreate,
        DateTime DateFinish,
        string Description,
        Guid idDiscipline,
        Guid idGroup,
        Guid idTeacher
        );
}
