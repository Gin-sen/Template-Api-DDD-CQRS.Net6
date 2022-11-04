using Microsoft.AspNetCore.Hosting;
using System.Reflection;

namespace My.DDD.CQRS.Temp6.Reflection.Extensions
{
  public static class HostBuilderExtensions
  {
    public static IWebHostBuilder LoadAssemblyReferencedNotLoaded(this IWebHostBuilder hostBuilder, Assembly entryAssembly)
    {
      var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
        .Where(assembly => !assembly.IsDynamic)
        .ToList();
      var loadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();

      string[] assemblyPartNames = entryAssembly!.GetName().Name!.Split(".");
      var productName = string.Join(".", assemblyPartNames.Take(assemblyPartNames.Length - 1));
      var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, $"{productName}*.dll", new EnumerationOptions { MatchCasing = MatchCasing.CaseInsensitive });
      var toLoadAssemblies = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();

      toLoadAssemblies.ForEach(path =>
      {
        loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path)));
      });

      return hostBuilder;
    }
  }
}