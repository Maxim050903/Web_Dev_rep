namespace Web_developing.Controllers.Response
{
    public record DisciplineResponse
    (
        Guid id,
        string Name,
        Guid idTeacher,
        Guid idGroup);
}
