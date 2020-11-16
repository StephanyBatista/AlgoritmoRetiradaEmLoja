using System.Collections.Generic;
using System.Linq;

namespace RetiradaEmLoja
{
    public class FiltraLojasDentroDoPlano
    {
        public List<LocalizacaoDaLoja> Filtrar(int[] plano, int[][] localizacaoDasLojas)
        {
            return localizacaoDasLojas.Where(item => item[0] >= 0 && item[0] <= plano[0] && item[1] >= 0 && item[1] <= plano[1])
                .Select(item => new LocalizacaoDaLoja(item[0], item[1]))
                .ToList();
        }
    }
}
