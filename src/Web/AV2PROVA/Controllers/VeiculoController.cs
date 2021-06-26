using Dominio.IRepositories;
using Historia.Veiculos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AV2PROVA.Factories;
using AV2PROVA.Models;

namespace AV2PROVA.Controllers
{
    public class VeiculoController : Controller
    {

        private readonly CriarVeiculo _criarVeiculo;
        private readonly AlterarVeiculo _alterarVeiculo;
        private readonly ConsultarVeiculo _consultarVeiculo;
        private readonly ExcluirVeiculo _excluirVeiculo;

        public VeiculoController(IVeiculoRepository veiculoRepository)
        {
            _criarVeiculo = new CriarVeiculo(veiculoRepository);
            _alterarVeiculo = new AlterarVeiculo(veiculoRepository);
            _consultarVeiculo = new ConsultarVeiculo(veiculoRepository);
            _excluirVeiculo = new ExcluirVeiculo(veiculoRepository);

        }

        public async Task<IActionResult> Index()
        {
            var ListaVeiculos = await _consultarVeiculo.ListarTodosVeiculos();
            var ListarVeiculosViewModel = VeiculoFactory.MapearListaVeiculoViewModel(ListaVeiculos);

            return View(ListarVeiculosViewModel);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(VeiculoViewModel veiculoViewModel)
        {
            if (ModelState.IsValid)
            {
                var veiculo = VeiculoFactory.MapearVeiculo(veiculoViewModel);

                await _criarVeiculo.Executar(veiculo);

                return RedirectToAction("Index");
            }

            return View(veiculoViewModel);
        }
        public async Task<IActionResult> Alterar(int id)
        {
            var veiculo = await _consultarVeiculo.BuscarPorId(id);

            if (veiculo == null)
            {
                return RedirectToAction("Index");
            }

            var autorViewModel = VeiculoFactory.MapearVeiculoViewModel(veiculo);

            return View(autorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, VeiculoViewModel veiculoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(veiculoViewModel);
            }

            var autor = VeiculoFactory.MapearVeiculo(veiculoViewModel);

            await _alterarVeiculo.Executar(id, autor);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detalhar(int id)
        {
            var veiculo = await _consultarVeiculo.BuscarPorId(id);

            if (veiculo == null)
            {
                return RedirectToAction("Index");
            }

            var autorViewModel = VeiculoFactory.MapearVeiculoViewModel(veiculo);

            return View(autorViewModel);
        }

        public async Task<IActionResult> Excluir(int id)
        {
            var veiculo = await _consultarVeiculo.BuscarPorId(id);

            if (veiculo == null)
            {
                return RedirectToAction("Index");
            }


            await _excluirVeiculo.Executar(veiculo);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> PesquisarMarca(string marca)
        {
            var marcasVeiculo = await _consultarVeiculo.PesquisarMarca(marca);
            var listarMarcaVeiculo = VeiculoFactory.MapearListaVeiculoViewModel(marcasVeiculo);

            return View(listarMarcaVeiculo);
        }

        [HttpPost]
        public async Task<IActionResult> PesquisarModelo(string modelo)
        {
            var modelosVeiculo = await _consultarVeiculo.PesquisarModelo(modelo);
            var listarModeloVeiculo = VeiculoFactory.MapearListaVeiculoViewModel(modelosVeiculo);

            return View(listarModeloVeiculo);
        }

    }
}
