using LibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingRecordController : ControllerBase
    {
        private readonly IBorrowingRecordRepoistory _borrowingRecordRepoistory;
        public BorrowingRecordController(IBorrowingRecordRepoistory BorrowingRecordRepoistory)
        {
            _borrowingRecordRepoistory = BorrowingRecordRepoistory;
        }
        [HttpPost]
        [Route("{bookid:int}/patron/{patronid:int}")]

        public async Task<IActionResult> Borrow([FromRoute] int bookid , [FromRoute] int patronid)
        {
            var record = await _borrowingRecordRepoistory.Borrow(bookid, patronid);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
        [HttpPut]
        [Route("{bookid:int}/patron/{patronid:int}")]
        
        public async Task<IActionResult> Return([FromRoute] int bookid, [FromRoute] int patronid)
        {
            var record = await _borrowingRecordRepoistory.Return(bookid, patronid);
            return Ok(record);
        }
    }
}
