using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace demo.json
{
  class Program
  {
    static void Main(string[] args)
    {
      var config = new ConfigurationBuilder();

      var person = new Person
      {
        Id = Guid.NewGuid(),
        FirstName = "Ted",
        LastName = "Shred"
      };

      System.Console.WriteLine(person.Id);

    }
  }
}
