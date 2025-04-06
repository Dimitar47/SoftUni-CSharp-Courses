using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Contracts;
using SeminarHub.Data.Models;
using SeminarHub.Models;
using System.Globalization;
using System.Xml.Linq;

namespace SeminarHub.Controllers
{
    public class SeminarController : BaseController
    {
        private readonly ISeminarService _service;

        public SeminarController(ISeminarService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddSeminarViewModel model = await _service.GetAddSeminarModelAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddSeminarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }            

            var userId = GetUserId();

            await _service.AddSeminarAsync(model, userId);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> All()
        {
            var model = await _service.GetAllSeminarsAsync();

            return View(model);
        }

        public async Task<IActionResult> Joined()
        {
            var model = await _service.GetJoinedSeminarsAsync(GetUserId());
            return View(model);
        }

        public async Task<IActionResult> Join(int id)
        {
            var seminar = await _service.GetSeminarByIdAsync(id);

            if(seminar == null)
            {
                return RedirectToAction("All", "Seminar");
            }
            var userId = GetUserId();

            await _service.AddSeminarToJoinedAsync(userId, seminar);
            return RedirectToAction(nameof(Joined));
        }

        public async Task<IActionResult> Leave(int id)
        {
            var seminar = await _service.GetSeminarByIdAsync(id);

            if(seminar == null)
            {
                return RedirectToAction("Joined", "Seminar");
            }

            var userId = GetUserId();
            await _service.LeaveSeminar(userId, seminar);

            return RedirectToAction(nameof(Joined));
        }

        public async Task<IActionResult> Details(int id)
        {
            var seminarToDisplay = await _service.GetSeminarDetails(id);

            if(seminarToDisplay == null)
            {
                return RedirectToAction("All", "Seminar");
            }

            return View(seminarToDisplay);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AddSeminarViewModel model = await _service.GetSeminarToEdit(id);
            if(model == null)
            {
                return RedirectToAction("All", "Seminar");
            }

            string userId = GetUserId();
            if(userId != model.OrganizerId)
            {
                return RedirectToAction("All", "Seminar");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddSeminarViewModel model)
        {
            var seminarToedit = await _service.FindAsync(id);

            if (seminarToedit == null)
            {
                return RedirectToAction("All", "Seminar");
            }

            string currentUser = GetUserId();
            if (currentUser != seminarToedit.OrganizerId)
            {
                return RedirectToAction("All", "Seminar");
            }

            await _service.EditSeminarAsync(model, seminarToedit);

            return RedirectToAction("All", "Seminar");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetUserId();

            var seminar = await _service.FindAsync(id);
            if (seminar == null || seminar.OrganizerId != userId)
            {
                return RedirectToAction("All", "Seminar");
            }

            var model = new DeleteViewModel()
            {
                Id = seminar.Id,
                Topic = seminar.Topic,
                DateAndTime = seminar.DateAndTime
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = GetUserId();

            var seminar = await _service.FindAsync(id);

            if (seminar == null || seminar.OrganizerId != userId)
            {
                return RedirectToAction("All", "Seminar");
            }

            await _service.DeleteSeminarAsync(seminar);            

            return RedirectToAction(nameof(All));
        }

    }
}
