using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZamkDb.Models;
using ZamkDb.Services.Interface;

namespace ZamkDb.Pages.Bookings
{
    public class CreateModel : PageModel
    {
	    private readonly IBookingService repo;

	    [BindProperty] public Booking Booking { get; set; } = new Booking();
	    public CreateModel(IBookingService repo)
	    {
			this.repo = repo;
		}

        public IActionResult OnGet(int tid)
        {
	        Booking.CourseId = tid;
	        //Booking.ParticipantId = uid;
	        return Page();
        }

        public IActionResult OnPost()
        {
	        var errors = ModelState
		        .Where(x => x.Value.Errors.Count > 0)
		        .Select(x => new { x.Key, x.Value.Errors })
		        .ToArray();
			if (!ModelState.IsValid)
	        {
		        return Page();
	        }

	        repo.AddBooking(Booking);
	        return RedirectToPage("GetAllBookings");
        }
    }
}
