using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScreenSound3.Database;
using ScreenSound3.Models;

namespace ScreenSound3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenController : ControllerBase
    {
        private readonly AlbumDao _screenDao;

        public ScreenController(AlbumDao screenDao)
        {
            _screenDao = screenDao;
        }

        [HttpPost]
        public void AdicionarAlbum([FromBody] Album album)
        {
           _screenDao.CadastrarAlbum(album);
        }
        

        [HttpGet]
        public List<Album> PegarTudo() 
        {
        return _screenDao.PegarTudo();
        }


        [HttpDelete("{id:int}")]
        public void DeletarAlbum([FromBody] int id)
        {
            _screenDao.DeletarAlbum(id);
        }


        [HttpPut]
        public void AtualizarAlbum([FromBody] Album album)
        {
            _screenDao.AtualizarAlbum(album);
        }
        



    }
}
