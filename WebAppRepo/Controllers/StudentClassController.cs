using System.Linq;
using System.Web.Mvc;
using WebAppRepo.DAL;
using WebAppRepo.Models;

namespace WebAppRepo.Controllers
{
    public class StudentClassController : Controller
    {
        private UnitOfWork Container = new UnitOfWork();

        public ActionResult Index()
        {
            return View(Container.StudentClassRepository.GetAll());
        }
        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(StudentClass model)
        {            
            Container.StudentClassRepository.Insert(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {           
            var data = Container.StudentClassRepository.GetByID(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(StudentClass model)
        {           
            Container.StudentClassRepository.Update(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult Details(int id)
        {          
            var data = Container.StudentClassRepository.GetByID(id);
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {           
            Container.StudentClassRepository.Delete(id);
            Container.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult GetResult()
        {
            var data = Container.StudentClassRepository.GetAll().Where(x => x.Id > 2).ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}