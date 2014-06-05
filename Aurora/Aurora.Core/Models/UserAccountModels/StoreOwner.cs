using Aurora.Core.Contracts.UserAccount;

namespace Aurora.Core.Models.UserAccountModels
{
    public class StoreOwner : User
    {
        public int Id { get; set; }
        public string OwnerEmail { get; set; }
    }
}
