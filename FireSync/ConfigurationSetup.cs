namespace FireSync
{
    /// <summary>
    /// Represents the configuration setup.
    /// </summary>
    public static class ConfigurationSetup
    {
        /// <summary>
        /// Adds the custom configuration.
        /// </summary>
        /// <param name="builder">The configuration builder.</param>
        /// <param name="env">The web host environment.</param>
        /// <returns>A <see cref="IConfigurationBuilder"/> instance.</returns>
        public static IConfigurationBuilder AddCustomConfiguration(this IConfigurationBuilder builder, IWebHostEnvironment env)
        {
            return builder.SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("Configurations/appsettings.json", optional: false, reloadOnChange: true)
                          .AddJsonFile($"Configurations/appsettings.{env.EnvironmentName}.json", optional: true)
                          .AddJsonFile("Configurations/database.json", optional: false, reloadOnChange: true)
                          .AddJsonFile($"Configurations/database.{env.EnvironmentName}.json", optional: true)
                          .AddEnvironmentVariables();
        }
    }
}
