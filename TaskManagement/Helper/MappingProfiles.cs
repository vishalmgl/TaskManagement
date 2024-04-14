using AutoMapper;
using TaskManagement.dto;
using TaskManagement.Model;

namespace TaskManagement.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model.Task, TaskDto>();
            CreateMap<TaskAssignment, TaskAssigmnentDto>();
            CreateMap<TaskDto, Model.Task>();
            CreateMap<TaskAssigmnentDto, TaskAssignment>();
            CreateMap<User,UserDto>();
            CreateMap<UserDto, User>();
            
        }
    }
}
