using System;

namespace tpfinal
{
	using System;
	using System.Collections.Generic;

	public class MaxHeap
	{
		private List<IComparable> elementos;
		private IEstrategiaComparacion estrategia;
		
		public MaxHeap(IEstrategiaComparacion estrategia)
		{
			this.elementos = new List<IComparable>();
			this.estrategia = estrategia;

		}

		public int tamaño{
			get{ return elementos.Count;}
		}

		public bool esVacia {
			get { return elementos.Count == 0; }
		}

		public void Insertar(IComparable comparable)
		{
			comparable.SetEstrategia(this.estrategia);
			elementos.Add(comparable);
			FiltrarArriba(this.tamaño - 1);
		}

		public IComparable GetRaiz()
		{
			IComparable min = elementos[0];
			elementos[0] = elementos[this.tamaño - 1];
			elementos.RemoveAt(this.tamaño - 1);
			FiltrarAbajo(0);

			return min;
		}

		public IComparable VerRaiz()
		{
			if (esVacia)
				throw new InvalidOperationException("La heap está vacía.");

			return elementos[0];
		}

		private void FiltrarArriba(int index)
		{
			while (index > 0) {
				int padre = (index - 1) / 2;
				if (elementos[index].EsMenor(elementos[padre]))
					break;

				Intercambiar(index, padre);
				index = padre;
			}
		}

		private void FiltrarAbajo(int index)
		{
			int tamañoHeap = this.tamaño;
			while (index < tamañoHeap) {
				int hijoIzq = 2 * index + 1;
				int hijoDer = 2 * index + 2;
				int mayor = index;
				
				if (hijoIzq < tamañoHeap && elementos[hijoIzq].EsMayor(elementos[mayor]))
					mayor = hijoIzq;

				if (hijoDer < tamañoHeap && elementos[hijoDer].EsMayor(elementos[mayor]))
					mayor = hijoDer;

				if (mayor == index)
					break;

				Intercambiar(index, mayor);
				index = mayor;
			}
		}

		private void Intercambiar(int i, int j)
		{
			IComparable temp = elementos[i];
			elementos[i] = elementos[j];
			elementos[j] = temp;
		}
		public int CantidadHojas()
		{
			if (esVacia)
				return 0;

			// La cantidad de hojas es el total de elementos menos el número de nodos que tienen al menos un hijo
			int nodosConHijos = this.tamaño / 2;
			return this.tamaño - nodosConHijos;
		}
		
		public int AlturaHeap()
		{
			if (this.elementos.Count == 0)
				return 0; // Si el heap está vacío, la altura es 0.

			// La altura se calcula como log2(n)
			return (int)Math.Ceiling(Math.Log(this.elementos.Count,2));
		}
		
		public String ImprimirHojas(){
			String hojas = "";
			for(int i = 0; i < this.tamaño-1; i++){
				int hijoIzq = 2 * i + 1;
				int hijoDer = 2 * i + 2;
				if(hijoIzq >= this.tamaño && hijoDer >= this.tamaño){
					hojas += "\n" + this.elementos[i] + " ";
				}
			}
			return hojas;
		}
	}
}