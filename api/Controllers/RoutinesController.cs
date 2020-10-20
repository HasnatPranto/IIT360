using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using IIT360_api.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace IIT360_api.Controllers
{
    [Route("api/Routines/[action]")]
    [ApiController]
    public class RoutinesController : ControllerBase
    {
        private readonly iit360Context _context;

        public RoutinesController(iit360Context context)
        {
            _context = context;
        }

        // GET: api/Routines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Routine>>> GetRoutine()
        {
            return await _context.Routine.ToListAsync();
        }

        // GET: api/Routines/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Routine>> GetRoutine(int id)
        {
            var routine = await _context.Routine.FindAsync(id);

            if (routine == null)
            {
                return NotFound();
            }

            return routine;
        }

        [HttpGet("{mail_id}")]
        public async Task<IActionResult> GetCourse(string mail_id) {
            var iitian = _context.Iitian.FirstOrDefault(s => s.IitianMail == mail_id);

            if (iitian == null) return NotFound();

            string semester = iitian.SemesterCi;
            DateTime date = Convert.ToDateTime("2020-01-01");
            DateTime endDate = date.AddDays(31);
            HashSet<string> courses = new HashSet<string>();

            var routine = _context.Routine.Where(s => s.Semester == semester && s.Date >= date && s.Date < endDate).ToList();

            foreach (var i in routine) {
                courses.Add(i.CourseCode);
            }

            return Ok(courses);
        }
        [HttpGet("{mail_id}")]
        public async Task<IActionResult> weekRoutine(string mail_id)
        {
            DateTime date = Convert.ToDateTime("2020-01-01");
            DateTime endDate = date.AddDays(7);

            List<Routine> routine = new List<Routine>();

            Iitian i = _context.Iitian.FirstOrDefault(s => s.IitianMail == mail_id);
            string type = i.SemesterCi;


            if (type == "CI")
            {
                Instructor ins = _context.Instructor.FirstOrDefault(s => s.InstructorMail == mail_id);
                routine = _context.Routine.Where(s => s.FkInstructorId == ins.InstructorId && s.Date >= date && s.Date < endDate).ToList();
            }

            else
            {
                routine = _context.Routine.Where(s => s.Semester == i.SemesterCi && s.Date >= date && s.Date < endDate).ToList();
            }


            if (routine == null)
            {
                return NotFound();
            }

            return Ok(routine);
        }

        [HttpGet("{mail_id}")]
        public IActionResult EarliestClass(String mail_id) {

            DateTime date = Convert.ToDateTime("2020-10-11");
            DateTime endDate = date.AddDays(7);
            List<Routine> routine = new List<Routine>();
            List<Routine> earliestSet = new List<Routine>();
            int ind = 0; 

            Iitian i = _context.Iitian.FirstOrDefault(s => s.IitianMail == mail_id);
            string type = i.SemesterCi;


            if (type == "CI")
            {
                Instructor ins = _context.Instructor.FirstOrDefault(s => s.InstructorMail == mail_id);
                routine = _context.Routine.Where(s => s.FkInstructorId == ins.InstructorId && s.Date >= date && s.Date < endDate).ToList();
            }

            else
            {
                routine = _context.Routine.Where(s => s.Semester == i.SemesterCi && s.Date >= date && s.Date < endDate).ToList();
            
            }

            if (routine == null)
            {
                return NotFound();
            }

            bool b = false;

            for (int j = 0; j < routine.Count; j++) {
                b = false;

                if (earliestSet.Count == 0) earliestSet.Add(routine[j]);
                
                else {

                    for (int k = 0; k < earliestSet.Count; k++) {

                        if (earliestSet[k].Date == routine[j].Date) {
                            b = true;
                            break;
                        }
                    }

                    if (b == false)
                        earliestSet.Add(routine[j]);
                }
            }


           for(int k=0;k<routine.Count;k++) {
                
                for (int j = 0; j < earliestSet.Count; j++)
                {
                    if (earliestSet[j].Date == routine[k].Date && earliestSet[j].BeginTime > routine[k].BeginTime)
                    {
                        earliestSet.RemoveAt(j);
                        earliestSet.Add(routine[k]);
                    }
                }
            }


            return Ok(earliestSet);
        }

        [HttpDelete("{mail_id}/{course_code}/{date}")]
        public IActionResult CancelClass(string mail_id, string course_code, string date) {

            Cr cr = _context.Cr.FirstOrDefault(s=> s.CrMailId == mail_id);
            List<Routine> routine= new List<Routine>();


            if (cr != null)
            {
                DateTime tdate = Convert.ToDateTime(date);
                routine = _context.Routine.Where(s => s.CourseCode == course_code && s.Date == tdate && s.Semester == cr.Semester).ToList();

                if (routine.Count==0)
                {

                    return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status406NotAcceptable);
                }
                else
                {
                    _context.Routine.RemoveRange(routine);
                    _context.SaveChanges();
                    return Ok(routine);
                }
            }

            else
                return Unauthorized("No CR With This Mail ID Found");
        
        }

        [HttpPut("{mail_id}/{cc1}/{d1}/{cc2}/{d2}")]
        public IActionResult SwapClass(string mail_id, string cc1, string d1, string cc2, string d2) {

            Cr cr = _context.Cr.FirstOrDefault(s => s.CrMailId == mail_id);
           


            if (cr != null)
            {
                DateTime class_one_date = Convert.ToDateTime(d1);
                DateTime class_two_date = Convert.ToDateTime(d2);

               var routine1 = _context.Routine.Where(s => s.CourseCode == cc1 && s.Date == class_one_date && s.Semester == cr.Semester).ToList();

               var routine2 = _context.Routine.Where(s => s.CourseCode == cc2 && s.Date == class_two_date && s.Semester == cr.Semester).ToList();

                if (routine1.Count!=0 && routine2.Count!=0 && routine1[0].Semester==routine2[0].Semester)
                {

                    DateTime date = routine1[0].Date; 
                    string day= routine1[0].Dayname;  
                    TimeSpan t0 = routine1[0].BeginTime; TimeSpan t1 = routine1[0].EndTime;
                    
                    foreach (var sc in routine1)
                    {
                        sc.Date = routine2[0].Date;
                        sc.BeginTime = routine2[0].BeginTime;
                        sc.EndTime = routine2[0].EndTime;
                        sc.Dayname = routine2[0].Dayname;
                       

                    }
                    foreach (var sc in routine2)
                    {
                        sc.Date = date;
                        sc.BeginTime = t0;
                        sc.EndTime = t1;
                        sc.Dayname = day;
                      

                    }
                    _context.SaveChanges();

                    return Ok("Classes Swapped");
                }
                else
                {
                    return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status406NotAcceptable);
                }
            }

            else
                return Unauthorized("No CR With This Mail ID Found");

        }
        [HttpPost("{mail_id}/{cc}/{oldDate}/{newDate}/{begin}/{end}")]
        public IActionResult Reschedule(string mail_id, string cc, string oldDate, string newDate, string begin, string end) {

            Cr cr = _context.Cr.FirstOrDefault(s => s.CrMailId == mail_id);

      
            if (cr != null) {

                DateTime oDate = Convert.ToDateTime(oldDate);
                DateTime nDate = Convert.ToDateTime(newDate);
                TimeSpan t0 = TimeSpan.Parse(begin);
                TimeSpan t1 = TimeSpan.Parse(end);
                var available = _context.Routine.Where(s=> s.Semester== cr.Semester && s.Date == nDate && s.EndTime>t0 && s.BeginTime<t1).ToList();

                if (available.Count != 0) {

                    return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status406NotAcceptable);
                }

                var routine = _context.Routine.Where(s => s.CourseCode == cc && s.Date == oDate).ToList();

                if (routine.Count != 0 && routine[0].Semester == cr.Semester)
                { 
                    foreach (var sc in routine)
                    {

                        Routine r = new Routine();
                        r.CourseCode = cc;
                        r.BeginTime = t0;
                        r.EndTime = t1;
                        r.Date = nDate;
                        r.FkInstructorId = sc.FkInstructorId;
                        r.Dayname = sc.Dayname;
                        r.Semester = sc.Semester;

                        _context.Routine.Add(r);
                        _context.Routine.Remove(sc);
                        _context.SaveChanges();
                    }
                    return Ok("Class Rescheduled");

                }
                else {
                    return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status406NotAcceptable);
                }
            
            
            }

            else {

                return Unauthorized("No CR With This Mail ID Found");
            }


        }
        [HttpPost("{mail_id}/{cc}/{date}/{begin}/{end}/{day}/{ic}")]
        public async Task<IActionResult> ExtraClass(string mail_id, string cc, string date, string begin, string end, string day, string ic) {

            Cr cr = _context.Cr.FirstOrDefault(s => s.CrMailId == mail_id);

            if (cr != null)
            {

                DateTime nDate = Convert.ToDateTime(date);
                TimeSpan t0 = TimeSpan.Parse(begin);
                TimeSpan t1 = TimeSpan.Parse(end);
                var available = _context.Routine.FirstOrDefault(s => s.Date == nDate && s.EndTime > t0 && s.BeginTime < t1);

                var res= await GetCourse(mail_id) as OkObjectResult;
                HashSet<string> availableCourses = new HashSet<string>();
                availableCourses= res.Value as HashSet<string>;

                bool courseAuth = false;

                foreach (var i in availableCourses) {

                    if (i == cc) { courseAuth = true; break; }
                }
                if (available != null || !courseAuth)
                {
                    return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status406NotAcceptable);
                }

                    Routine r = new Routine();
                    r.CourseCode = cc;
                    r.BeginTime = t0;
                    r.EndTime = t1;
                    r.Date = nDate;
                    r.FkInstructorId = ic;
                    r.Dayname = day;
                    r.Semester = cr.Semester;

                    _context.Routine.Add(r);
                    _context.SaveChanges();
                    return Ok("Extra Class Added");
                
            }
            else {

                return Unauthorized("No CR With This Mail ID Found");
            }

            
        }
        // PUT: api/Routines/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
       /* [HttpPut("{id}")]
        public async Task<IActionResult> PutRoutine(int id, Routine routine)
        {
            if (id != routine.RoutineId)
            {
                return BadRequest();
            }

            _context.Entry(routine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoutineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Routines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Routine>> PostRoutine(Routine routine)
        {
            _context.Routine.Add(routine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoutine", new { id = routine.RoutineId }, routine);
        }

        // DELETE: api/Routines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Routine>>DeleteRoutine(int id)
        {
            var routine = await _context.Routine.FindAsync(id);
            if (routine == null)
            {
                return NotFound();
            }

            _context.Routine.Remove(routine);
            await _context.SaveChangesAsync();

            return routine;
        }
        
      
            private bool RoutineExists(int id)
        {
            return _context.Routine.Any(e => e.RoutineId == id);
        }


        [HttpDelete("{course_code}")]
        private async Task<ActionResult<Routine>> CancelClass(string course_code, DateTime date) {

            var routine = await _context.Routine.FindAsync(course_code, date);

            if (routine == null)
            {
                return NotFound();
            }

            _context.Routine.Remove(routine);
            await _context.SaveChangesAsync();

            return routine;

        }

       
            /* IitiansController ic = new IitiansController(_context);
            
            DateTime date = new DateTime();
            date = Convert.ToDateTime("2020-01-01");
            
            var routine=await _context.Routine.FindAsync(date);
            
            return routine;

            /*var type = ic.GetSemester(mail_id);
            
           
            if (type != null)
            {

                if (!type.Equals("CI"))
                {

                  var routine = await _context.Routine.Where(x => x.Date == date).ToListAsync();
                    var json = JsonConvert.SerializeObject(routine);
                    return json;

                }

            }
            else {

             var routine = await _context.Routine.Where(x => x.Date == date && x.FkInstructorId.Equals(type)).ToListAsync();
                var json = JsonConvert.SerializeObject(routine);
                return json;
            }

            return "not found";*/
       
    }
}
