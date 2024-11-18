namespace Web_developing.Controllers.Request
{
    public record GroupRequest
    (   
        string Name,
        List<Guid> id_Students);
}
