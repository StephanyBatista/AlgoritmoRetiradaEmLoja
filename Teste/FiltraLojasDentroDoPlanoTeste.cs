using System.Collections.Generic;
using ExpectedObjects;
using RetiradaEmLoja;
using Xunit;

namespace Teste
{
    public class FiltraLojasDentroDoPlanoTeste
    {
        private readonly FiltraLojasDentroDoPlano _filtraLojasDentroDoPlano;

        public FiltraLojasDentroDoPlanoTeste()
        {
            _filtraLojasDentroDoPlano = new FiltraLojasDentroDoPlano();
        }

        [Fact]
        public void DeveFiltrarLojasQueEstejamDentroDoPlano()
        {
            var plano = new[] {100, 100};
            var localizacaoDasLojas = new[] { new []{101, 100}, new[] { 20, 20}, new[] { 30, 101}};
            var lojasEsperadas = new List<LocalizacaoDaLoja> { new LocalizacaoDaLoja(20, 20) };

            var localizacaoDasLojasFiltradas = _filtraLojasDentroDoPlano.Filtrar(plano, localizacaoDasLojas);

            lojasEsperadas.ToExpectedObject().ShouldMatch(localizacaoDasLojasFiltradas);
        }
    }
}
