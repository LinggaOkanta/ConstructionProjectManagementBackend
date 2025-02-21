// Infrastructure/External/ElasticSearchService.cs
using ConstructionProjectManagement.Domain.Entities;
using Nest;

public class ElasticSearchService
{
    private readonly ElasticClient _client;

    public ElasticSearchService()
    {
        var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
            .DefaultIndex("construction-projects");
        _client = new ElasticClient(settings);
    }

    public async Task IndexProjectAsync(ConstructionProject project)
    {
        var response = await _client.IndexDocumentAsync(project);
        if (!response.IsValid)
        {
            throw new Exception("Failed to index project in ElasticSearch.");
        }
    }

    public async Task<IEnumerable<ConstructionProject>> SearchProjectsAsync(string query)
    {
        var searchResponse = await _client.SearchAsync<ConstructionProject>(s => s
            .Query(q => q
                .Match(m => m
                    .Field(f => f.ProjectName)
                    .Query(query)
                )
            )
        );

        return searchResponse.Documents;
    }

    public async Task<ConstructionProject> GetProjectByIdAsync(int id)
    {
        var response = await _client.GetAsync<ConstructionProject>(id);
        if (!response.Found)
        {
            throw new KeyNotFoundException("Project not found in ElasticSearch.");
        }
        return response.Source;
    }
}