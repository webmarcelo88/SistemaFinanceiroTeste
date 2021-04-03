using Financeiro.Dominio;
using System.Collections.Generic;

namespace Financeiro.Common.Comparadores
{
    public class ComparadorTipoLancamento<T> : IEqualityComparer<TipoLancamento>
    {
        public bool Equals(TipoLancamento x, TipoLancamento y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(TipoLancamento obj)
        {
            return 0;
        }
    }
}