using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpOrientation.Models;
using CsvHelper;

namespace CSharpOrientation.Repositories
{
    public interface IArtRepository
    {
        List<string> GetAllTitles();
    }

    public class ArtRepository : IArtRepository
    {
        private class ArtRecord
        {
            public string title { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string location { get; set; }
            public string medium { get; set; }
            public string type { get; set; }
            public string description { get; set; }
            public double? latitude { get; set; }
            public double? longitude { get; set; }
            public string mapped_location { get; set; }

        }
        private string ART_CSV = Path.Combine("Data", "nashville_art.csv");
        public List<string> GetAllTitles()
        {
            using (TextReader reader = new StreamReader(ART_CSV))
            {
                using (CsvReader csv = new CsvReader(reader))
                {
                    return csv.GetRecords<ArtRecord>()
                              .Select(a => a.title)
                              .ToList();
                }
            }
        }
    }
}