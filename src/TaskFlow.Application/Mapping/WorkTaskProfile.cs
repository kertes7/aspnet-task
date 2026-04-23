using AutoMapper;
using TaskFlow.Application.Dtos;
using TaskFlow.Domain;

namespace TaskFlow.Application.Mapping;

public class WorkTaskProfile : Profile
{
    public WorkTaskProfile()
    {
        CreateMap<Project, ProjectDto>()
            .ForCtorParam("OwnerName", opt => opt.MapFrom(project => project.Owner == null ? null : project.Owner.FullName))
            .ForCtorParam("TasksCount", opt => opt.MapFrom(project => project.Tasks.Count));

        CreateMap<WorkTask, WorkTaskDto>()
            .ForCtorParam("ProjectName", opt => opt.MapFrom(task => task.Project == null ? null : task.Project.Name))
            .ForCtorParam("AssigneeName", opt => opt.MapFrom(task => task.Assignee == null ? null : task.Assignee.FullName))
            .ForCtorParam("CommentsCount", opt => opt.MapFrom(task => task.Comments.Count));
    }
}
