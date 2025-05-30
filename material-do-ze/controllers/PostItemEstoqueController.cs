using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/itemestoque")]
public class PostItemEstoqueController : ControllerBase
{
    private readonly AppDbContext _context;

    public PostItemEstoqueController(AppDbContext context)
    {
        _context = context;
    }

    // POST: api/itemestoque
    [HttpPost]
    public async Task<IActionResult> Adicionar(ItemEstoque item)
    {
        _context.ItensEstoque.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPorId", new { id = item.Id }, item);
    }
}
