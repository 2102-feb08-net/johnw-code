using EFDemo.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EFDemo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var logStream = new StreamWriter("ef-logs.txt", append: false) { AutoFlush = true };
            string connectionString = File.ReadAllText("C:/revature/chinook-connection-string.txt");
            DbContextOptions<ChinookContext> options = new DbContextOptionsBuilder<ChinookContext>()
                .UseSqlServer(connectionString)
                .LogTo(logStream.WriteLine, minimumLevel: LogLevel.Information)
                .Options;
            using var context = new ChinookContext(options);

            Display5Tracks(context);

            EditOneOfThoseTracks(context);

            Display5Tracks(context);

            InsertANewTrack(context);

            Display5Tracks(context);

            DeleteTheNewTrack(context);

            Display5Tracks(context);

            // implement some CRUD (create, read, update, delete) operations like those
            // use the reference material i've given on EF Core.

            // bonus: involve multiple tables in the operations, not just track
            // bonus: do it based on user input (Console.ReadLine)
        }

        public static void Display5Tracks(ChinookContext ctx)
        {
            IQueryable<string> query = ctx.Tracks
                .Select(x => x.Name)
                .Take(5);

            List<string> results = query.ToList();
            Console.WriteLine();
            foreach (string s in results)
            {
                Console.WriteLine(s);
            }
        }

        public static void EditOneOfThoseTracks(ChinookContext ctx)
        {
            Track t = ctx.Tracks.Where(t => t.Name.Contains("balls to the wall")).FirstOrDefault();
            if (t.Name == "Balls to the Wall (2)")
            {
                t.Name = "Balls to the Wall";
            }
            else if(t.Name == "Balls to the Wall")
            {
                t.Name = "Balls to the Wall (2)";
            }
            ctx.Update(t);
            ctx.SaveChanges();
        }

        public static void InsertANewTrack(ChinookContext ctx)
        {
            Track t = new Track();
            t.Name = "Test track";
            t.MediaTypeId = 1;
            t.Composer = "Weird Al";
            t.Milliseconds = 123456;
            t.UnitPrice = 0.99M;
            ctx.Add(t);
            ctx.SaveChanges();
            Track n = ctx.Tracks.Where(t => t.Name.Contains("test track")).FirstOrDefault();
            Console.WriteLine($"Here is the new track: {n.Name}");
        }

        public static void DeleteTheNewTrack(ChinookContext ctx)
        {
            ctx.Tracks.Remove(ctx.Tracks.Where(t => t.Name.Contains("test track")).FirstOrDefault());
            ctx.SaveChanges();
        }
    }
}
