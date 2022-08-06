using InfilonTask.Models;
using InfilonTask.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfilonTask.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectController (ISubjectRepository subjectRepoitory)
        {
            this._subjectRepository = subjectRepoitory;
        }
        // GET: SubjectController
        public ActionResult Index()
        {
            var subjectData = _subjectRepository.GetSubjectData();
            return View(subjectData);
        }

        public async Task<ActionResult>  UpdateDataFromApi()
        {
            try
            {
                await _subjectRepository.PostSubjectDataFromApiToDatabase();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectController/Edit/5
        public ActionResult Edit(int id)
        {
            var subject = _subjectRepository.GetSubjectDataById(id);
            return View(subject);
        }

        // POST: SubjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Subject collection)
        {
            try
            {
                _subjectRepository.UpdateSubject(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

