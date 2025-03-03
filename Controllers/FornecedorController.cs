using CafeManiaApi.DataContexts;
using CafeManiaApi.Dtos;
using CafeManiaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeManiaApi.Controllers
{
    [ApiController]
    [Route("fornecedores")]

    public class FornecedorController : Controller
    {
        private readonly AppDbContext _context;

        public FornecedorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaFornecedores = await _context.Fornecedores.ToListAsync();

                return Ok(listaFornecedores);
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
                var fornecedor = await _context.Fornecedores.Where(s => s.Id == id).FirstOrDefaultAsync();

                if (fornecedor == null)
                {
                    return NotFound($"Fornecedor #{id} não encontrado");
                }

                return Ok(fornecedor);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FornecedorDto item)
        {
            try
            {

                var fornecedores = new Fornecedor()
                {
                    Nome = item.Nome,
                    Contato = item.Contato,
                    Endereco = item.Contato
                };

                await _context.Fornecedores.AddAsync(fornecedores);
                await _context.SaveChangesAsync();

                return Created("", fornecedores);
            }
            catch (Exception e)
            {
                return Problem();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FornecedorDto item)
        {
            try
            {
                var fornecedor = await _context.Fornecedores.FindAsync(id);

                if (fornecedor is null)
                {
                    return NotFound();
                }

                fornecedor.Nome = item.Nome;
                fornecedor.Contato = item.Contato;
                fornecedor.Endereco = item.Contato;

                _context.Fornecedores.Update(fornecedor);
                await _context.SaveChangesAsync();

                return Ok(fornecedor);
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
                var fornecedor = await _context.Fornecedores.FindAsync(id);

                if (fornecedor is null)
                {
                    return NotFound();
                }

                _context.Fornecedores.Remove(fornecedor);
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