namespace Web_developing.Controllers.Response
{
    public record StudentResponse
    (
        Guid id,
        string Name,
        string SecondName,
        string GroupName,
        ulong IndividualNumber,
        string Password);
}
