using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZamkDb.Models;
using ZamkDb.Services.Interface;

namespace ZamkDb.Pages.Account
{
    public class ManageYourAccountModel : PageModel
    {
        private readonly IParticipantService repository;

        public ManageYourAccountModel(IParticipantService repository)
        {
            this.repository = repository;
        }

        
        public Participant Participant { get; set; }


        public IActionResult OnGet(string uid)
        {
            Participant = repository.GetParticipant(uid);
            return Page();
        }

        public IActionResult OnPost(Participant participant)
        {
            participant = repository.EditParticipant(participant);
            return RedirectToPage("GetAllParticipants");
        }
    }
}
