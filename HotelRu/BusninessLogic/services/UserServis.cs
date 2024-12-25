using BusinessLogic.Services;
using Domian.Interfaces;
using Domian.Models;
using Microsoft.AspNetCore.Mvc; // Для IActionResult
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        /// <summary>
        /// Получает всех пользователей.
        /// </summary>
        /// <returns>Список всех пользователей.</returns>
        public async Task<List<User>> GetAll()
        {
            // Исправлено приведение типов:
            return (await _repositoryWrapper.User.FindAll()).ToList();
        }

        /// <summary>
        /// Получает пользователя по ID.
        /// </summary>
        /// <param name="id">ID пользователя.</param>
        /// <returns>Пользователь с указанным ID или null, если пользователь не найден.</returns>
        public async Task<User> GetById(int id)
        {
            var user = await _repositoryWrapper.User.FindByCondition(x => x.UserId == id);
            return user.FirstOrDefault(); // Безопаснее использовать FirstOrDefault()
        }

        /// <summary>
        /// Создает нового пользователя.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /User
        ///     {
        ///        "login" : "testuser",
        ///        "password" : "password123",
        ///        "firstname" : "Иван",
        ///        "lastname" : "Иванов",
        ///        "middlename" : "Иванович"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Модель пользователя для создания.</param>
        /// <returns></returns>
        public async Task Create(User model)
        {
            await _repositoryWrapper.User.Create(model);
            await _repositoryWrapper.Save(); // await обязателен для асинхронного Save
        }

        /// <summary>
        /// Обновляет существующего пользователя.
        /// </summary>
        /// <param name="model">Модель пользователя с обновленными данными.</param>
        /// <returns></returns>
        public async Task Update(User model)
        {
            _repositoryWrapper.User.Update(model);
            await _repositoryWrapper.Save(); // await обязателен для асинхронного Save
        }

        /// <summary>
        /// Удаляет пользователя по ID.
        /// </summary>
        /// <param name="id">ID пользователя для удаления.</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User.FindByCondition(x => x.UserId == id);

            if (user.FirstOrDefault() != null) // Проверка на null перед удалением
            {
                _repositoryWrapper.User.Delete(user.First());
                await _repositoryWrapper.Save(); // await обязателен для асинхронного Save
            }
        }
    }
}