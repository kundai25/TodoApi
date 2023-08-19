using AutoMapper;
using TodoApi.Model;

namespace TodoApi.Dto.Mapper
{
    public class GeneralMapper : Profile
    {
        public GeneralMapper()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<TodoTaskDto, TodoTask>().ReverseMap();
        }
    }
}
