using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IAboutService:IGenericService<About>
	{
		//IGenericService tanımlamış olduğum metodlara ulaşmak için
		//ve IGenericService'deki T değerime buradan About değerimi
		//tanımladım
	}
}
