using System;

namespace Aurora.Core.Contracts.Business
{
    public abstract class SystemUser
    {
        public string Username { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
