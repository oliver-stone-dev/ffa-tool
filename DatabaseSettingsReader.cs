using System.IO;
using System.Text.Json;

namespace ffa_tool;

public static class DatabaseSettingsReader
{
    private static readonly string _settingsPath = Path.GetFullPath("C:\\Users\\olley\\Documents\\Development\\ffa-tool\\DatabaseSettings.json");

    private static JsonDocument? _settings;

    static DatabaseSettingsReader()
    {
        _settings = GetJsonDocument();
    }

    private static JsonDocument? GetJsonDocument()
    {
        if (File.Exists(_settingsPath))
        {
            var fileString = File.ReadAllText(_settingsPath);

            if (string.IsNullOrEmpty(fileString) == false)
            {
                return JsonDocument.Parse(fileString);
            }
        }

        return null;
    }

    public static string ReadSetting(string key)
    {
        if (_settings == null) return string.Empty;

        var root = _settings.RootElement;
        var data = root.GetProperty(key).GetString();

        return string.IsNullOrEmpty(data) ? string.Empty : data;
    }
}
