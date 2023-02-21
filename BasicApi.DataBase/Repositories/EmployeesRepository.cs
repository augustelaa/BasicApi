using BasicApi.DataBase.Contexts;
using BasicApi.DataBase.Interfaces;
using BasicApi.DataBase.Schemas;

namespace BasicApi.DataBase.Repositories
{
    public class EmployeesRepository : SQLiteDbContext, IEmployeesRepository
    {
        public void Delete(long id)
        {
            var sql = @"
                    DELETE employees
                    WHERE id = @Id";
            Delete(sql);
        }

        public bool Insert(EmployeeSchema employee)
        {
            var sql = @"
                    INSERT INTO employees
                    (name),
                    (age)
                    VALUES
                    (@Name),
                    (@Age);
                    SELECT last_insert_rowid();";
            return Insert<EmployeeSchema>(sql, employee) > 0;
        }

        public EmployeeSchema Select(long id)
        {
            var sql = @"
                    SELECT * FROM employees
                    WHERE id = @Id";
            return Select<EmployeeSchema>(sql);
        }

        public void Update(EmployeeSchema employee)
        {
            var sql = @"
                    UPDATE employees
                    SET name = @Name, age = @Age
                    WHERE id = @Id";
            Update<EmployeeSchema>(sql, employee);
        }
    }
}
