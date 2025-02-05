using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EFaboutDal:GenericRepository<About>,IAboutDal
	{
		//EFAboutDal Sınıfım, Controller tarafında
		//business katmanıma bağlı olan manager sınıflarımı çağırıp,
		//oradaki parametre olarak bu sınıf görev yapmaktadır.
		//Business katmanındaki bağlı olan
		//metoduma gönderdiğim parametreleri içerecek
		//GenericRepostiroy,IAboutDal almamızın sebebi
		//Controller tarafında gerekli işlemler için iş katmanımdaki
		//AboutManager sınıfımı çağırdığımda bir parametre isteyecek
		//istemesinin sebebi  AboutManager sınıfımda ben IAboutDal
		//adında bir field oluşturdum IAboutDal'a göre işlem yapacağım için
		//IAboutDal, IGenericDal'daki tanımlanmış metodları hemde
		//GenericRepository'deki metodlar içerisindeki görevleri 
		//içerdiği için GenericRepository<About>,IAboutDal bu iki tanımlamayı
		//bu classımda kullanıyorum
	}
}
