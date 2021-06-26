using System;

namespace Dominio.Entidades
{
    public class Veiculo
    {

        public Veiculo(string marca, string modelo, string ano, string quilometragem)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Quilometragem = quilometragem;
        }

        public int Id { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Ano { get; private set; }
        public string Quilometragem { get; private set; }

        public void AtualizarVeiculo(string marca, string modelo, string ano, string quilometragem)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Ano = ano;
            this.Quilometragem = quilometragem;
        }

    }
}

