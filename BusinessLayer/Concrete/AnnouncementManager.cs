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
	public class AnnouncementManager : IAnnouncementService
	{
		private readonly IAnnouncementDal _announcementDal;
public AnnouncementManager(IAnnouncementDal announcementDal)
		{
			_announcementDal = announcementDal;
		}

		public Announcement GetById(int id)
		{
			return _announcementDal.GetByID(id);
		}

		public List<Announcement> GetList()
		{
			return _announcementDal.GetList();
		}

		public void TAdd(Announcement t)
		{
			_announcementDal.Insert(t);
		}

		public void TDelete(Announcement t)
		{
			_announcementDal.Delete(t);
		}

		public void TUpdate(Announcement t)
		{
			_announcementDal.Update(t);
		}
	}
}
