using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Announcement
	{
        public int AnnouncementID { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public DateTime Date { get; set; }
    }
}
