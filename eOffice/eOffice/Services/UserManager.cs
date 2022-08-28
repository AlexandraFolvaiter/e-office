namespace eOffice.Services;

public static class UserManager
{
    public static Guid EmployeeId = Guid.Parse("6a1500c7-4843-4828-9e31-99fb7ce7cbc6");
    public static Guid OperatorId = Guid.Parse("23421bc1-f23f-4d72-82d7-68b5dde7f3db");
    public static Guid ManagerId = Guid.Parse("7f34766e-725c-445c-97c5-e569777c4d78");

    public static bool IsEmployee(this Guid id)
    {
        return id.Equals(EmployeeId);
    }

    public static bool IsOperator(this Guid id)
    {
        return id.Equals(OperatorId);
    }

    public static bool IsManager(this Guid id)
    {
        return id.Equals(ManagerId);
    }

    public static string GetRole(this Guid id)
    {
        if (id.Equals(EmployeeId))
        {
            return "employee";
        }

        if (id.Equals(OperatorId))
        {
            return "operator";
        }

        if (id.Equals(ManagerId))
        {
            return "manager";
        }

        return "Unknown";
    }
}