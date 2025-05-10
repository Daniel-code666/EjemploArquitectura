using AutoMapper;
using WebApi.Entitites;
using WebApi.Objects;

namespace WebApi
{
    internal class ApplicationAppProfile : Profile
    {
        public ApplicationAppProfile()
        {
            MapUsers();
        }

        public void MapUsers()
        {
            CreateMap<UsersCreate, TblUsersEntity>();
            CreateMap<TblUsersEntity, UsersRead>();
        }
    }
}
