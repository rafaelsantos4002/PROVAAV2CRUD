using Dominio.Entidades;
using Dominio.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Historia.Veiculos
{
    public class ConsultarVeiculo
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public ConsultarVeiculo(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<Veiculo> BuscarPorId(int id)
        {
            return await _veiculoRepository.BuscarPorId(id);
        }

        public async Task<IEnumerable<Veiculo>> ListarTodosVeiculos()
        {
            return await _veiculoRepository.ListarTodosVeiculos();
        }
        public async Task<IEnumerable<Veiculo>> PesquisarMarca(string marca)
        {
            return await _veiculoRepository.PesquisarMarca(marca);
        }

        public async Task<IEnumerable<Veiculo>> PesquisarModelo(string modelo)
        {
            return await _veiculoRepository.PesquisarModelo(modelo);
        }
    }
}