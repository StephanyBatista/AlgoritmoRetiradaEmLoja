using System;
using System.Collections.Generic;
using System.Linq;

namespace RetiradaEmLoja
{
    public class BuscaLojasProximas
    {
        private readonly FiltraLojasDentroDoPlano _filtraLojasDentroDoPlano;

        public BuscaLojasProximas(FiltraLojasDentroDoPlano filtraLojasDentroDoPlano)
        {
            _filtraLojasDentroDoPlano = filtraLojasDentroDoPlano;
        }

        public List<LocalizacaoDaLoja> Buscar(int[] plano, int[] localizacaoDoCliente, int[][] localizacaoDasLojas)
        {
            ValidarParametros(plano, localizacaoDoCliente);

            var lojasFiltradas = _filtraLojasDentroDoPlano.Filtrar(plano, localizacaoDasLojas);

            foreach (var loja in lojasFiltradas)
                loja.Calcular(localizacaoDoCliente[0], localizacaoDoCliente[1]);

            return lojasFiltradas.OrderBy(loja => loja.AproximacaoEmRelacaoAoCliente).Take(3).ToList();
        }

        private static void ValidarParametros(int[] plano, int[] localizacaoDoCliente)
        {
            if (plano[0] < 0 || plano[0] > 1000 || plano[1] < 0 || plano[1] > 1000)
                throw new Exception("Tamanho do plano inválido. Plano deve ser 0 ≤ M ≤ 1000 e 0 ≤ N ≤ 1000");

            if (localizacaoDoCliente[0] < 0 || localizacaoDoCliente[0] > plano[0] || 
                localizacaoDoCliente[1] < 0 || localizacaoDoCliente[1] > plano[1])
                throw new Exception("Localização do cliente inválida. Localização deve ser 0 ≤ X ≤ M e 0 ≤ Y ≤ N");
        }
    }
}