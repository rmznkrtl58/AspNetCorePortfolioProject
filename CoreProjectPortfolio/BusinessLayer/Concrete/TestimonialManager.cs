using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager:ITestimonialService
    {
        ITestimonialDal _testimonial;

        public TestimonialManager(ITestimonialDal testimonial)
        {
            _testimonial = testimonial;
        }

        public List<Testimonial> GetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Testimonial t)
        {
           _testimonial.Insert(t);
        }

        public Testimonial TGetById(int id)
        {
          return  _testimonial.GetById(id);
        }

        public List<Testimonial> TGetList()
        {
            return _testimonial.GetList();
        }

        public void TRemove(Testimonial t)
        {
            _testimonial.Delete(t);
        }

        public void TUpdate(Testimonial t)
        {
            _testimonial.Update(t);
        }
    }
}
