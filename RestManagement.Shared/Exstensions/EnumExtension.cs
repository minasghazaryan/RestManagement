namespace RestManagement.Shared
{
    public static class EnumExtension
    {
        public static IEnumerable<string> GetNames<T>(this T @enum) where T : Enum
        {
           return Enum.GetNames(@enum.GetType());
        }
    }
}
