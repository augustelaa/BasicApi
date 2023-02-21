using BasicApi.DataBase.Schemas;
using System.ComponentModel.DataAnnotations;

namespace BasicApi.Application.RequestModels
{
    // For preventing over-posting and to ommit some propperties, we are going to use a request model instead of the real model itself.
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
        // We can use the Required anottation either... but i've made this as a ValidatableObject just to make an example.
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("No name has been sent.", new string[] { "Name" });
            }
        }
    }
}