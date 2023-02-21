using BasicApi.DataBase.Schemas;

namespace BasicApi.Application.RequestModels
{
    public class EmployeeRequestModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public EmployeeSchema ToSchema()
        {
            return new EmployeeSchema
            {
                Id = Id,
                Name = Name,
                Age = Age
            };
        }
    }
}