using System.Collections.Generic;
using CSharpOrientation.Repositories;

namespace CSharpOrientation.Services
{
    public interface IArtService
    {
        List<string> SearchTitles(string searchCriteria);
    }

    public class ArtService : IArtService
    {
        private readonly IArtRepository _artRepository;

        public ArtService(IArtRepository artRepository)
        {
            _artRepository = artRepository;
        }

        public List<string> SearchTitles(string searchCriteria)
        {
            List<string> allTitles = _artRepository.GetAllTitles();

            List<string> results = new List<string>();

            if (searchCriteria == null)
            {
                results = allTitles;
            }
            else
            {
                foreach (string title in allTitles)
                {
                    if (title.Contains(searchCriteria))
                    {
                        results.Add(title);
                    }
                }
            }

            return results;
        }
    }
}