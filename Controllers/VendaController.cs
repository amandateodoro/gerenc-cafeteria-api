using CafeManiaApi.DataContexts;
using CafeManiaApi.Dtos;
using CafeManiaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeManiaApi.Controllers
{
    [ApiController]
    [Route("vendas")]

    public class VendaController : Controller
    {
        private readonly AppDbContext _context;

        public VendaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaVendas = await _context.Vendas
                    .Include(v => v.ItensVenda)
                    .Include(v => v.Colaboradores)
                    .Include(v => v.RelatorioVendas) 
                    .Select(v => new
                    {
                        v.Id,
                        v.DataHora,
                        v.FormaPagamento,
                        v.ValorTotal,
                        RelatorioVenda = new { v.RelatorioVendas.Id, v.RelatorioVendas.DataHora, v.RelatorioVendas.Dados },
                        Colaborador = new { v.Colaboradores.Id, v.Colaboradores.Nome, v.Colaboradores.Contato, v.Colaboradores.Cargo, v.Colaboradores.Permissoes, v.Colaboradores.UsuarioColaborador, v.Colaboradores.SenhaColaborador },
                        Produtos = v.ItensVenda.Select(iv => new
                        {
                            iv.Produto.Id,
                            iv.Produto.Nome,
                            iv.Produto.Descricao,
                            iv.Produto.ValorUn,
                            iv.Quantidade,
                            iv.PrecoUnitario
                        })
                    })
                    .ToListAsync();

                return Ok(listaVendas);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var venda = await _context.Vendas.Where(s => s.Id == id).FirstOrDefaultAsync();

                if (venda == null)
                {
                    return NotFound($"Venda #{id} não encontrada");
                }

                return Ok(venda);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VendaDto vendaDto)
        {
            try
            {
                var colaborador = await _context.Colaboradores.FindAsync(vendaDto.ColaboradorId);
                if (colaborador == null)
                {
                    return NotFound($"Colaborador com ID {vendaDto.ColaboradorId} não encontrado.");
                }

                var venda = new Venda
                {
                    DataHora = vendaDto.DataHoraVenda,
                    FormaPagamento = vendaDto.FormaPagamento,
                    ValorTotal = vendaDto.ValorTotal,
                    ColaboradorId = vendaDto.ColaboradorId,
                    ItensVenda = new List<ItemVenda>()
                };

                foreach (var itemDto in vendaDto.ItensVenda)
                {
                    var produto = await _context.Produtos.FindAsync(itemDto.ProdutoId);
                    if (produto == null)
                    {
                        return NotFound($"Produto com ID {itemDto.ProdutoId} não encontrado.");
                    }

                    var itemVenda = new ItemVenda
                    {
                        ProdutoId = itemDto.ProdutoId,
                        Quantidade = itemDto.Quantidade,
                        PrecoUnitario = itemDto.PrecoUnitario,
                        
                    };

                    venda.ItensVenda.Add(itemVenda);
                }

                await _context.Vendas.AddAsync(venda);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = venda.Id }, venda);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // "PUT/vendas/{id}" ATUALIZA UMA VENDA EXISTENTE (NÃO É NECESSÁRIO NO CONTEXTO ATUAL)

        /*[HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VendaDto item)
        {
            try
            {
                var venda = await _context.Vendas.FindAsync(id);

                if (venda is null)
                {
                    return NotFound();
                }

                venda.Data = item.DataVenda;
                venda.Hora = item.HoraVenda;
                venda.QuantidadeProd = item.QuantidadeProduto;
                venda.ValorTotal = item.ValorTotal;


                _context.Colaboradores.Update(venda);
                await _context.SaveChangesAsync();

                return Ok(venda);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }*/


        // "DELETE/vendas/{id}" DELETA UMA VENDA EXISTENTE (NÃO É NECESSÁRIO NO CONTEXTO ATUAL)
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var venda = await _context.Vendas.FindAsync(id);

                if (venda is null)
                {
                    return NotFound();
                }

                _context.Vendas.Remove(venda);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }*/

    }
}

