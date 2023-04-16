using Homework2.Base.Dto;

namespace Homework2.Dto.Dto
{
    public class PersonDto : BaseDto
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
