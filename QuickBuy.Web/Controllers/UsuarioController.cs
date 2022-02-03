
using Microsoft.AspNetCore.Mvc;
using Quickbuy.Dominio.Contratos;
using Quickbuy.Dominio.Entidade;
using System;

namespace QuickBuy.Web.Controllers
{
    [Route("api/[Controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
       
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio) {
            _usuarioRepositorio = usuarioRepositorio;
             
        }

        [HttpPost]
        public ActionResult Post([FromBody]Usuarios usuario)
        {
            try 
            {
                var usuarioCadastrado = _usuarioRepositorio.Obter(usuario.Email);
                if (usuarioCadastrado != null)
                {
                    return BadRequest("usuario já cadastrado no sistema");
                }
                else {
                    // depois tirar
                    //usuario.EhAdministrador = true;
                    _usuarioRepositorio.Adicionar(usuario);
                    return Ok();
                }
                
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost("VerificarUsuario")]
        public ActionResult VerificarUsuario ([FromBody] Usuarios usuario)
        {

            try
            {
                var usuarioRetorno = _usuarioRepositorio.Obter(usuario.Email,usuario.Senha);

                if (usuarioRetorno !=null)
                {
                    return Ok(usuarioRetorno);
                }
                else 
                {
                    return BadRequest("Usuário ou senha inválido");
                }
            }


            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        
        [HttpGet]
        public ActionResult Get()
        {

            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        

    }
}
