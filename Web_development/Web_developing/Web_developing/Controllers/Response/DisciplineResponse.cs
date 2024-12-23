namespace Web_developing.Controllers.Response
{
    public record DisciplineResponse
    (
        Guid id,
        string Name,
        Guid idTeacher,
        List<string> Groups);
}
