using DiscordExpeditionBot.Services;
using NetCord.Services;
using NetCord.Services.ApplicationCommands;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordExpeditionBot.Preconditions;

public class RequireRegisteredUserAttribute : PreconditionAttribute<ApplicationCommandContext>
{
    public override async ValueTask<PreconditionResult> EnsureCanExecuteAsync(ApplicationCommandContext context, IServiceProvider? services)
    {
        var expeditionManager = services.GetRequiredService<ExpeditionManager>();
        var user = await expeditionManager.GetUserAsync(context.User.Id);

        if (user == null)
        {
            // You can customize the error message here
            return PreconditionResult.Fail("You are not registered! Please use `/initialize_user` first.");
        }

        // Optional: Cache the user in the context so you don't have to fetch it again in the command
        // context.Properties["CurrentUser"] = user; 
        
        return PreconditionResult.Success;
    }
}