using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScreenSound3.Database;
using ScreenSound3.Models;

namespace ScreenSound3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicasController : ControllerBase
    {
        private readonly MusicasDao _musicasDao;

        public MusicasController(MusicasDao musicasDao)
        {
            _musicasDao = musicasDao;
        }

        [HttpPost]
        public void AdicionarMusica([FromBody] Musicas musicas) {
            _musicasDao.CadastrarMusica(musicas);
        }


        [HttpGet]
        public List<Musicas> PegarMusicas()
        {
            return _musicasDao.PegarMusicas();
        }

        [HttpDelete("{id:int}")]
        public void DeletarMusicas([FromBody] int id)
        {
            _musicasDao.DeletarMusicas(id);
        }


        [HttpPut]
        public void AtualizarMusicas([FromBody]Musicas musicas)
        {
            _musicasDao.AtualizarMusicas(musicas);
        }
    }
}
