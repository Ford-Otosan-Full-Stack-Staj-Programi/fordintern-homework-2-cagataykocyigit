using Homework2.Base.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace Homework2.Data.Model
{
    public class Person : BaseModel
    {
        [BindNever]
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
