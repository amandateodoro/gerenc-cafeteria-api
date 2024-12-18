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
                    .Include(e => e.Produto)
                    .Select(e => new
                    {
                        e.Id,
                        e.Data,
                        e.Hora,
                        e.QuantidadeProd,
                        e.ValorTotal,
                        Produto = new { e.Produto.Id, e.Produto.Nome, e.Produto.Descicao, e.Produto.ValorUn, e.Produto.QuantidadeEst, e.Produto.DataValidade },
                        Colaborador = new { e.Colaborador.Id, e.Colaborador.Nome, e.Colaborador.Contato, e.Colaborador.Cargo, e.Colaborador.Permissoes, e.Colaborador.UsuarioColaborador, e.Colaborador.SenhaColaborador }

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

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, [FromBody] VendaDto item)
        //{
        //    try
        //    {
        //        var venda = await _context.Vendas.FindAsync(id);

        //        if (venda is null)
        //        {
        //            return NotFound();
        //        }

        //        venda.Data = item.DataVenda;
        //        venda.Hora = item.HoraVenda;
        //        venda.QuantidadeProd = item.QuantidadeProduto;
        //        venda.ValorTotal = item.ValorTotal;


        //        _context.Colaboradores.Update(venda);
        //        await _context.SaveChangesAsync();

        //        return Ok(venda);
        //    }
        //    catch (Exception e)
        //    {
        //        return Problem(e.Message);
        //    }
        //}

        [HttpDelete("{id}")]
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
        }

    }
}

