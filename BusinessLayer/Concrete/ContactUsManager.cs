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
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public ContactUs GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> GetList()
        {
            return _contactUsDal.GetList();
        }

        public void TAdd(ContactUs t)
        {
            throw new NotImplementedException();
        }

		public void TContactUsStatusChangeToFalse(int id)
		{
			throw new NotImplementedException();
		}

		public void TDelete(ContactUs t)
        {
            throw new NotImplementedException();
        }

		public List<ContactUs> TGetListContactUsByFalse()
		{
			return _contactUsDal.GetListContactUsByFalse();

		}

		public List<ContactUs> TGetListContactUsByTrue()
		{
			return _contactUsDal.GetListContactUsByTrue();
		}

		public void TUpdate(ContactUs t)
        {
            throw new NotImplementedException();
        }
    }
}

