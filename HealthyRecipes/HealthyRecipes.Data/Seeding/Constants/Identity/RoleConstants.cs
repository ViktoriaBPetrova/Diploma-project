namespace HealthyRecipes.Data.Seeding.Constants.Identity
{
    public class RoleConstants
    {
        // ---------- Role IDs ----------
        public const string AdminRoleId = "a1b2c3d4-e5f6-7890-abcd-ef1234567890";
        public const string UserRoleId = "b2c3d4e5-f6a7-8901-bcde-f12345678901";

        // ---------- Role Names ----------
        public const string AdminRoleName = "Admin";
        public const string UserRoleName = "User";

        // ---------- Normalized Role Names ----------
        public const string AdminRoleNormalized = "ADMIN";
        public const string UserRoleNormalized = "USER";

        // ---------- Concurrency Stamps ----------
        public const string AdminRoleConcurrencyStamp = "admin-role-stamp";
        public const string UserRoleConcurrencyStamp = "user-role-stamp";
    }
}
