using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SkinetMarket.Extensions;

public static class UserManagerExtensions
{
    public static async Task<AppUser> FindByUserByClaimsPrincipalEmailWithAddressAsync(
        this UserManager<AppUser> input, ClaimsPrincipal user)
    {
        var email = user?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

        return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
    }

    public static async Task<AppUser> FindByEmailFromClaimsPrinciple(this UserManager<AppUser> input,
        ClaimsPrincipal user)
    {
        var email = user?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

        return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
    }
}