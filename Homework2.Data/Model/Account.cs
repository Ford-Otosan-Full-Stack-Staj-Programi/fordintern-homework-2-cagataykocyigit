

using Homework2.Base.Model;

namespace Homework2.Data.Model;

public class Account : BaseModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public DateTime LastActivity { get; set; }

}
