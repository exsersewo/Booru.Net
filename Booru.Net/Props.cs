using System.Reflection;

namespace Booru.Net
{
    static class Props
    {
        public static string LibraryVersion { get; } =
            typeof(SafebooruClient).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
            typeof(SafebooruClient).GetTypeInfo().Assembly.GetName().Version.ToString(3) ??
            "Unknown";
    }
}
