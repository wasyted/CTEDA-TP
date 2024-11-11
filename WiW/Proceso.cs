using System;
using System.Collections.Generic;

namespace tpfinal
{

	[Serializable]
	public class Proceso : IComparable
	{
		public string nombre { get; set; } // String of symbols
		
		public int prioridad { get; set; }

		public int tiempo { get; set; }
		
		public IEstrategiaComparacion estrategia;
		
		public void SetEstrategia(IEstrategiaComparacion estrategia){
			this.estrategia = estrategia;
		}
		
		public Proceso(string nombre, int tiempo, int prioridad)
		{
			this.prioridad = prioridad;
			this.nombre = nombre;
			this.tiempo = tiempo;
			this.estrategia = null;
		}
		
		public bool EsMayor(IComparable unProceso){
			return this.estrategia.EsMayor(this , unProceso);
		}
		
		public bool EsMenor(IComparable unProceso){
			return this.estrategia.EsMenor(this , unProceso);
		}
		
		public bool EsIgual(IComparable unProceso){
			return this.estrategia.EsIgual(this , unProceso);
		}
		

		public override string ToString()
		{
			if (nombre != null)
			{

				return nombre + " Tiempo: " + tiempo+" Prioridad: " + prioridad; ;

			}
			else
			{

				return "";
			}
		}
		
		

	}
}