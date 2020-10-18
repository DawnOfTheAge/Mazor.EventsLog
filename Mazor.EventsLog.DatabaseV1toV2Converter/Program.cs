using Mazor.EventsLog.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazor.EventsLog.DatabaseV1toV2Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            string JsonFilePath;
            string result;
            string stage = string.Empty;

            List<CriminalEvent> criminalEvents;

            try
            {
                stage = "Reading CLI Arguments";
                if ((args == null) || (args.Length != 1))
                {
                    Console.WriteLine($"No Arguments. Try 'DatabaseV1toV2Converter <Filename>.json'");

                    Environment.Exit(0);
                }

                JsonFilePath = args[0];

                stage = "Loading V1 JSON File";
                if (!Utils.LoadFromJson(JsonFilePath, out criminalEvents, out result))
                {
                    Console.WriteLine($"Failed Loading V1 JSON File '{JsonFilePath}'. {result}");

                    Environment.Exit(0);
                }

                stage = "Saving V1 JSON File As Backup";
                File.Copy(JsonFilePath, JsonFilePath.Replace(".json", $"{DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss")}.V1.json"));

                stage = "Creating New Databes Object";
                EventsLogDatabase eventsLogDatabase = new EventsLogDatabase();
                eventsLogDatabase.CriminalEventsRecordsList.AddRange(criminalEvents);

                stage = "Saving V2 JSON File";
                if (!Utils.SaveToJson(JsonFilePath, eventsLogDatabase, out result))
                {
                    Console.WriteLine($"Failed Saving v2 JSON File '{JsonFilePath}'. {result}");

                    Environment.Exit(0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed At Stage {stage}. {e.Message}");
            }
        }
    }
}
