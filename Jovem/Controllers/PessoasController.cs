using Jovem.Banco;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jovem.Controllers
{
    [Route("/v1/{controller}")]
    public class PessoasController : Controller
    {
        public BancoJovem bancoClasse { get; set; }

        public PessoasController(BancoJovem bancoContrutor)
        {
            this.bancoClasse = bancoContrutor;
        }

        [HttpPost("create")]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            pessoa.Id = Guid.NewGuid();
            bancoClasse.Add(pessoa);
            bancoClasse.SaveChanges();
            return Ok("Inserido com sucesso");
        }

        [HttpPut("update")]
        public IActionResult Put([FromBody] Pessoa pessoa)
        {
            bancoClasse.Update(pessoa);
            bancoClasse.SaveChanges();
            return Ok("Inserido com sucesso");
        }

        [HttpDelete("delete")]
        public IActionResult Delete(string email)
        {
            var pessoa = bancoClasse.Pessoa.FirstOrDefault(x=> x.Email.Equals(email));
            if(pessoa == null)
            {
                return BadRequest("REgistro não existe");
            }

            bancoClasse.Entry(pessoa).State = EntityState.Deleted;
            bancoClasse.SaveChanges();
            return Ok("Inserido com sucesso");
        }

        [HttpGet("consult")]
        public IActionResult Get(string email)
        {
            var pessoa = bancoClasse.Pessoa.FirstOrDefault(x => x.Email.Equals(email));
            if (pessoa == null)
            {
                return BadRequest("REgistro não existe");
            }
            return Ok(pessoa);
        }

        [HttpGet("select")]
        public IActionResult Get()
        {
            var pessoa = bancoClasse.Pessoa.ToList();
            return Ok(pessoa);
        }
    }
}
