using System.Web.Mvc;
using WebAppRepo.DAL;
using WebAppRepo.Models;

namespace WebAppRepo.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork Container = new UnitOfWork();//3

        public ActionResult Index()
        {
            var list = Container.StudentRepository.GetAll();//3
            return View(list);
        }
        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Student model)
        {
            Container.StudentRepository.Insert(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            var data = Container.StudentRepository.GetByID(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student model)
        {
            Container.StudentRepository.Update(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult Details(int id)
        {
            var data = Container.StudentRepository.GetByID(id);
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Container.StudentRepository.Delete(id);
            Container.Save();
            return RedirectToAction("Index");
        }
    }
}