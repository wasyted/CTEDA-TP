using System;

namespace tpfinal
{
	public class CompararPorPrioridad : IEstrategiaComparacion
	{
		public bool EsMayor(IComparable comparable, IComparable otroComparable){
			Proceso esteProceso = (Proceso)comparable;
			Proceso otroProceso = (Proceso)otroComparable;
			if(esteProceso.prioridad > otroProceso.prioridad){
				return true;
			}
			return false;
		}
		public bool EsMenor(IComparable comparable, IComparable otroComparable){
			Proceso esteProceso = (Proceso)comparable;
			Proceso otroProceso = (Proceso)otroComparable;
			if(esteProceso.prioridad < otroProceso.prioridad){
				return true;
			}
			return false;
		}
		public bool EsIgual(IComparable comparable, IComparable otroComparable){
			Proceso esteProceso = (Proceso)comparable;
			Proceso otroProceso = (Proceso)otroComparable;
			if(esteProceso.prioridad == otroProceso.prioridad){
				return true;
			}
			return false;
		}
	}
}
