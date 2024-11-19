namespace Web_developing.Controllers.Response
{
    public record TeacherResponse
    (
        Guid id,
        string Name,
        string SecondName,
        ulong IndividualNumber,
        string Password);
}
