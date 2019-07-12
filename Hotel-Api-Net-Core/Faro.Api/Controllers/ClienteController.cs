namespace Faro.Api.Controllers
{
    public class ClienteController
    {
        [Route("api/[controller]")]
        [ApiController]

        public class ClienteController: ControllerBase
        {
            private IClienteService clienteService;
            public PacienteController(IClienteService clienteService)
            {
                this.clienteService = clienteService;
            }
            [HttpGet]
            public ActionResult Get()
            {
                return Ok(clienteService.GetAll());
            }
            [HttpPost]
            public ActionResult Post([FromBody] Cliente cliente)
            {
                return Ok(clienteService.Save(cliente));
            }
            [HttpPut]
            public ActionResult Put([FromBody] Cliente cliente)
            {
                return Ok(clienteService.Update(cliente));
            }
            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
                return Ok(pacienteService.Delete(id));
            }
        }   
    }
}