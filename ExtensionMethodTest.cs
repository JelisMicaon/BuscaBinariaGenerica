using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitaryTests
{
    public class ExtensionMethodTest
    {
        [Fact(DisplayName = "Verificar retorno vazio de lista sem dados")]
        public void VerificarRetornoVazioSemDados()
            => Assert.Null(StaticsClass.ReturnListEmpty().BinarySearch<InfoList>("Id", 123, false));

        [Fact(DisplayName = "Verificar retorno vazio de lista com dados")]
        public void VerificarRetornoVazioComDados()
            => Assert.Null(StaticsClass.ReturnListInfo().BinarySearch<InfoList>("Id", 999, true));

        [Fact(DisplayName = "Verificar retorno item de lista com dados")]
        public void VerificarRetornoItemComDados()
            => Assert.NotNull(StaticsClass.ReturnListInfo().BinarySearch<InfoList>("Id", 123, true));

        [Fact(DisplayName = "Verificar retorno vazio de lista sem dados e propriedade inexistente")]
        public void VerificarRetornoPropriedadeInexistenteComDados()
            => Assert.Null(StaticsClass.ReturnListEmpty().BinarySearch<InfoList>("Name", 123, false));

        [Fact(DisplayName = "Verificar retorno vazio de lista com dados e propriedade inexistente")]
        public void VerificarRetornoPropriedadeInexistenteSemDados()
            => Assert.Null(StaticsClass.ReturnListInfo().BinarySearch<InfoList>("Name", 123, true));

        [Fact(DisplayName = "Verificar retorno de lista ordenada por propriedade sem dados")]
        public void VerificarRetornoListaOrdenadaSemDados()
            => Assert.NotNull(StaticsClass.ReturnListEmpty().ListOrderByProperty<InfoList>("Id"));

        [Fact(DisplayName = "Verificar retorno de lista ordenada por propriedade sem dados e propriedade inexistente")]
        public void VerificarRetornoListaOrdenadaPropriedadeInexistenteSemDados()
            => Assert.Null(StaticsClass.ReturnListEmpty().ListOrderByProperty<InfoList>("Name"));

        [Fact(DisplayName = "Verificar retorno de lista ordenada por propriedade com dados e propriedade inexistente")]
        public void VerificarRetornoListaOrdenadaPropriedadeInexistenteComDados()
            => Assert.Null(StaticsClass.ReturnListInfo().ListOrderByProperty<InfoList>("Name"));

        [Fact(DisplayName = "Verificar retorno de lista ordenada por propriedade com dados")]
        public void VerificarRetornoListaOrdenadaComDados()
        {
            List<InfoList> listaRegistros = StaticsClass.ReturnListInfo();
            Assert.Equal(listaRegistros.OrderBy(x => x.Id).ToList(), listaRegistros.ListOrderByProperty<InfoList>("Id"));
        }

        [Fact(DisplayName = "Verificar retorno de lista ordenada por propriedade com dados (retorno diferente)")]
        public void VerificarRetornoListaOrdenadaPropriedadeComDados()
        {
            List<InfoList> listaRegistros = StaticsClass.ReturnListInfo();
            Assert.NotEqual(listaRegistros, listaRegistros.ListOrderByProperty<InfoList>("Id"));
        }
    }
}