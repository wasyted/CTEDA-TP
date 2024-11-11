
using System;
using System.Collections.Generic;
using System.Numerics;

namespace tpfinal
{

	public class Estrategia
	{

		public String Consulta1(List<Proceso> datos)
		{
			
			if(datos.Count == 0){
				return "Lista vacía";
			}
			
			string result = "";
			int cantidadHojasMinHeap = 0;
			int cantidadHojasMaxHeap = 0;
			
			IHeapStrategy PP = HeapFactory.CrearHeap("PP");
			IHeapStrategy SSF = HeapFactory.CrearHeap("SJF");
			
			foreach (var dato in datos) {
				PP.Insertar(dato);
				SSF.Insertar(dato);
			}
			
			cantidadHojasMinHeap = SSF.CantidadHojas();
			cantidadHojasMaxHeap = PP.CantidadHojas();
			
			// Analizar hojas en MinHeap
			result += "\nNodos hoja en MinHeap (SJF) (" + cantidadHojasMinHeap + "): ";
			
			result += SSF.ImprimirHojas();
			
			result += "\n";
			
			// Analizar hojas en MaxHeap
			result += "\nNodos hoja en maxHeap (PP) (" + cantidadHojasMaxHeap + "): ";
			
			result += PP.ImprimirHojas();
			
			return "Hojas de las heaps:\n" + string.Join("\n", result);
			
		}



		public String Consulta2(List<Proceso> datos)
		{
			
			int alturaMinHeap, alturaMaxHeap = 0;
			
			IHeapStrategy PP = HeapFactory.CrearHeap("PP");
			IHeapStrategy SSF = HeapFactory.CrearHeap("SJF");
			
			foreach (var dato in datos) {
				PP.Insertar(dato);
				SSF.Insertar(dato);
			}
			
			alturaMinHeap = SSF.AlturaHeap();
			
			alturaMaxHeap = PP.AlturaHeap();
			
			string result = "Altura de la Heap en SJF: " + alturaMinHeap.ToString() + " Altura de la Heap en PP:  " + alturaMaxHeap.ToString();
			
			return result;
		}



		public String Consulta3(List<Proceso> datos)
		{
			string result = "";
			int tamañoMaxHeap, tamañoMinHeap = 0;
			
			IHeapStrategy PP = HeapFactory.CrearHeap("PP");
			IHeapStrategy SSF = HeapFactory.CrearHeap("SJF");
			
			foreach (var dato in datos) {
				PP.Insertar(dato);
				SSF.Insertar(dato);
			}
			
			tamañoMaxHeap = PP.GetTamaño();
			tamañoMinHeap = SSF.GetTamaño();
			
			result += "\nDatos en MinHeap (SJF): ";
			for (int i = 0; i < tamañoMinHeap; i++)
			{
				int nivel = (int)Math.Floor(Math.Log(i + 1,2)); // Calcular nivel
				result += "\nNivel " + nivel.ToString() + ": " + SSF.GetRaiz().ToString();
			}
			
			result += "\n";
			
			result += "\nDatos en MaxHeap (PP): ";
			for (int i = 0; i < tamañoMaxHeap; i++)
			{
				int nivel = (int)Math.Floor(Math.Log(i + 1,2)); // Calcular nivel
				result += "\nNivel " + nivel + ": " + PP.GetRaiz().ToString() + " ";
			}
			
			return result;
		}


		public void ShortesJobFirst(List<Proceso> datos, List<Proceso> collected)
		{
			IHeapStrategy heap = HeapFactory.CrearHeap("SJF");
			
			foreach (var dato in datos) {
				heap.Insertar(dato);
			}
			
			while(!heap.EsVacia()){
				collected.Add((Proceso)heap.GetRaiz());
			}
		}


		public void PreemptivePriority(List<Proceso> datos, List<Proceso> collected)
		{
			IHeapStrategy heap = HeapFactory.CrearHeap("PP");
			
			foreach (var dato in datos) {
				heap.Insertar(dato);
			}
			
			while(!heap.EsVacia()){
				collected.Add((Proceso)heap.GetRaiz());
			}
		}
	}
}