using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/itemestoque")]
public class GetItemEstoqueController : ControllerBase
{
    private readonly AppDbContext _context;

    public GetItemEstoqueController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/itemestoque
    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        var itens = await _context.ItensEstoque.ToListAsync();
        return Ok(itens);
    }

    // GET: api/itemestoque/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPorId(int id)
    {
        var item = await _context.ItensEstoque.FindAsync(id);
        if (item == null)
            return NotFound(new { erro = "Item não encontrado." });
        return Ok(item);
    }
}
