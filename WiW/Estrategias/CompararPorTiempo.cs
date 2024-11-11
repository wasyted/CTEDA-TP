using System;

namespace tpfinal
{
	public class CompararPorTiempo : IEstrategiaComparacion
	{
		public bool EsMayor(IComparable comparable, IComparable otroComparable){
			Proceso esteProceso = (Proceso)comparable;
			Proceso otroProceso = (Proceso)otroComparable;
			if(esteProceso.tiempo > otroProceso.tiempo){
				return true;
			}
			return false;
		}
		public bool EsMenor(IComparable comparable, IComparable otroComparable){
			Proceso esteProceso = (Proceso)comparable;
			Proceso otroProceso = (Proceso)otroComparable;
			if(esteProceso.tiempo < otroProceso.tiempo){
				return true;
			}
			return false;
		}
		public bool EsIgual(IComparable comparable, IComparable otroComparable){
			Proceso esteProceso = (Proceso)comparable;
			Proceso otroProceso = (Proceso)otroComparable;
			if(esteProceso.tiempo == otroProceso.tiempo){
				return true;
			}
			return false;
		}
	}
}