using System.Linq;
using RetiradaEmLoja;
using Xunit;

namespace Teste
{
    public class BuscaLojasProximasTeste
    {
        private readonly BuscaLojasProximas _buscaLojasProximas;

        public BuscaLojasProximasTeste()
        {
            _buscaLojasProximas = new BuscaLojasProximas(new FiltraLojasDentroDoPlano());
        }
        
        [Theory]
        [InlineData(1001, 1000)]
        [InlineData(-1, 1000)]
        [InlineData(1000, 1001)]
        [InlineData(1000, -1)]
        public void DeveValidarTamanhoDoPlano(int m, int n)
        {
            const string mensagemEsperada = "Tamanho do plano inválido. Plano deve ser 0 ≤ M ≤ 1000 e 0 ≤ N ≤ 1000";
            var planoInvalido = new [] {m, n};
            
            AssertExtensions.ThrowsWithMessage(() => _buscaLojasProximas.Buscar(planoInvalido, null, null), mensagemEsperada);
        }

        [Theory]
        [InlineData(101, 100)]
        [InlineData(-1, 100)]
        [InlineData(100, 101)]
        [InlineData(100, -1)]
        public void DeveValidarLocalizacaoDoCliente(int x, int y)
        {
            const string mensagemEsperada = "Localização do cliente inválida. Localização deve ser 0 ≤ X ≤ M e 0 ≤ Y ≤ N";
            var localizacaoDoClienteInvalida = new[] {x, y};
            var tamanhoDoPlano = new[] { 100, 100 };

            AssertExtensions.ThrowsWithMessage(() => _buscaLojasProximas.Buscar(tamanhoDoPlano, localizacaoDoClienteInvalida, null), mensagemEsperada);
        }

        [Fact]
        public void DeveRetornarAs3LojasMaisProximas()
        {
            var tamanhoDoPlano = new[] { 100, 100 };
            var localizacaoDoCliente = new[] { 20, 32 };
            var localizacaoDasLojas = new[] { new []{40, 88}, new[] { 18, 56}, new[] { 99, 2}, new[] { 99, 10 } };
            var treslojasMaisProximasEsperadas = new[] {24.083189157584592, 59.464274989274024, 82.006097334283623};

            var lojasMaisProximas =
                _buscaLojasProximas.Buscar(tamanhoDoPlano, localizacaoDoCliente, localizacaoDasLojas);

            Assert.Equal(treslojasMaisProximasEsperadas[0], lojasMaisProximas.ElementAt(0).AproximacaoEmRelacaoAoCliente);
            Assert.Equal(treslojasMaisProximasEsperadas[1], lojasMaisProximas.ElementAt(1).AproximacaoEmRelacaoAoCliente);
            Assert.Equal(treslojasMaisProximasEsperadas[2], lojasMaisProximas.ElementAt(2).AproximacaoEmRelacaoAoCliente);
        }
    }
}
