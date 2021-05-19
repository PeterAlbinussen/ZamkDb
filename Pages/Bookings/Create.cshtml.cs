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
        private readonly ICourseService repoC;

		[BindProperty] public Course Course { get; set; } = new Course();
	    [BindProperty] public Booking Booking { get; set; } = new Booking();
	    public CreateModel(IBookingService repo, ICourseService repoC)
	    {
			this.repo = repo;
            this.repoC = repoC;
        }

        public IActionResult OnGet(int tid)
        {
	        Booking.CourseId = tid;
            Course = repoC.GetCourse(tid);
	        //Booking.ParticipantId = uid;
	        return Page();
        }

   //     public IActionResult OnPost()
   //     {
	        
			//if (!ModelState.IsValid)
	  //      {
		 //       return Page();
	  //      }

	  //      repo.AddBooking(Booking);
	  //      return RedirectToPage("GetAllBookings");
			
   //     }
    }
}
