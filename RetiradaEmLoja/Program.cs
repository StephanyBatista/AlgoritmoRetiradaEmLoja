using System;

namespace RetiradaEmLoja
{
    class Program
    {
        static void Main(string[] args)
        {
            var tamanhoDoPlano = new[] { 100, 100 };
            var localizacaoDoCliente = new[] { 20, 32 };
            var localizacaoDasLojas = new[] { new[] { 40, 88 }, new[] { 18, 56 }, new[] { 99, 2 }, new[] { 99, 10 } };

            var buscaLojasProximas = new BuscaLojasProximas(new FiltraLojasDentroDoPlano());
            var lojasRetornadas = buscaLojasProximas.Buscar(tamanhoDoPlano, localizacaoDoCliente, localizacaoDasLojas);

            foreach (var loja in lojasRetornadas)
            {
                Console.WriteLine($"[{loja.PontoX}, {loja.PontoY}]");
            }
        }
    }
}
