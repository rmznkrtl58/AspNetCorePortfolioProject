using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IAboutDal:IGenericDal<About>
	{
		//IGenericDal->Benim temel crud işlemlerimi
		//iskelet kısmını oluşturduğum yani gerekli metodları
		//tanımladığım yerdir altını çiziyorum tanımladığım yerdir
		//görevleri verdiğim yer değil!
		//IAboutDal IGenericDal'a bağlı olan tanımlamalarımı
		//kapsayacak ve IGenericDal'da T olan parametreme 
		//gelecek olan değeri (about classını) belirttiğim yerdir.
		//IGenericDal'daki gerekli bütün tanımlamaları artık
		//IAboutDal'da kapsıyor olacak
		
	}
}
