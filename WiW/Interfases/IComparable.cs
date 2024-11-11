using System;

namespace tpfinal
{
	public interface IComparable
	{
		void SetEstrategia(IEstrategiaComparacion estrategia);
		bool EsMayor(IComparable comparable);
		bool EsMenor(IComparable comparable);
		bool EsIgual(IComparable comparable);
	}
}
