using AutoMapper;
using WebApi.Entitites;
using WebApi.Interfaces;
using WebApi.Objects;
using WebApiArch;
using WebApiArch.Base;


namespace WebApi.Repository
{
    public class UsersBussiness : ApplicationBase, IUsersBussiness
    {
        private readonly IUsersRepository _usersRepository;

        public UsersBussiness(IMapper mapper, IUsersRepository usersRepository) : base(mapper)
        {
            _usersRepository = usersRepository;
        }

        async Task<Guid?> IUsersBussiness.CreateUser(UsersCreate user)
        {
            if (await _usersRepository.CreateUser(_mapper.Map<TblUsersEntity>(user)) is Guid id_user)
                return id_user;

            throw new WebApiExceptions("Error al crear el usuario", 500);
        }

        async Task<IEnumerable<UsersRead?>> IUsersBussiness.GetAllUsers()
            => _mapper.Map<IEnumerable<UsersRead?>>(await _usersRepository.GetAllUsers());
    }
}
