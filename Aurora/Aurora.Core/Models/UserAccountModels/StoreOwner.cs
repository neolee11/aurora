using Aurora.Core.Contracts.Business;

namespace Aurora.Core.Models.UserAccountModels
{
    public class StoreOwner : SystemUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string OwnerEmail { get; set; }
    }
}
