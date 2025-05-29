public class ItemEstoque
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required string Tipo { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
}
