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
    public class PortfolioManager : IPortfolioService
    {
        IPortfolioDal _portfoliodal;

        public PortfolioManager(IPortfolioDal portfoliodal)
        {
            _portfoliodal = portfoliodal;
        }

        public List<Portfolio> GetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Portfolio t)
        {
            _portfoliodal.Insert(t);
        }

        public Portfolio TGetById(int id)
        {
           return _portfoliodal.GetById(id);
        }

        public List<Portfolio> TGetList()
        {
          return  _portfoliodal.GetList();
        }

        public void TRemove(Portfolio t)
        {
            _portfoliodal.Delete(t);
        }

        public void TUpdate(Portfolio t)
        {
           _portfoliodal.Update(t);
        }
    }
}
