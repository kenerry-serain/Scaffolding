using $ApplicationInterfacesNamespace$;
using $ApplicationViewModelsNamespace$;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace $WebAPINamespace$
{
    [Route("api/[controller]")]
    [ApiController]
    public class $Entity$Controller : ControllerBase
    {
        private readonly I$Entity$ApplicationService _$lowerEntity$AppService;
        public $Entity$Controller(I$Entity$ApplicationService $lowerEntity$Appservice)
        {
            _$lowerEntity$AppService = $lowerEntity$Appservice;
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            var $lowerEntity$List = await _$lowerEntity$AppService.ReadAll();
            return Ok($lowerEntity$List);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadById([FromRoute]int id)
        {
            var $lowerEntity$List = await _$lowerEntity$AppService.ReadById(id);
            return Ok($lowerEntity$List);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]$Entity$ViewModel $lowerEntity$ViewModel)
        {
            var created$Entity$ = await _$lowerEntity$AppService.Create($lowerEntity$ViewModel);
            return Created("/{id}", created$Entity$);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]$Entity$ViewModel $lowerEntity$ViewModel)
        {
            var updated$Entity$ = await _$lowerEntity$AppService.Update($lowerEntity$ViewModel);
            return Accepted(updated$Entity$);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute]int id)
        {
            await _$lowerEntity$AppService.Remove(id);
            return Ok();
        }
    }
}