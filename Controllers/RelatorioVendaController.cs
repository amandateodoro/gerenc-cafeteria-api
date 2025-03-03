using CafeManiaApi.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeManiaApi.Controllers
{
    [ApiController]
    [Route("relatorios")]
    public class RelatorioVendaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RelatorioVendaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("vendas/{tipo}")]
        public async Task<IActionResult> GetRelatorio(string tipo)
        {
            DateTime dataInicial = tipo.ToLower() switch
            {
                "diario" => DateTime.Today,
                "semanal" => DateTime.Today.AddDays(-7),
                "mensal" => DateTime.Today.AddMonths(-1),
                _ => throw new ArgumentException("Tipo de relatório inválido. Use: diario, semanal ou mensal.")
            };

            var relatorio = await _context.Vendas
                .Where(v => v.DataHora >= dataInicial)
                .Include(v => v.Colaboradores)
                .Include(v => v.ItensVenda)
                .ThenInclude(iv => iv.Produto)
                .Select(v => new
                {
                    v.Id,
                    DataHoraVenda = v.DataHora,
                    v.ValorTotal,
                    Colaborador = new { v.Colaboradores.Id, v.Colaboradores.Nome },
                    Itens = v.ItensVenda.Select(i => new
                    {
                        i.ProdutoId,
                        ProdutoNome = i.Produto.Nome,
                        i.Quantidade,
                        i.PrecoUnitario
                    })
                })
                .ToListAsync();

            return Ok(relatorio);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRelatorioById(int id)
        {
            var relatorio = await _context.Relatorios
                .Include(r => r.Vendas)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (relatorio == null)
            {
                return NotFound($"Relatório {id} não encontrado.");
            }

            return Ok(relatorio);
        }
    }
}