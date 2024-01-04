using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myClientListApp.Models;
using myClientListApp.Services;
using myClientListApp.DTOs; 

namespace myClientListApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IEnumerable<ClientDto>> GetAllClients()
        {
            var clients = await _clientService.GetAllClients();
            var clientDtos = new List<ClientDto>();

            foreach (var client in clients)
            {
                clientDtos.Add(new ClientDto(client));
            }

            return clientDtos;
        }

        [HttpGet("{clientId}")]
        public async Task<ActionResult<ClientDto>> GetClientById(int clientId)
        {
            var client = await _clientService.GetClientById(clientId);

            if (client == null)
            {
                return NotFound();
            }

            var clientDto = new ClientDto(client);
            return clientDto;
        }

        [HttpGet("search")]
        public async Task<IEnumerable<ClientDto>> SearchClients([FromQuery] string query)
        {
            var clients = await _clientService.SearchClients(query);
            var clientDtos = clients.Select(client => new ClientDto(client)).ToList();

            return clientDtos;
        }


        [HttpPost]
        public async Task<ActionResult<ClientDto>> AddClient(ClientDto clientDto)
        {
            try
            {
                // Validate and process logic
                var client = clientDto.ToClient();
                await _clientService.AddClient(client);

                // Return the created ClientDto
                return CreatedAtAction(nameof(GetClientById), new { clientId = client.Id }, new ClientDto(client));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("{clientId}")]
        public async Task<IActionResult> UpdateClient(int clientId, ClientDto clientDto)
        {
            if (clientId != clientDto.Id)
            {
                return BadRequest();
            }

            var client = clientDto.ToClient();
            await _clientService.UpdateClient(client);

            return NoContent();
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteClient(int clientId)
        {
            await _clientService.DeleteClient(clientId);
            return NoContent();
        }
    }
}
