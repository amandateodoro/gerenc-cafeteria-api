using CafeManiaApi.DataContexts;
using CafeManiaApi.Dtos;
using CafeManiaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeManiaApi.Controllers
{
    [ApiController]
    [Route("produtos")]

    public class ProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaProdutos = await _context.Produtos.ToListAsync();

                return Ok(listaProdutos);
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
                var produto = await _context.Produtos.FindAsync(id);

                if (produto == null)
                {
                    return NotFound($"Produto #{id} não encontrado");
                }

                return Ok(produto);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoDto item)
        {
            try
            {

                var produtos = new Produto()
                {
                    Nome = item.Nome,
                    Descricao = item.Descricao,
                    ValorUn = item.ValorUn,
                    QuantidadeEstoque = item.QuantidadeEstoque,
                    DataValidade = item.DataValidade
                };

                await _context.Produtos.AddAsync(produtos);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = produtos.Id }, produtos);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProdutoDto item)
        {
            try
            {
                var produto = await _context.Produtos.FindAsync(id);

                if (produto is null)
                {
                    return NotFound();
                }

                produto.Nome = item.Nome;
                produto.Descricao = item.Descricao;
                produto.ValorUn = item.ValorUn;
                produto.QuantidadeEstoque = item.QuantidadeEstoque;
                produto.DataValidade = item.DataValidade;

                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();

                return Ok(produto);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var produto = await _context.Produtos.FindAsync(id);

                if (produto is null)
                {
                    return NotFound();
                }

                _context.Produtos.Remove(produto);
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