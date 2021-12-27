using GQLClient;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;

//var serviceCollection = new ServiceCollection();
//        serviceCollection.AddHttpClient(
//            "StarwarsClient",
//            c => c.BaseAddress = new Uri("http://127.0.0.1:8000"));
//        serviceCollection.AddStartwars();

//        IServiceProvider services = serviceCollection.BuildServiceProvider();
//        IStartwars client = services.GetRequiredService<IStartwars>();

//        IOperationResult<IGetHeroResult> result = await client.GetHero.ExecuteAsync(Episode.NewHope);
//        Console.WriteLine(((ISomeDroid)result.Data.Hero).Name);

//        result = await client.GetHero.ExecuteAsync(Episode.Empire);
//        Console.WriteLine(((ISomeHuman)result.Data.Hero).Name);


var serviceCollection = new ServiceCollection();

serviceCollection
    .AddStartwars()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://127.0.0.1:8000/graphql"));

IServiceProvider services = serviceCollection.BuildServiceProvider();

IStartwars client = services.GetRequiredService<IStartwars>();
var result = await client.GetHero.ExecuteAsync(Episode.Empire);
result.EnsureNoErrors();

Console.WriteLine(((ISomeHuman)result.Data.Hero).Name);