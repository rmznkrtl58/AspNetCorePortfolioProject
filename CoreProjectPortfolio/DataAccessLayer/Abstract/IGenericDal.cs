using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IGenericDal<T> where T:class 
	{
		void Insert(T t);

		void Update(T t);

		void Delete(T t);

		List<T> GetList();

		T GetById(int id);
		//Şartlı listeleme istediğim şarta göre listeleme yapacak
		List<T> GetByFilter(Expression<Func<T,bool>>filter);//filter şartım olacak
	    //metodu tanımladıktan sonra generic repository'de implemt et (metodu dahil et)
	}
}
