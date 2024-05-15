using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatronController : ControllerBase
    {
        private readonly IPatronRepository _patronRepository;
        public PatronController(IPatronRepository patronRepository)
        {
            _patronRepository = patronRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getALL()
        {
            var patrons = await _patronRepository.GetPatrons();
            return Ok(patrons);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> getbyId([FromRoute]int id)
        {
            var patron =await  _patronRepository.GetPatronById(id);
            if (patron == null)
            {
                return NotFound();
            }
            return Ok(patron);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Patron patron)
        {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
           return Ok( await _patronRepository.Create(patron));
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromBody] Patron patron, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updated = await _patronRepository.Update(patron, id);
            return Ok(updated);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var patron = await _patronRepository.Delete(id);
            if (patron == null)
            {
                return NotFound();
            }
            return Ok(patron);
        }

    }
}
