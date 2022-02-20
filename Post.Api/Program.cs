using NLog.Web;

namespace Post
{
    public static class Program
    {
        private const string LogFileName = "nlog.config";

        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog(LogFileName).GetCurrentClassLogger();

            try
            {
                logger.Debug("Main init");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                logger.Error(e, "Program has benn stopped because of error");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}