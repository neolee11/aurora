using Aurora.Core.Contracts.UserAccount;

namespace Aurora.Core.Models.UserAccountModels
{
    public class SystemAdmin : User
    {
        public int Id { get; set; }
        public string AdminEmail { get; set; }
    }
}
