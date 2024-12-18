using CafeManiaApi.DataContexts;
using CafeManiaApi.Dtos;
using CafeManiaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeManiaApi.Controllers
{
    [ApiController]
    [Route("colaboradores")]

    public class ColaboradorController : Controller
    {
        private readonly AppDbContext _context;

        public ColaboradorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaColaboradores = await _context.Colaboradores.ToListAsync();

                return Ok(listaColaboradores);
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
                var colaborador = await _context.Colaboradores.Where(s => s.Id == id).FirstOrDefaultAsync();

                if (colaborador == null)
                {
                    return NotFound($"Colaborador #{id} não encontrado");
                }

                return Ok(colaborador);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ColaboradorDto item)
        {
            try
            {
                var colaborador = await _context.Colaboradores.FindAsync(id);

                if (colaborador is null)
                {
                    return NotFound();
                }

                colaborador.Nome = item.Nome;
                colaborador.Contato = item.Contato;
                colaborador.Cargo = item.Cargo;
                colaborador.Permissoes = item.Permissoes;
                colaborador.UsuarioColaborador = item.UsuarioColaborador;
                colaborador.SenhaColaborador = item.SenhaColaborador;

                _context.Colaboradores.Update(colaborador);
                await _context.SaveChangesAsync();

                return Ok(colaborador);
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
                var colaborador = await _context.Colaboradores.FindAsync(id);

                if (colaborador is null)
                {
                    return NotFound();
                }

                _context.Colaboradores.Remove(colaborador);
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

//try
//{
//    var listaServidores = await _context.Servidores
//        .Include(e => e.Campus)
//        .Select(e => new {
//            e.Id,
//            e.CPF,
//            e.Nome,
//            e.Siape,
//            Campus = new { e.Campus.Id, e.Campus.Nome }
//        })
//        .ToListAsync();

//    return Ok(listaServidores);
//}
//catch (Exception e)
//{
//    return Problem(e.Message);
//}
