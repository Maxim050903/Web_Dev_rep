namespace Web_developing.Controllers.Request
{
    public record StudentRequest
    (string Name,
    string SecondName,
    string GroupName,
    ulong IndividualNumber,
    string Password);
}
