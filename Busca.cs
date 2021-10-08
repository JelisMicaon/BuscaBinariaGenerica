using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Busca
{
    public static class Busca
    {
        public static T PesquisaBinaria<T>(List<T> lista, string chaveBusca, long chave) where T : class
        {
            List<PropertyInfo> propriedades = typeof(T).GetProperties().ToList();
            if (propriedades.Any(x => x.Name == chaveBusca))
            {
                lista = lista.OrderBy(x => typeof(T).GetProperty(chaveBusca).GetValue(x, null)).ToList();

                int meio;
                int esquerda = 0;
                int direita = lista.Count - 1;
                long valorPropriedade;

                do
                {
                    meio = (esquerda + direita) / 2;
                    valorPropriedade = Convert.ToInt64(lista.ElementAt(meio).GetType().GetProperty(chaveBusca).GetValue(lista.ElementAt(meio)));
                    if (valorPropriedade == chave)
                        return lista.ElementAt(meio);
                    else if (chave > valorPropriedade)
                        esquerda = meio + 1;
                    else
                        direita = meio - 1;
                } while (esquerda <= direita);

                return null;
            }

            return null;
        }
    }
}
