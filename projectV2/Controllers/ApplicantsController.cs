using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GMUAdmissionPortal.Models;
using projectV2.Data;

namespace projectV1.Controllers
{
    public class ApplicantsController : Controller
    {
        private projectV2Context db = new projectV2Context();

        // GET: Applicants
        public ActionResult Index(string search)
        {
            var applicants = db.Applicants.Where(a => a.SSN.Length != 0);

            if (!String.IsNullOrEmpty(search))
            {
                applicants = applicants.Where(a => a.LastName.Contains(search) ||
                a.SSN.Contains(search));
                ViewBag.Search = search;
            }

            return View(applicants.ToList());
        }

        // GET: Applicants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // GET: Applicants/Create
        public ActionResult Create()
        {
            List<SelectListItem> States = new List<SelectListItem>();
            States.Add(new SelectListItem { Text = "Alabama", Value = "Alabama" });
            States.Add(new SelectListItem { Text = "Alaska", Value = "Alaska" });
            States.Add(new SelectListItem { Text = "Arizona", Value = "Arizona" });
            States.Add(new SelectListItem { Text = "Arkansas", Value = "Arkansas" });
            States.Add(new SelectListItem { Text = "California", Value = "California" });
            States.Add(new SelectListItem { Text = "Colorado", Value = "Colorado" });
            States.Add(new SelectListItem { Text = "Connecticut", Value = "Connecticut" });
            States.Add(new SelectListItem { Text = "Delaware", Value = "Delaware" });
            States.Add(new SelectListItem { Text = "Florida", Value = "Florida" });
            States.Add(new SelectListItem { Text = "Georgia", Value = "Georgia" });
            States.Add(new SelectListItem { Text = "Hawaii", Value = "Hawaii" });
            States.Add(new SelectListItem { Text = "Idaho", Value = "Idaho" });
            States.Add(new SelectListItem { Text = "Illinois", Value = "Illinois" });
            States.Add(new SelectListItem { Text = "Indiana", Value = "Indiana" });
            States.Add(new SelectListItem { Text = "Iowa", Value = "Iowa" });
            States.Add(new SelectListItem { Text = "Kansas", Value = "Kansas" });
            States.Add(new SelectListItem { Text = "Kentucky", Value = "Kentucky" });
            States.Add(new SelectListItem { Text = "Louisiana", Value = "Louisiana" });
            States.Add(new SelectListItem { Text = "Maine", Value = "Maine" });
            States.Add(new SelectListItem { Text = "Maryland", Value = "Maryland" });
            States.Add(new SelectListItem { Text = "Massachusetts", Value = "Massachusetts" });
            States.Add(new SelectListItem { Text = "Michigan", Value = "Michigan" });
            States.Add(new SelectListItem { Text = "Minnesota", Value = "Minnesota" });
            States.Add(new SelectListItem { Text = "Mississippi", Value = "Mississippi" });
            States.Add(new SelectListItem { Text = "Missouri", Value = "Missouri" });
            States.Add(new SelectListItem { Text = "Montana", Value = "Montana" });
            States.Add(new SelectListItem { Text = "Nebraska", Value = "Nebraska" });
            States.Add(new SelectListItem { Text = "Nevada", Value = "Nevada" });
            States.Add(new SelectListItem { Text = "New Hampshire", Value = "New Hampshire" });
            States.Add(new SelectListItem { Text = "New Jersey", Value = "New Jersey" });
            States.Add(new SelectListItem { Text = "New Mexico", Value = "New Mexico" });
            States.Add(new SelectListItem { Text = "New York", Value = "New York" });
            States.Add(new SelectListItem { Text = "North Carolina", Value = "North Carolina" });
            States.Add(new SelectListItem { Text = "North Dakota", Value = "North Dakota" });
            States.Add(new SelectListItem { Text = "Ohio", Value = "Ohio" });
            States.Add(new SelectListItem { Text = "Oklahoma", Value = "Oklahoma" });
            States.Add(new SelectListItem { Text = "Oregon", Value = "Oregon" });
            States.Add(new SelectListItem { Text = "Pennsylvania", Value = "Pennsylvania" });
            States.Add(new SelectListItem { Text = "Rhode Island", Value = "Rhode Island" });
            States.Add(new SelectListItem { Text = "South Carolina", Value = "South Carolina" });
            States.Add(new SelectListItem { Text = "South Dakota", Value = "South Dakota" });
            States.Add(new SelectListItem { Text = "Tennessee", Value = "Tennessee" });
            States.Add(new SelectListItem { Text = "Texas", Value = "Texas" });
            States.Add(new SelectListItem { Text = "Utah", Value = "Utah" });
            States.Add(new SelectListItem { Text = "Vermont", Value = "Vermont" });
            States.Add(new SelectListItem { Text = "Virginia", Value = "Virginia" });
            States.Add(new SelectListItem { Text = "Washington", Value = "Washington" });
            States.Add(new SelectListItem { Text = "West Virginia", Value = "West Virginia" });
            States.Add(new SelectListItem { Text = "Wisconsin", Value = "Wisconsin" });
            States.Add(new SelectListItem { Text = "Wyoming", Value = "Wyoming" });
            ViewBag.Majors = States;

            List<SelectListItem> Majors = new List<SelectListItem>();
            Majors.Add(new SelectListItem { Text = "Math", Value = "Math" });
            Majors.Add(new SelectListItem { Text = "Information Technology", Value = "Information Technology" });
            Majors.Add(new SelectListItem { Text = "Computer Science", Value = "Computer Science" });
            Majors.Add(new SelectListItem { Text = "Biology", Value = "Biology" });
            Majors.Add(new SelectListItem { Text = "Chemistry", Value = "Chemistry" });
            Majors.Add(new SelectListItem { Text = "Engineering", Value = "Engineering" });
            ViewBag.Majors = Majors;

            List<SelectListItem> EnrollmentSemester = new List<SelectListItem>();
            EnrollmentSemester.Add(new SelectListItem { Text = "Spring", Value = "Spring" });
            EnrollmentSemester.Add(new SelectListItem { Text = "Summer", Value = "Summer" });
            EnrollmentSemester.Add(new SelectListItem { Text = "Fall", Value = "Fall" });
            ViewBag.EnrollmentSemester = EnrollmentSemester;


            return View();
        }


        // POST: Applicants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,MiddleName,LastName,SSN,EmailAddress,HomePhone,CellPhone,Street,City,State,Zipcode,DOB,Gender,HSName,HSCity,GraduationDate,GPA,MathScore,VerbalScore,Major,EnrollmentSemester,EnrollmentYear,SubmissionDate")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                Applicant matchingApplicant = db.Applicants.Where(cm => string.Compare(cm.SSN, applicant.SSN, true) == 0).FirstOrDefault();

                if (applicant == null)
                {
                    return HttpNotFound();
                }

                if (matchingApplicant != null)
                {
                    ModelState.AddModelError("SSN", "An applicant with this SSN already exist. Each applicant can apply only once.");
                    return View(applicant);
                }

                if (applicant.MathScore + applicant.VerbalScore < 1000)
                {
                    ModelState.AddModelError("VerbalScore", "You are not qualified. The total of Math Score and Verbal Score must be greater than 1000");
                    return View(applicant);
                }

                db.Applicants.Add(applicant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicant);
        }

        // GET: Applicants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> States = new List<SelectListItem>();
            States.Add(new SelectListItem { Text = "Alabama", Value = "Alabama" });
            States.Add(new SelectListItem { Text = "Alaska", Value = "Alaska" });
            States.Add(new SelectListItem { Text = "Arizona", Value = "Arizona" });
            States.Add(new SelectListItem { Text = "Arkansas", Value = "Arkansas" });
            States.Add(new SelectListItem { Text = "California", Value = "California" });
            States.Add(new SelectListItem { Text = "Colorado", Value = "Colorado" });
            States.Add(new SelectListItem { Text = "Connecticut", Value = "Connecticut" });
            States.Add(new SelectListItem { Text = "Delaware", Value = "Delaware" });
            States.Add(new SelectListItem { Text = "Florida", Value = "Florida" });
            States.Add(new SelectListItem { Text = "Georgia", Value = "Georgia" });
            States.Add(new SelectListItem { Text = "Hawaii", Value = "Hawaii" });
            States.Add(new SelectListItem { Text = "Idaho", Value = "Idaho" });
            States.Add(new SelectListItem { Text = "Illinois", Value = "Illinois" });
            States.Add(new SelectListItem { Text = "Indiana", Value = "Indiana" });
            States.Add(new SelectListItem { Text = "Iowa", Value = "Iowa" });
            States.Add(new SelectListItem { Text = "Kansas", Value = "Kansas" });
            States.Add(new SelectListItem { Text = "Kentucky", Value = "Kentucky" });
            States.Add(new SelectListItem { Text = "Louisiana", Value = "Louisiana" });
            States.Add(new SelectListItem { Text = "Maine", Value = "Maine" });
            States.Add(new SelectListItem { Text = "Maryland", Value = "Maryland" });
            States.Add(new SelectListItem { Text = "Massachusetts", Value = "Massachusetts" });
            States.Add(new SelectListItem { Text = "Michigan", Value = "Michigan" });
            States.Add(new SelectListItem { Text = "Minnesota", Value = "Minnesota" });
            States.Add(new SelectListItem { Text = "Mississippi", Value = "Mississippi" });
            States.Add(new SelectListItem { Text = "Missouri", Value = "Missouri" });
            States.Add(new SelectListItem { Text = "Montana", Value = "Montana" });
            States.Add(new SelectListItem { Text = "Nebraska", Value = "Nebraska" });
            States.Add(new SelectListItem { Text = "Nevada", Value = "Nevada" });
            States.Add(new SelectListItem { Text = "New Hampshire", Value = "New Hampshire" });
            States.Add(new SelectListItem { Text = "New Jersey", Value = "New Jersey" });
            States.Add(new SelectListItem { Text = "New Mexico", Value = "New Mexico" });
            States.Add(new SelectListItem { Text = "New York", Value = "New York" });
            States.Add(new SelectListItem { Text = "North Carolina", Value = "North Carolina" });
            States.Add(new SelectListItem { Text = "North Dakota", Value = "North Dakota" });
            States.Add(new SelectListItem { Text = "Ohio", Value = "Ohio" });
            States.Add(new SelectListItem { Text = "Oklahoma", Value = "Oklahoma" });
            States.Add(new SelectListItem { Text = "Oregon", Value = "Oregon" });
            States.Add(new SelectListItem { Text = "Pennsylvania", Value = "Pennsylvania" });
            States.Add(new SelectListItem { Text = "Rhode Island", Value = "Rhode Island" });
            States.Add(new SelectListItem { Text = "South Carolina", Value = "South Carolina" });
            States.Add(new SelectListItem { Text = "South Dakota", Value = "South Dakota" });
            States.Add(new SelectListItem { Text = "Tennessee", Value = "Tennessee" });
            States.Add(new SelectListItem { Text = "Texas", Value = "Texas" });
            States.Add(new SelectListItem { Text = "Utah", Value = "Utah" });
            States.Add(new SelectListItem { Text = "Vermont", Value = "Vermont" });
            States.Add(new SelectListItem { Text = "Virginia", Value = "Virginia" });
            States.Add(new SelectListItem { Text = "Washington", Value = "Washington" });
            States.Add(new SelectListItem { Text = "West Virginia", Value = "West Virginia" });
            States.Add(new SelectListItem { Text = "Wisconsin", Value = "Wisconsin" });
            States.Add(new SelectListItem { Text = "Wyoming", Value = "Wyoming" });
            ViewBag.Majors = States;

            List<SelectListItem> Majors = new List<SelectListItem>();
            Majors.Add(new SelectListItem { Text = "Math", Value = "Math" });
            Majors.Add(new SelectListItem { Text = "Information Technology", Value = "Information Technology" });
            Majors.Add(new SelectListItem { Text = "Computer Science", Value = "Computer Science" });
            Majors.Add(new SelectListItem { Text = "Biology", Value = "Biology" });
            Majors.Add(new SelectListItem { Text = "Chemistry", Value = "Chemistry" });
            Majors.Add(new SelectListItem { Text = "Engineering", Value = "Engineering" });
            ViewBag.Majors = Majors;

            List<SelectListItem> EnrollmentSemester = new List<SelectListItem>();
            EnrollmentSemester.Add(new SelectListItem { Text = "Spring", Value = "Spring" });
            EnrollmentSemester.Add(new SelectListItem { Text = "Summer", Value = "Summer" });
            EnrollmentSemester.Add(new SelectListItem { Text = "Fall", Value = "Fall" });
            ViewBag.EnrollmentSemester = EnrollmentSemester;

            List<SelectListItem> AdmissionDecision = new List<SelectListItem>();
            AdmissionDecision.Add(new SelectListItem { Text = "Admit", Value = "Admit" });
            AdmissionDecision.Add(new SelectListItem { Text = "Reject", Value = "Reject" });
            AdmissionDecision.Add(new SelectListItem { Text = "Wait List", Value = "Wait List" });
            ViewBag.EnrollmentSemester = AdmissionDecision;

            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,SSN,EmailAddress,HomePhone,CellPhone,Street,City,State,Zipcode,DOB,Gender,HSName,HSCity,GraduationDate,GPA,MathScore,VerbalScore,Major,EnrollmentSemester,EnrollmentYear,SubmissionDate, AdmissionDecision")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {

                if (applicant.MathScore + applicant.VerbalScore < 1000)
                {
                    ModelState.AddModelError("VerbalScore", "You are not qualified. The total of Math Score and Verbal Score must be greater than 1000");
                    return View(applicant);
                }

                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Applicant applicant = db.Applicants.Find(id);
            db.Applicants.Remove(applicant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
