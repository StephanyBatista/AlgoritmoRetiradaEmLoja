using RetiradaEmLoja;
using Xunit;

namespace Teste
{
    public class LocalizacaoDaLojaTeste
    {
        [Fact]
        public void DeveCriarLocalizacaoDaLoja()
        {
            const int pontoX = 5;
            const int pontoY = 10;

            var localizacaoDaLoja = new LocalizacaoDaLoja(pontoX, pontoY);

            Assert.Equal(pontoX, localizacaoDaLoja.PontoX);
            Assert.Equal(pontoY, localizacaoDaLoja.PontoY);
        }

        [Fact]
        public void DeveCalcularAproximacaoEmRelacaoAoCliente()
        {
            const int pontoDoClienteX = 20;
            const int pontoDoClienteY = 32;
            const double aproximacaoEsperada = 59.464274989274024;
            var localizacaoDaLoja = new LocalizacaoDaLoja(40, 88);

            localizacaoDaLoja.CalcularAproximacao(pontoDoClienteX, pontoDoClienteY);

            Assert.Equal(aproximacaoEsperada, localizacaoDaLoja.AproximacaoEmRelacaoAoCliente);
        }
    }
}
