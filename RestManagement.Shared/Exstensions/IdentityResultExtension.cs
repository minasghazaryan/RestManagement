using Microsoft.AspNetCore.Identity;

namespace RestManagement.Shared
{
    public static class IdentityResultExtension
    {
        public static string GetErrorMessage(this IdentityResult result) =>
          string.Join(Environment.NewLine, result.Errors.Select(e => e.Description));
    }
}
