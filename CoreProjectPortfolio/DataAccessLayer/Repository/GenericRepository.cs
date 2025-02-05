using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
		//GenericRepository classım IGenericDal'da tanımlamış olduğum
		//temel crud metodlarının buraya implemente edip
		//metodların içerisine gerekli görevleri verdiğimiz yerdir.
	{   
		public void Delete(T t)
		{
			using var ent = new Context();
			ent.Remove(t);
		    ent.SaveChanges();
		}

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
           using var ent=new Context();
		   return ent.Set<T>().Where(filter).ToList();
            //T'ye gelecek olan entity değerimi al (tablom yani)
            //belirlediğim şarta göre ilgili tablomdan değerleri listele
			//burda implement ettikten sonra genericserviste metodu tanımla
        }

        public T GetById(int id)
		{
			using var ent = new Context();
			return ent.Set<T>().Find(id);
			//T'ye gelecek olan entity değerimi al
			//ve onun id'sine göre arama yap
		}

		public List<T> GetList()
		{
			using var ent = new Context();
			return ent.Set<T>().ToList();
			//T'ye gelecek olan entity değerimi al
			//ve ona göre Verileri Listele
		}

		public void Insert(T t)
		{
			using var ent = new Context();
			ent.Add(t);
			ent.SaveChanges();
		}

		public void Update(T t)
		{
			using var ent = new Context();
			ent.Update(t);
			ent.SaveChanges();
		}
	}
}
