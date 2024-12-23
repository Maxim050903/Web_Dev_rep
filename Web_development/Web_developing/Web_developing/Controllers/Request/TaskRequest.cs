namespace Web_developing.Controllers.Request
{
    public record TaskRequest
    (
        DateTime DateFinish,
        string Description,
        Guid idDiscipline,
        Guid idGroup,
        Guid idTeacher
        );

    public record TaskUpdateRequest(
        DateTime DateFinish,
        string Description
        );
}
