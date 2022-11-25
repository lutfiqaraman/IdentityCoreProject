using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace IdentityCoreProject.Authorization
{
    public class HRManager : IAuthorizationRequirement
    {
        public int ProbationMonth { get; }
        public HRManager(int probationMonth)
        {
            ProbationMonth = probationMonth;
        }

        public class HRManagerHandler : AuthorizationHandler<HRManager>
        {
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HRManager requirement)
            {
                if (!context.User.HasClaim(x => x.Type == "EmploymentDate"))
                    return Task.CompletedTask;

                DateTime empDate = DateTime.Parse(context.User.FindFirst(x => x.Type == "EmploymentDate")!.Value);
                TimeSpan period = DateTime.Now - empDate;

                if (period.Days > 30 * requirement.ProbationMonth)
                    context.Succeed(requirement);

                return Task.CompletedTask;
            }
        }
    }
}
