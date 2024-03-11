using System.Text;
using Dynamitey.Internal.Optimization;
using Microsoft.Playwright;
using Newtonsoft.Json;
using NUnit.Framework;

namespace PlaywrightSpecflow;

[Binding]
public class APITestSteps
{
    private IPage page;
    private IAPIResponse apiResponse;


    [Given(@"I have a valid API endpoint")]
    public async Task GivenIHaveAValidApiEndpoint()
    {
        var endpoint = "https://swapi.py4e.com/api/";
    }

    [When(@"I make a GET request using Playwright")]
    public async Task WhenIMakeAgetRequestUsingPlaywright()
    {
        var playwright = await Playwright.CreateAsync();
        var context = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
        {
            BaseURL = "https://swapi.py4e.com/api/"
        });
        apiResponse = await context.GetAsync("people/1/");
    }

    [Then(@"the API should respond with a successful status code")]
    public void ThenTheApiShouldRespondWithASuccessfulStatusCode()
    {
        Assert.AreEqual(apiResponse.Status, 200);
    }

    [Then(@"the response body is as expected")]
    public async Task ThenTheResponseBodyIsAsExpected()
    {
        
        var json = await apiResponse.JsonAsync();
        string jsonString = json.ToString();
        var character = System.Text.Json.JsonSerializer.Deserialize<Character>(jsonString);
        Assert.AreEqual("Luke Skywalker", character.name);
        Assert.AreEqual("172", character.height);
        Assert.AreEqual("77", character.mass);

        


    }
    public class Character
    {
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
       
    }

    [Then(@"I can send a API call to the bank using POST")]
    public async Task ThenICanSendAapiCallToTheBankUsingPost()
    {
        var playwright = await Playwright.CreateAsync();
        var context = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions());
        apiResponse = await context.GetAsync("http://www.api-examplebank.com/sendpayment");
    }

    [Then(@"I can send a API call to the bank using SOAP")]
    public async Task ThenICanSendAapiCallToTheBankUsingSoap()
    {
        string soapEnvelope = @"
        <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:web=""http://www.example.com/"">
           <soapenv:Header/>
           <soapenv:Body>
              <web:YourOperation>
                 <!--Your operation data-->
              </web:YourOperation>
           </soapenv:Body>
        </soapenv:Envelope>";

        using (var httpClient = new HttpClient())
        {
            var httpContent = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
            httpContent.Headers.Add("SOAPAction", "http://www.examplevitesse.com/checkpayment");
            var response = await httpClient.PostAsync("http://www.api-examplebank.com/sendpayment", httpContent);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

        }
    }
}
    
  