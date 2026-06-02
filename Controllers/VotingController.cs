using Microsoft.AspNetCore.Mvc;
using mi_proyecto.Models;
using mi_proyecto.Services;
using System.Collections.Generic;

namespace mi_proyecto.Controllers
{
    public class VotingController : Controller
    {
        private readonly DataService _dataService;

        public VotingController(DataService dataService)
        {
            _dataService = dataService;
        }

        // GET: /Voting
        public IActionResult Index()
        {
            var events = _dataService.GetVotingEvents();
            
            var candidatesMap = new Dictionary<int, List<VotingCandidate>>();
            foreach(var e in events)
            {
                candidatesMap[e.Id] = _dataService.GetCandidatesByEventId(e.Id);
            }
            ViewBag.CandidatesMap = candidatesMap;
            
            return View(events);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEvent([Bind("Title,StartDate,EndDate")] VotingEvent vEvent)
        {
            if (ModelState.IsValid)
            {
                _dataService.AddVotingEvent(vEvent);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEvent(int id)
        {
            _dataService.DeleteVotingEvent(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCandidate([Bind("VotingEventId,Name,Proposal")] VotingCandidate candidate)
        {
            if (ModelState.IsValid)
            {
                _dataService.AddCandidate(candidate);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCandidate(int id)
        {
            _dataService.DeleteCandidate(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
