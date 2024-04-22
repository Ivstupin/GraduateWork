using System.Diagnostics;
using GraduateWork.Helpers.Configuration;
using NLog;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;


namespace GraduateWork.Clients;

public sealed class RestClientExtended
{
    //private string Token = "testmo_api_eyJpdiI6ImxCQWNsUFlYbXo4bHRwdUhDUENsbHc9PSIsInZhbHVlIjoidlFJMkFCa3BHRzZlazVBaEYzZUh6OUI3aGR4M2Yya1ZJeG8vclR0eDJjND0iLCJtYWMiOiJhNjg3ZTJiNGRmNzllNmUyODcyMTgyZGVjN2QxZmJmZjg2NDhlYzAxNjY1NzZkOTM5ZTEwZjUzNTFkMDEyMmQzIiwidGFnIjoiIn0=";
    private readonly RestClient _client;
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public RestClientExtended()
    {
        var options = new RestClientOptions(Configurator.AppSettings.URI ?? throw new InvalidOperationException())
        {
           // Authenticator =
                //new OAuth2AuthorizationRequestHeaderAuthenticator("Authorization", $"Bearer {Token}")
        };

        _client = new RestClient(options);
       // request.AddHeader("Authorization", $"Bearer {tok}");
        _client.AddDefaultHeaders(new Dictionary<string, string> {{ "Authorization", $"Bearer { Configurator.AppSettings.Token}" }});

        Debug.Assert(Configurator.Admin != null, "Configurator.Admin != null");
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }

    private void LogRequest(RestRequest request)
    {
        _logger.Debug($"{request.Method} request to: {request.Resource}");

        var body = request.Parameters
            .FirstOrDefault(p => p.Type == ParameterType.RequestBody)?.Value;

        if (body != null)
        {
            _logger.Debug($"body: {body}");
        }
    }

    private void LogResponse(RestResponse response)
    {
        if (response.ErrorException != null)
        {
            _logger.Error(
                $"Error retrieving response. Check inner details for more info. \n{response.ErrorException.Message}");
        }

        _logger.Debug($"Request finished with status code: {response.StatusCode}");

        if (!string.IsNullOrEmpty(response.Content))
        {
            _logger.Debug(response.Content);
        }
    }

    public async Task<RestResponse> ExecuteAsync(RestRequest request)
    {
        LogRequest(request);
        var response = await _client.ExecuteAsync(request);
        LogResponse(response);

        return response;
    }

    public async Task<T> ExecuteAsync<T>(RestRequest request)
    {
        LogRequest(request);
        var response = await _client.ExecuteAsync<T>(request);
        LogResponse(response);

        return response.Data ?? throw new InvalidOperationException();
    }
}