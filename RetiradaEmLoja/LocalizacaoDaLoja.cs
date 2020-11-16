using System;

namespace RetiradaEmLoja
{
    public class LocalizacaoDaLoja
    {
        public int PontoX { get; }
        public int PontoY { get; }
        public double AproximacaoEmRelacaoAoCliente { get; private set; }

        public LocalizacaoDaLoja(int pontoX, int pontoY)
        {
            PontoX = pontoX;
            PontoY = pontoY;
        }

        public void CalcularAproximacao(in int pontoDoClienteX, in int pontoDoClienteY)
        {
            AproximacaoEmRelacaoAoCliente = Math.Sqrt(Math.Pow(pontoDoClienteX - PontoX, 2) + Math.Pow(pontoDoClienteY - PontoY, 2));
        }
    }
}
