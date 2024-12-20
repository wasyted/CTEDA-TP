﻿using System;
using System.Collections.Generic;

namespace tpfinal
{
	public class PPHeapStrategy : IHeapStrategy {
		private readonly MaxHeap heap = new MaxHeap(new CompararPorPrioridad());
		
		public int GetTamaño(){
			return heap.tamaño;
		}
		public bool EsVacia(){
			return heap.esVacia;
		}
		public void Insertar(IComparable proceso){
			heap.Insertar(proceso);
		}
		public IComparable GetRaiz(){
			return heap.GetRaiz();
		}
		public string ImprimirHojas(){
			return heap.ImprimirHojas();
		}
		public int CantidadHojas(){
			return heap.CantidadHojas();
		}
		public int AlturaHeap(){
			return heap.AlturaHeap();
		}
	}
}
