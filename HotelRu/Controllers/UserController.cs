using Domian.Interfaces;
using Domian.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;
using HotelRu.Contracts;
namespace HotelRus.Controllers
{
    /// <summary>
    /// Контроллер для управления пользователями.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService; // readonly для внедряемых зависимостей - хорошая практика
        private readonly IMapper _mapper; // Внедряем IMapper от Mapster


        /// <summary>
        /// Конструктор контроллера UserController.
        /// </summary>
        /// <param name="userService">Сервис для работы с пользователями.</param>
        public UserController(IUserService userService, IMapper mapper) // Добавляем IMapper в конструктор
        {
            _userService = userService;
            _mapper = mapper;
        }

            /// <summary>
            /// Возвращает всех пользователей.
            /// </summary>
            /// <returns>Список всех пользователей (HTTP 200 OK).</returns>
            [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        /// <summary>
        /// Возвращает пользователя по ID.
        /// </summary>
        /// <param name="id">ID пользователя.</param>
        /// <returns>Пользователь с указанным ID (HTTP 200 OK) или NotFound (HTTP 404), если пользователь не найден.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
            {
                return NotFound(); // Возвращаем NotFound, если пользователь не найден
            }
            return Ok(user);
        }

        /// <summary>
        /// Создает нового пользователя.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /api/User
        ///     {
        ///        "login": "testuser",
        ///        "password": "password123",
        ///        "firstname": "Иван",
        ///        "lastname": "Иванов",
        ///        "middlename": "Иванович"
        ///     }
        /// </remarks>
        /// <param name="user">Модель нового пользователя.</param>
        /// <returns>HTTP 200 OK, если пользователь успешно создан, или BadRequest (HTTP 400), если данные некорректны.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request) 
        {
            var user = _mapper.Map<User>(request);
            await _userService.Create(user);
            return Ok();
        }

        /// <summary>
        /// Обновляет данные пользователя.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /api/User
        ///     {
        ///        "userId": 1, // ID пользователя для обновления
        ///        "login": "updateduser",
        ///        "password": "newpassword",
        ///         // ... другие поля ...
        ///     }
        /// </remarks>
        /// <param name="user">Модель пользователя с обновленными данными.</param>
        /// <returns>HTTP 200 OK, если пользователь успешно обновлен, или BadRequest, если данные некорректны, или NotFound, если пользователь не найден.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] GetUserResponse request)
        {
            var existingUser = await _userService.GetById(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            _mapper.Map(request, existingUser); // Маппим request в existingUser
            await _userService.Update(existingUser);
            return Ok();

        }

        /// <summary>
        /// Удаляет пользователя по ID.
        /// </summary>
        /// <param name="id">ID пользователя для удаления.</param>
        /// <returns>HTTP 200 OK, если пользователь успешно удален, или NotFound, если пользователь не найден.</returns>
        [HttpDelete("{id}")] // Добавлен {id} для соответствия Delete в UserService
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}