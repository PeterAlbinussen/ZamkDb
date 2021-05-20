using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [BindProperty] public IEnumerable<SelectListItem> PickUpPointList { get; set; } = new List<SelectListItem>();

        public CreateModel(IBookingService repo, ICourseService repoC)
        {
            this.repo = repo;
            this.repoC = repoC;
        }

        public IActionResult OnGet(int tid, string cpp)
        {
            Booking.CourseId = tid;
            Course = repoC.GetCourse(tid);
            Booking.ChosenPickUpPoint = cpp;

            //PickUpPointList.Append(new SelectListItem(Course.PickUpPoint1,Course.PickUpPoint1));
            //PickUpPointList.Append(new SelectListItem(Course.PickUpPoint2, Course.PickUpPoint2));
            //PickUpPointList.Append(new SelectListItem(Course.PickUpPoint3, Course.PickUpPoint3));

            //Booking.ParticipantId = uid;
            return Page();
        }

        //public IActionResult OnPost()
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    return RedirectToPage("BookingConfirm");

        //}


    }
}