using Dominio.Entidades;
using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AV2PROVA.Models;

namespace AV2PROVA.Factories
{
    public static class VeiculoFactory
    {
        public static VeiculoViewModel MapearVeiculoViewModel(Veiculo veiculo)
        {
            var veiculoViewModel = new VeiculoViewModel
            {

                Id = veiculo.Id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Ano = veiculo.Ano,
                Quilometragem = veiculo.Quilometragem
            };
            //Endereco pesquisar
            return veiculoViewModel;
        }
        public static Veiculo MapearVeiculo(VeiculoViewModel veiculoViewModel)
        {
            var veiculo = new Veiculo(
                veiculoViewModel.Marca,
                veiculoViewModel.Modelo,
                veiculoViewModel.Ano,
                veiculoViewModel.Quilometragem);

            return veiculo;
        }
        public static IEnumerable<VeiculoViewModel> MapearListaVeiculoViewModel(IEnumerable<Veiculo> veiculos)
        {
            var lista = new List<VeiculoViewModel>();
            foreach (var item in veiculos)
            {
                lista.Add(MapearVeiculoViewModel(item));
            }

            return lista;
        }
    }
}