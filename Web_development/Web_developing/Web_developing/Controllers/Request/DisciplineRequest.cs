namespace Web_developing.Controllers.Request;

public record DisciplineRequest
(
    string Name,
    Guid idTeacher,
    Guid idGroup 
    );
