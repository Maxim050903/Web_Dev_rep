﻿using WebDev.Core.Models;


namespace WebDev.Core.Interfaces
{
    public interface IDisciplineRepository
    {
        Task<Guid> CreateDiscepline(Discipline discipline);
        Task<Guid> DeleteDiscepline(Guid id);
        Task<List<Discipline>> GetDisciplinesForTeacher(Guid idTeacher);
        Task<Guid> UpdateDiscepline(Guid id, Guid idTeacher, List<Guid> idGroups, string Name);
        Task<Discipline> GetDisciplinesForId(Guid id);
    }
}