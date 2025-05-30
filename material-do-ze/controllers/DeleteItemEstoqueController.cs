using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/itemestoque")]
public class DeleteItemEstoqueController : ControllerBase
{
    private readonly AppDbContext _context;

    public DeleteItemEstoqueController(AppDbContext context)
    {
        _context = context;
    }

    // DELETE: api/itemestoque/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var item = await _context.ItensEstoque.FindAsync(id);
        if (item == null)
            return NotFound(new { erro = "Item não encontrado." });

        _context.ItensEstoque.Remove(item);
        await _context.SaveChangesAsync();

        return Ok(new { mensagem = "Item removido com sucesso." });
    }
}
