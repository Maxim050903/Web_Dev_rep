namespace Web_developing.Controllers.Response
{
    public record GroupResponse
    (
        Guid id,
        string Name,
        List<Guid> id_Students);
}
