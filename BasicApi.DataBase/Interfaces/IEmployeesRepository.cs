using BasicApi.DataBase.Schemas;

namespace BasicApi.DataBase.Interfaces
{
    public interface IEmployeesRepository
    {
        void Delete(long id);
        long Insert(EmployeeSchema employee);
        EmployeeSchema Select(long id);
        void Update(EmployeeSchema employee);
    }
}
