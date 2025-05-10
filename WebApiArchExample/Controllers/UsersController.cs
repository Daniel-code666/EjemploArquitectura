using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Objects;

namespace WebApiArchExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersBussiness _usersBussiness;

        public UsersController(IUsersBussiness usersBussiness)
        {
            _usersBussiness = usersBussiness;
        }

        /// <summary>
        /// obtiene todos los usuarios
        /// </summary>
        /// <returns><see cref="IEnumerable{UsersRead}"/> colección</returns>
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<UsersRead?>>> GetAllUsers()
            => Ok(await _usersBussiness.GetAllUsers());

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="user"><see cref="UsersCreate"/> instancia</param>
        /// <returns><see cref="Guid"/> devuelve el guid del usuario creado o vacío si no se creó</returns>
        [HttpPost("CreateUser")]
        public async Task<ActionResult<Guid?>> CreateUser([FromBody] UsersCreate user)
            => Ok(await _usersBussiness.CreateUser(user));
    }
}
