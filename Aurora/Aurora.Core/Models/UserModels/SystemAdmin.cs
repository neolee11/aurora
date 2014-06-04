using Aurora.Core.Contracts.UserInfo;

namespace Aurora.Core.Models.UserModels
{
    public class SystemAdmin : User
    {
        public int Id { get; set; }
        public string AdminEmail { get; set; }
    }
}
