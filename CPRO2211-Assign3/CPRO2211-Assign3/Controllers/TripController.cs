using CPRO2211_Assign3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;

namespace CPRO2211_Assign3.Controllers
{
    public class TripsController : Controller
    {
        private readonly TripDbContext _context;
        private readonly ILogger<TripsController> _logger;

        public TripsController(TripDbContext context, ILogger<TripsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Gets the list view of all Trips
        public async Task<IActionResult> Index()
        {
            var tripsData = await _context.Trips.ToListAsync();
            var trips = tripsData.Select(t => new TripIndexViewModel
            {
                TripId = t.TripId,
                Destination = t.Destination,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                Accommodation = $"{t.Accommodation}\nPhone- {t.AccommodationPhone}\nEmail- {t.AccommodationEmail}",
                CombinedThingsToDo = string.Join(", ", new[] { t.ThingToDo1, t.ThingToDo2, t.ThingToDo3 }.Where(s => !string.IsNullOrEmpty(s)))
            }).ToList();

            ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;
            return View(trips);
        }

        // Returns the view for creating a new Trip
        public IActionResult Create()
        {
            return View();
        }

        // Trip Creation Step 1
        public async Task<IActionResult> CreateStepOne(CreateViewModel trip)
        {
            if (ModelState.IsValid)
            {
                // Store trip information in TempData to preserve it across redirects
                TempData["Destination"] = trip.Destination;
                TempData["StartDate"] = trip.StartDate.ToString("o");
                TempData["EndDate"] = trip.EndDate.ToString("o");
                TempData["Accommodation"] = trip.Accommodation;

                // Check if the Accommodation detail is provided
                if (!string.IsNullOrWhiteSpace(trip.Accommodation))
                {
                    // Redirect to the next step to enter accommodation details
                    return RedirectToAction("CreateAccommodation");
                }
                else
                {
                    // If no Accommodation detail is provided, skip to the step for entering activities
                    return RedirectToAction("CreateActivities");
                }
            }

            // If there are validation errors, re-display the form
            return View(trip);
        }

        // Trip Creation Step 2
        [HttpGet]
        public IActionResult CreateAccommodation()
        {
            // Just display the form initially
            return View(new AccommodationViewModel());
        }

        [HttpPost]
        public IActionResult SubmitAccommodation(AccommodationViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["AccommodationPhone"] = model.AccommodationPhone;
                TempData["AccommodationEmail"] = model.AccommodationEmail;

                // Logging the accommodation details using Peek
                _logger.LogInformation("AccommodationPhone stored in TempData: {AccommodationPhone}", TempData.Peek("AccommodationPhone"));
                _logger.LogInformation("AccommodationEmail stored in TempData: {AccommodationEmail}", TempData.Peek("AccommodationEmail"));

                return RedirectToAction("CreateActivities");
            }
            return View(model);
        }

        // Trip Creation Step 3
        [HttpGet]
        public IActionResult CreateActivities()
        {
            // Just display the form initially
            return View(new ActivityViewModel());
        }

        [HttpPost]
        public IActionResult SubmitActivities(ActivityViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["ThingToDo1"] = model.ThingToDo1;
                TempData["ThingToDo2"] = model.ThingToDo2;
                TempData["ThingToDo3"] = model.ThingToDo3;

                // Logging the activities details using Peek
                _logger.LogInformation("ThingToDo1 stored in TempData: {ThingToDo1}", TempData.Peek("ThingToDo1"));
                _logger.LogInformation("ThingToDo2 stored in TempData: {ThingToDo2}", TempData.Peek("ThingToDo2"));
                _logger.LogInformation("ThingToDo3 stored in TempData: {ThingToDo3}", TempData.Peek("ThingToDo3"));

                return RedirectToAction("Save");
            }
            return View(model);
        }

        // Trip Creation Step 4
        [HttpGet]
        public IActionResult Save()
        {
            var viewModel = new Trip // Assuming you have a ViewModel that suits your needs
            {
                Destination = TempData.Peek("Destination")?.ToString(),
                StartDate = (DateTime)(TempData.Peek("StartDate") != null ? (DateTime?)DateTime.Parse(TempData.Peek("StartDate").ToString()) : null),
                EndDate = (DateTime)(TempData.Peek("EndDate") != null ? (DateTime?)DateTime.Parse(TempData.Peek("EndDate").ToString()) : null),
                Accommodation = TempData.Peek("Accommodation")?.ToString(),
                AccommodationPhone = TempData.Peek("AccommodationPhone")?.ToString(),
                AccommodationEmail = TempData.Peek("AccommodationEmail")?.ToString(),
                ThingToDo1 = TempData.Peek("ThingToDo1")?.ToString(),
                ThingToDo2 = TempData.Peek("ThingToDo2")?.ToString(),
                ThingToDo3 = TempData.Peek("ThingToDo3")?.ToString(),
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitSave(Trip trip)
        {

            if (trip.Destination != null && trip.StartDate != null && trip.EndDate != null && trip.ThingToDo1 != null)
            {
                // The trip object is already populated, so just add it to the context
                _context.Trips.Add(trip);
                await _context.SaveChangesAsync();

                TempData.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Missing trip information. Please try again.";
                return RedirectToAction("Create");
            }
        }

        // Shows the details of a specific Trip
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }

            var viewModel = new TripIndexViewModel
            {
                TripId = trip.TripId,
                Destination = trip.Destination,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate,
                Accommodation = $"{trip.Accommodation}\nPhone- {trip.AccommodationPhone}\nEmail- {trip.AccommodationEmail}",
                CombinedThingsToDo = string.Join(", ", new[] { trip.ThingToDo1, trip.ThingToDo2, trip.ThingToDo3 }.Where(s => !string.IsNullOrEmpty(s)))
            };

            return View(viewModel);
        }

        // Returns the Delete confirmation view for a specific Trip
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // Confirms deletion of a Trip
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Trip deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        // Checks if a Trip exists by its ID
        private bool TripExists(int id)
        {
            return _context.Trips.Any(e => e.TripId == id);
        }
    }
}