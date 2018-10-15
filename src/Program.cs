using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;

namespace demo.json
{
  class Program
  {
    static IConfigurationRoot _config;

    static void Main(string[] args)
    {

      const string dataFolderKey = "data-folder";
      const string fileName = "sample01.json";

      _config = GetConfiguration();

      var folder = _config.GetSection(dataFolderKey).Value;

      var fullPath = Path.Combine(folder, fileName);

      FileInfo fi = new FileInfo(fullPath);

      var settings = new JsonSerializerSettings
      {
        TypeNameHandling = TypeNameHandling.All,
        Formatting = Formatting.None,
        MissingMemberHandling = MissingMemberHandling.Error
      };

      JsonSerializer serializer = new JsonSerializer();

      using (StreamReader reader = new StreamReader(fi.FullName))
      {
        var text = reader.ReadToEnd();
      }

      //var result = JsonConvert.SerializeObject(person, settings);

      //System.Console.WriteLine(result);

    }

    private static IConfigurationRoot GetConfiguration()
    {
      var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

      return builder.Build();
    }

    private static FileInfo GetData(string filename)
    {

      //var folder = _config.ToString
      var fi = new FileInfo(filename);

      if (!fi.Exists)
      {
        throw new Exception($"Cannot find data file: {filename}");
      }

      return fi;
    }
  }
}
