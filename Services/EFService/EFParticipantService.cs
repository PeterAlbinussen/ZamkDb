using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZamkDb.Models;
using ZamkDb.Services.Interface;

namespace ZamkDb.Services.EFService
{
	public class EFParticipantService : IParticipantService
	{
		private readonly ZamDbContext _context;

		public EFParticipantService(ZamDbContext context)
		{
			_context = context;
		}

		public Participant GetParticipant(string id)
		{
			var participant = _context.Participants
				.Include(p => p.Bookings).ThenInclude(c => c.Course)
				.AsNoTracking()
				.FirstOrDefault(m => m.DriverId == id);
			return participant;
			//return _context.Participants.Find(id);
		}

		public IEnumerable<Participant> GetAllParticipants()
		{
			return _context.Participants;
		}
	}
}
