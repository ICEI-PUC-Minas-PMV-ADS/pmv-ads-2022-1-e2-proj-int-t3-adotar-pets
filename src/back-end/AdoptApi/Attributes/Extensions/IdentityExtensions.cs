using System.Security.Claims;
using System.Security.Principal;

namespace AdoptApi.Attributes.Extensions;

public static class IdentityExtensions
{
    public static int GetUserId(this IIdentity identity)
    {
        ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
        Claim claim = claimsIdentity?.FindFirst(ClaimTypes.PrimarySid);

        if (claim == null)
            return 0;

        return int.Parse(claim.Value);
    }
}