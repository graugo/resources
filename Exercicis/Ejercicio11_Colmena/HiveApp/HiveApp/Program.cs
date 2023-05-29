using HiveApp.Infrastructure.Contracts.Contracts;
using HiveApp.Infrastructure.Impl.Implementations;
using HiveApp.Library.Model;
using HiveApp.ServiceLibrary.Contracts.Contracts;
using HiveApp.ServiceLibrary.Impl;
using System;
using System.Collections.Generic;
using System.IO;

namespace HiveApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO Add inversion of control
            //IHiveRepository repository = new HiveJsonLoader(Path.Combine(Environment.CurrentDirectory, @"../../../hive.json"));
            IHiveRepository repository = new HiveXmlLoader(Path.Combine(Environment.CurrentDirectory, @"../../../hive.xml"));
            HiveEntity hive = repository.ReadHive();

            IHiveFilterService filterService = new HiveFilterService();
            List<BeeEntity> bees = filterService.GetAllBees(hive);
            foreach (BeeEntity bee in bees)
            {
                Console.WriteLine($"ID:{bee.Id}, Name:{bee.Name}");
            }

            Console.Read();
        }
    }
}
