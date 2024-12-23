namespace Web_developing.Controllers.Request
{
    public record AuthRequest(
        ulong username,
        string password
        );
}
