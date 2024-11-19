namespace Web_developing.Controllers.Response
{
    public record TaskResponse
    (
        Guid id,
        DateTime DareCreate,
        DateTime DateFinish,
        string Description,
        Guid idDiscipline,
        Guid idGroup,
        Guid idTeacher);
}
