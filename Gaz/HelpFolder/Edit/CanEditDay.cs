using Gaz.Data;
using Gaz.Domain.Entities;
using SerGaz.Controllers;

namespace Gaz.HelpFolder.Edit
{
    public class CanEditDay
    {
        private readonly freedb_testdbgazContext _context;
        private readonly UsersRolesController usersRolesController;
        public CanEditDay(freedb_testdbgazContext context)
        {
            _context = context;
            usersRolesController = new UsersRolesController(_context);
        }

        public  bool CanEdit(int userId)
        {
            DateTime now = DateTime.Now;
            int day = now.Day;
            List<UsersRole> usersRoles = usersRolesController.GetRolesByUser(userId);
            if(usersRoles.Any(z=>z.Role.RoleName == "Стоп-РИСК" ||
            z.Role.RoleName == "Рационализаторская деятельность" || 
            z.Role.RoleName == "Бережливое производство" || 
            z.Role.RoleName == "Положительный опыт" || 
            z.Role.RoleName == "Наставничество" || z.Role.RoleName == "Профмастерство" || z.Role.RoleName == "Стоп-РИСК" || 
            z.Role.RoleName == "Экология" || z.Role.RoleName == "Спорт" || 
            z.Role.RoleName == "Культ-масс" || z.Role.RoleName == "Благотворительность" || 
            z.Role.RoleName == "Руководитель ГИТ" || 
            z.Role.RoleName == "Руководитель ГРС" || 
            z.Role.RoleName == "Руководитель ДС" || z.Role.RoleName == "Руководитель КИПиА" || 
            z.Role.RoleName == "Руководитель ЛЭС" || z.Role.RoleName == "Руководитель МТС" || 
            z.Role.RoleName == "Руководитель РСГЭХУ" || 
            z.Role.RoleName == "Руководитель СТС" || 
            z.Role.RoleName == "Руководитель ТЦ" || z.Role.RoleName == "Руководитель ЭВС" || 
            z.Role.RoleName == "Руководитель ЭХЗ"))
            {
                if (day <= 25)
                    return true;
                else
                    return false;
            }
            else if(usersRoles.Any(z=>z.Role.RoleName == "Сотрудник"))
            {
                if (day <= 20)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
