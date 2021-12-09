using System.ComponentModel.DataAnnotations;

namespace FishStore.Entities.Accounting
{
    public class User
    {
        /// <summary>
        /// Получает или задает ИД
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Получает или задает Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Получает или задает День рождения пользователя
        /// </summary>
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// Получает или задает День рождения пользователя
        /// </summary>
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Получаеи или задаеи Роль пользователя
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Получает или задаеи Id роли
        /// </summary>
        public int? RoleId { get; set; }
    }
}
