using System;
using System.Net.Http.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Ticketing.Specs.Entities;

namespace Ticketing.Specs.StepDefinitions
{
    [Binding]
    public class TicketingStepDefinitions
    {
        private readonly HttpClient _httpClient;
        private readonly ScenarioContext _scenarioContext;

        public TicketingStepDefinitions(HttpClient httpclient, ScenarioContext scenarioContext)
        {
            _httpClient = httpclient;
            _scenarioContext = scenarioContext;
        }

        [When(@"customer fills all the following datas and submits the form")]
        public async Task WhenCustomerFillsAllTheFollowingDatasAndSubmitsTheFormAsync(Table table)
        {
            var createTicketRequests = table.CreateSet<CreateTicketRequests>();
            var createdTickets = new List<TicketResponse>();
            foreach (var createTicketRequest in createTicketRequests)
            {
                var response = await _httpClient.PostAsJsonAsync("/api/v1/Ticketing", createTicketRequest);
                var responseTicket = await response.Content.ReadFromJsonAsync<TicketResponse>();
                createdTickets.Add(responseTicket);
            }
            _scenarioContext.Add("CreatedTickets", createdTickets);
        }

        [Then(@"a ticket should be succesfully created")]
        public async Task ThenATicketShouldBeSuccesfullyCreatedAsync()
        {
            var createdTickets = _scenarioContext.Get<List<TicketResponse>>("CreatedTickets");
            foreach (var createdTicket in createdTickets)
            {
                var response = await _httpClient.GetFromJsonAsync<TicketResponse>($"/api/v1/Ticketing/{createdTicket.Id}");
                createdTicket.Should().BeEquivalentTo(response);
            }
        }

        [Given(@"the following datas are already submitted")]
        public void GivenTheFollowingDatasAreAlreadySubmitted(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"I view a ticket")]
        public void WhenIViewATicket()
        {
            throw new PendingStepException();
        }

        [Then(@"display all information of the ticket")]
        public void ThenDisplayAllInformationOfTheTicket()
        {
            throw new PendingStepException();
        }
    }
}
