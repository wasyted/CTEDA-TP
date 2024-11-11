using System;
using System.Collections.Generic;

namespace tpfinal
{
	public interface IHeapStrategy
	{
		int GetTamaño();
		bool EsVacia();
		void Insertar(IComparable comparable);
		IComparable GetRaiz();
		string ImprimirHojas();
		int CantidadHojas();
		int AlturaHeap();
	}
}
