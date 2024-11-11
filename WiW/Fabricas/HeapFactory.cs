using System;

namespace tpfinal
{
	public static class HeapFactory {
		public static IHeapStrategy CrearHeap(string tipo) {
			if (tipo == "SJF") return new SJFHeapStrategy();
			if (tipo == "PP") return new PPHeapStrategy();
			throw new ArgumentException("Tipo de Heap no soportado");
		}
	}
}
