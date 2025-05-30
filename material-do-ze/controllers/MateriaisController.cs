// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// [ApiController]
// [Route("api/[controller]")]
// public class ItemEstoqueController : ControllerBase
// {
//     private readonly AppDbContext _context;

//     public ItemEstoqueController(AppDbContext context)
//     {
//         _context = context;
//     }

//     // GET: api/itemestoque
//     [HttpGet]
//     public async Task<IActionResult> GetTodos()
//     {
//         var itens = await _context.ItensEstoque.ToListAsync();
//         return Ok(itens);
//     }

//     // GET: api/itemestoque/{id}
//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetPorId(int id)
//     {
//         var item = await _context.ItensEstoque.FindAsync(id);

//         if (item == null)
//         {
//             return NotFound(new { erro = "Item não encontrado." });
//         }

//         return Ok(item);
//     }

//     // POST: api/itemestoque
//     [HttpPost]
//     public async Task<IActionResult> Adicionar(ItemEstoque item)
//     {
//         _context.ItensEstoque.Add(item);
//         await _context.SaveChangesAsync();

//         return CreatedAtAction(nameof(GetPorId), new { id = item.Id }, item);
//     }

//     // DELETE: api/itemestoque/{id}
//     [HttpDelete("{id}")]
//     public async Task<IActionResult> Deletar(int id)
//     {
//         var item = await _context.ItensEstoque.FindAsync(id);

//         if (item == null)
//         {
//             return NotFound(new { erro = "Item não encontrado." });
//         }

//         _context.ItensEstoque.Remove(item);
//         await _context.SaveChangesAsync();

//         return Ok(new { mensagem = "Item removido com sucesso." });
//     }

//     // putHttpPut: api/itemestoque/{id}/baixar
//     [HttpPut("{id}/baixar")]
//     public async Task<IActionResult> BaixarEstoque(int id, [FromBody] BaixaEstoqueDto dto)
//     {
//         var item = await _context.ItensEstoque.FindAsync(id);

//         if (item == null)
//         {
//             return NotFound(new { erro = "Item não encontrado." });
//         }

//         if (dto.Quantidade <= 0)
//         {
//             return BadRequest(new { erro = "Quantidade deve ser maior que zero." });
//         }

//         if (item.Quantidade < dto.Quantidade)
//         {
//             return BadRequest(new { erro = "Quantidade insuficiente no estoque." });
//         }

//         item.Quantidade -= dto.Quantidade;

//         await _context.SaveChangesAsync();

//         var resposta = new
//         {
//             mensagem = "Saída realizada com sucesso.",
//             quantidadeAtual = item.Quantidade
//         };

//         if (item.Quantidade < 10)
//         {
//             return Ok(new
//             {
//                 resposta.mensagem,
//                 resposta.quantidadeAtual,
//                 aviso = "Estoque baixo! Considere repor."
//             });
//         }

//         return Ok(resposta);
//     }
    
//     // putHttpPut: api/itemestoque/{id}/repor
// [HttpPut("{id}/repor")]
// public async Task<IActionResult> ReporEstoque(int id, [FromBody] ReporEstoqueDto dto)
// {
//     var item = await _context.ItensEstoque.FindAsync(id);

//     if (item == null)
//     {
//         return NotFound(new { erro = "Item não encontrado." });
//     }

//     if (dto.Quantidade <= 0)
//     {
//         return BadRequest(new { erro = "Quantidade deve ser maior que zero." });
//     }

//     item.Quantidade += dto.Quantidade;

//     await _context.SaveChangesAsync();

//     return Ok(new
//     {
//         mensagem = "Reposição realizada com sucesso.",
//         quantidadeAtual = item.Quantidade
//     });
// }

// }
