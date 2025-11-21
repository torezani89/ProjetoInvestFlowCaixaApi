//using Microsoft.AspNetCore.Hosting;
//using Microsoft.VisualStudio.TestPlatform.TestHost;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//namespace InvestFlowCaixa.IntegrationTests.Setup

//{

//    public class TestApiFactory : WebApplicationFactory<Program>
//    {
//        private readonly string _databaseName;

//        public TestApiFactory()
//        {
//            _databaseName = Guid.NewGuid().ToString();
//        }

//        private TestApiFactory(string databaseName)
//        {
//            _databaseName = databaseName;
//        }

//        protected override void ConfigureWebHost(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices(services =>
//            {
//                // Remove registration atual do DbContext (se existir)
//                var descriptor = services.SingleOrDefault(
//                    d => d.ServiceType == typeof(DbContextOptions<InvestimentosDbContext>));
//                if (descriptor != null) services.Remove(descriptor);

//                // Registrar InMemory com nome único (isola testes)
//                services.AddDbContext<InvestimentosDbContext>(options =>
//                {
//                    options.UseInMemoryDatabase(_databaseName);
//                });

//                // Opcional: se precisar inicializar seed, faça aqui.
//                var sp = services.BuildServiceProvider();
//                using (var scope = sp.CreateScope())
//                {
//                    var db = scope.ServiceProvider.GetRequiredService<InvestimentosDbContext>();
//                    db.Database.EnsureCreated();
//                }
//            });
//        }
//    }

//}
