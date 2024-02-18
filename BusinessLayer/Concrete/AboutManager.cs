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
	public class AboutManager : IAboutService

	{
		IABoutDal _aboutdal;

        public AboutManager(IABoutDal aboutDal)
        {
				_aboutdal = aboutDal;
        }
        public About GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<About> GetList()
		{
			 return _aboutdal.GetList();
		}

		public void TAdd(About t)
		{
			_aboutdal.Insert(t);
		}

		public void TDelete(About t)
		{
			_aboutdal.Delete(t);
		}

		public void TUpdate(About t)
		{
			_aboutdal.Update(t);
		}
	}
}
