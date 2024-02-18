using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _Testimonial:ViewComponent
    {
        TestimonialManager testimonial = new TestimonialManager(new EfTestimoanialDal());

        public IViewComponentResult Invoke()
        {
            var values = testimonial.GetList();
          
            return View(values);
        }
    }
}
