public interface IUserContext
{
    bool IsInRole(Role role);
    Currency Currency { get; }
}

public enum Role { PreferredCustomer }