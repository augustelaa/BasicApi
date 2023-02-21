using BasicApi.DataBase.Schemas;
using System.ComponentModel.DataAnnotations;

namespace BasicApi.Application.RequestModels
{
    public class EmployeeRequestModel : IValidatableObject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [Range(1, int.MaxValue)]
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("No name has been sent.", new string[] { "Name" });
            }
        }
    }
}