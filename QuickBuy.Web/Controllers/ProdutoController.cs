using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quickbuy.Dominio.Contratos;
using Quickbuy.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBuy.Web.Controllers
{   [Route("api/[Controller]")]
    public class ProdutoController:Controller
    {   //variável de contrato
        private readonly IProdutoRepository _produtoRepositorio;

        private IHttpContextAccessor _httpContextAccessor;

        private IHostingEnvironment _hostingEnviroment;

        public ProdutoController(IProdutoRepository produtoRepositorio
            ,IHttpContextAccessor httpContextAccessor, IHostingEnvironment hostingEnviroment) 
        {
            _produtoRepositorio = produtoRepositorio;
            _httpContextAccessor = httpContextAccessor;
            //serve para obter informações na pasta raíz onde o site está sendo executado.
            _hostingEnviroment = hostingEnviroment;

        }

        [HttpGet]
        public IActionResult Get() 
        {

            try
            {
                return Json(_produtoRepositorio.ObterTodos());
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto) 
        {
            try
            {
                produto.Validate();
                if (!produto.EhValido) 
                {
                    return BadRequest(produto.ObterMensagensValidacao());
                }
                if (produto.Id > 0)
                {
                    _produtoRepositorio.Atualizar(produto);
                }
                else 
                {
                    _produtoRepositorio.Adicionar(produto);
                }
                
                return Created("api/produto",produto); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }


        [HttpPost("deletar")]
        public IActionResult Deletar([FromBody] Produto produto)
        {
            try
            {
                //produto recebido do from body deve ter a propriedade id >0
                _produtoRepositorio.Remover(produto);
                return Json(_produtoRepositorio.ObterTodos());
             
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }




        [HttpPost("EnviarArquivo")]
        public IActionResult EnviarArquivo() {

            try
            {
                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];
                var nomeArquivo = formFile.FileName;
                //pegar a ultima posição do arquivo
                var extensao = nomeArquivo.Split(".").Last();
                //pegar simplesmente 10 caracteres de nome do arquivo
                string novoNomeArquivo = GerarNovoNomeArquivo(nomeArquivo, extensao); var pastaArquivos = _hostingEnviroment.WebRootPath + "\\arquivos\\";
                var nomeCompleto = pastaArquivos + novoNomeArquivo;
                using (var streamArquivo = new FileStream(nomeCompleto, FileMode.Create))
                {
                    formFile.CopyTo(streamArquivo);
                }
                return Json(novoNomeArquivo);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.ToString());
            }
        }

        private static string GerarNovoNomeArquivo(string nomeArquivo, string extensao)
        {
            var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();
            var novoNomeArquivo = new string(arrayNomeCompacto).Replace(" ", "-");
            novoNomeArquivo = $"{novoNomeArquivo}_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.{extensao}";
            return novoNomeArquivo;
        }
    }
}
