using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IGenericService<T>
	{
		//busines tarafında gerekli crud işlemlerinin
		//metodlarını çağırmadan önceki imzaları taşıyacak
		//bir nevi iş öncesi iskeleti tanımlamak gibi
		void TAdd(T t);
		void TRemove(T t);
		void TUpdate(T t);
		List<T> TGetList();
		T TGetById(int id);
		//şartlı listeleme metodumu çağırmadan önce oluşturduğum metod
		List<T> GetListByFilter(string p);
	}
}
