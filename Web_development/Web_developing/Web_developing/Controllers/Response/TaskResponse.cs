namespace Web_developing.Controllers.Response
{
    public record TaskResponse
    (
        Guid id,
        DateTime DareCreate,
        DateTime DateFinish,
        string Description,
        Guid idDiscipline,
        Guid idGroup,
        Guid idTeacher);

    public record TaskResponseForStiudentPage
    (
        Guid id,
        string DisciplineName,
        DateTime DateFinish,
        string Description,
        string TeacherName);

    public record TaskResponseOne
    (
        DateTime DateFinish,
        string Description,
        string Discipline);
}
