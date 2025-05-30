using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/itemestoque")]
public class PutItemEstoqueController : ControllerBase
{
    private readonly AppDbContext _context;

    public PutItemEstoqueController(AppDbContext context)
    {
        _context = context;
    }

    // putHttpPut: api/itemestoque/{id}/baixar
    [HttpPut("{id}/baixar")]
    public async Task<IActionResult> BaixarEstoque(int id, [FromBody] BaixaEstoqueDto dto)
    {
        var item = await _context.ItensEstoque.FindAsync(id);
        if (item == null)
            return NotFound(new { erro = "Item não encontrado." });

        if (dto.Quantidade <= 0)
            return BadRequest(new { erro = "Quantidade deve ser maior que zero." });

        if (item.Quantidade < dto.Quantidade)
            return BadRequest(new { erro = "Quantidade insuficiente no estoque." });

        item.Quantidade -= dto.Quantidade;
        await _context.SaveChangesAsync();

        var resposta = new { mensagem = "Baixa realizada com sucesso.", quantidadeAtual = item.Quantidade };
        return Ok(resposta);
    }

    // putHttpPut: api/itemestoque/{id}/repor
    [HttpPut("{id}/repor")]
    public async Task<IActionResult> ReporEstoque(int id, [FromBody] ReporEstoqueDto dto)
    {
        var item = await _context.ItensEstoque.FindAsync(id);
        if (item == null)
            return NotFound(new { erro = "Item não encontrado." });

        if (dto.Quantidade <= 0)
            return BadRequest(new { erro = "Quantidade deve ser maior que zero." });

        item.Quantidade += dto.Quantidade;
        await _context.SaveChangesAsync();

        return Ok(new { mensagem = "Reposição realizada com sucesso.", quantidadeAtual = item.Quantidade });
    }
}
