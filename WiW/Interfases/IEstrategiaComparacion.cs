using System;

namespace tpfinal
{
	public interface IEstrategiaComparacion
	{
		bool EsMayor(IComparable comparable, IComparable otroComparable);
		bool EsMenor(IComparable comparable, IComparable otroComparable);
		bool EsIgual(IComparable comparable, IComparable otroComparable);
	}
}
