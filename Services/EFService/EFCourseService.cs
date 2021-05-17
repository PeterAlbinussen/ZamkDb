using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZamkDb.Models;
using ZamkDb.Services.Interface;

namespace ZamkDb.Services.EFService
{
	public class EFCourseService : ICourseService
	{
		private readonly ZamDbContext _context;

		public EFCourseService(ZamDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Course> GetAllCourses()
		{
			return _context.Courses.Include(p => p.User).ThenInclude(x => x.Driver.Name);
		}

		public Course GetCourse(int id)
		{
			//var course = _context.Courses.Include(c => c.Bookings).ThenInclude(b => b.Participant)
			//	.AsNoTracking()
			//	.FirstOrDefault(m => m.CourseId == id);
			////var course = _context.Courses.Include(c => c.Bookings).AsNoTracking().FirstOrDefault(b => b.CourseId == id);
			//return course;
			return _context.Courses.Find(id);
		}

		public Course AddCourse(Course c)
		{
			_context.Courses.Add(c);
			_context.SaveChanges();
			return c;
		}

		public Course DeleteCourse(int id)
		{
			Course course = _context.Courses.Find(id);
			if (course != null)
			{
				_context.Courses.Remove(course);
				_context.SaveChanges();
			}

			return course;

		}

        public Course EditCourse(Course c)
        {
            var course = _context.Courses.Attach(c);
            course.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return c;
        }

        public IEnumerable<Course> FilterCourse(string criteria)
        {
            if (string.IsNullOrEmpty(criteria))
            {
                return _context.Courses;
            }

            return _context.Courses.Where(a => a.ZealandLocation.Contains(criteria));
        }
    }
}
