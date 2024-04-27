public interface IUserContext
{
    bool IsInRole(Role role);
}

public enum Role { PreferredCustomer }