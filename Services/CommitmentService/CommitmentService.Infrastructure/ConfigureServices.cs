// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using CommitmentService.Core;
using CommitmentService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {

        services.AddScoped<ICommitmentServiceDbContext, CommitmentServiceDbContext>();
        services.AddDbContextPool<CommitmentServiceDbContext>(options =>
        {
            options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("CommitmentService.Infrastructure"))
            .EnableThreadSafetyChecks(false);
        });
    }
}
