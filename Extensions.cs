namespace SCPChat
{
    using Exiled.API.Features;

    public static class Extensions
    {

        public static string ToFormattedString(this Exiled.API.Features.Roles.Role role)
        {
            switch (role.Type)
            {
                case RoleType.Scp049:
                    return "SCP-049";
                case RoleType.Scp079:
                    return "SCP-079";
                case RoleType.Scp096:
                    return "SCP-096";
                case RoleType.Scp106:
                    return "SCP-106";
                case RoleType.Scp173:
                    return "SCP-173";
                case RoleType.Scp0492:
                    return "SCP-049-2";
                case RoleType.Scp93953:
                case RoleType.Scp93989:
                    return "SCP-939";
                default: return "Unknown";
            }
        }
    }
}