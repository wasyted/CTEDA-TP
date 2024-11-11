using System;

namespace tpfinal
{
	using System;
	using System.Collections.Generic;

	public class MinHeap
	{
		private List<IComparable> elementos;
		IEstrategiaComparacion estrategia;

		public MinHeap(IEstrategiaComparacion estrategia)
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
			FiltrarArriba(this.tamaño- 1);
		}
		
		public void BuildHeap(List<IComparable> comparables){
			this.elementos = comparables;
			FiltrarAbajo(0);
		}
		
		public IComparable GetRaiz()
		{
			if (esVacia)
				throw new InvalidOperationException("La heap está vacía.");

			IComparable min = elementos[0];
			elementos[0] = elementos[tamaño - 1];
			elementos.RemoveAt(tamaño - 1);
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
			while (index > 0)
			{
				int padre = (index - 1) / 2;
				if (elementos[index].EsMayor(elementos[padre]))
					break;

				Intercambiar(index, padre);
				index = padre;
			}
		}

		private void FiltrarAbajo(int index)
		{
			int tamañoHeap = this.tamaño;
			while (index < tamañoHeap)
			{
				int hijoIzq = 2 * index + 1;
				int hijoDer = 2 * index + 2;
				int menor = index;

				if (hijoIzq < tamañoHeap && elementos[hijoIzq].EsMenor(elementos[menor]))
					menor = hijoIzq;

				if (hijoDer < tamañoHeap && elementos[hijoDer].EsMenor(elementos[menor]))
					menor = hijoDer;

				if (menor == index)
					break;

				Intercambiar(index, menor);
				index = menor;
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
			int nodosConHijos = tamaño / 2;
			return tamaño - nodosConHijos;
		}
		
		public int AlturaHeap()
		{
			if (this.esVacia)
				return 0; // Si el heap está vacío, la altura es 0.
			
			return (int)Math.Ceiling(Math.Log(this.tamaño,2)); // La altura se calcula como log2(n)
		}
		
		public String ImprimirHojas(){
			String hojas = "";
			for(int i = tamaño/2; i < this.tamaño; i++){
				hojas += "\n" + this.elementos[i] + " ";
			}
			return hojas;
		}
		
	}

}
