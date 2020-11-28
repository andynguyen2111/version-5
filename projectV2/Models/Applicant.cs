using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GMUAdmissionPortal.Models
{
    public class Applicant
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(20, ErrorMessage = "First name can contain only 20 characters")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only characters are allowed")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(20, ErrorMessage = "Middle name can contain only 20 characters")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only characters are allowed")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(20, ErrorMessage = "Last name can contain only 20 characters")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only characters are allowed")]
        public string LastName { get; set; }

        [Display(Name = "SSN")]
        [Required(ErrorMessage = "Please enter your Social Security Number")]
        [MinLength(9, ErrorMessage = "Please enter a valid SSN with 9 numbers")]
        [StringLength(9, ErrorMessage = "Please enter a valid SSN with 9 numbers")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers are allowed")]
        public string SSN { get; set; }
        [Display(Name = "Email Adress")]
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string EmailAddress { get; set; }
        [Display(Name = "Home Phone")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers are allowed")]
        public string HomePhone { get; set; }
        [Display(Name = "Cell Phone")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers are allowed")]
        public string CellPhone { get; set; }

        // Address
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Display(Name = "City")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only characters are allowed")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Zip Code")]
         [Range(10000, 99999, ErrorMessage = "Zipcode must be 5 digits long.")]
        public int Zipcode { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        // High school
        [Display(Name = "Highschool Name")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only characters are allowed")]
        public string HSName { get; set; }
        [Display(Name = "Highschool City")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only characters are allowed")]
        public string HSCity { get; set; }

        // graduation
        [Display(Name = "Graduation Date")]
        [DataType(DataType.Date)]
        public DateTime GraduationDate { get; set; }

        [Display(Name = "Current GPA")]
        [Required]
        [Range(3.0, 4.0, ErrorMessage = "You are not qualified. The minimum GPA for admission is 3.0.")]
        public double GPA { get; set; }

        [Display(Name = "SAT Math Score")]
        [Required]
        [Range(0, 800, ErrorMessage = "Enter a SAT Score between 0-800.")]
        public int MathScore { get; set; }

        [Display(Name = "SAT Verbal Score")]
        [Required]
        [Range(0, 800, ErrorMessage = "Enter a SAT Score between 0-800.")]
        public int VerbalScore { get; set; }

        [Display(Name = "Primary Area of Interest")]
        public string Major { get; set; }

        // enrollment
        [Display(Name = "Enrollment Semester")]
        public string EnrollmentSemester { get; set; }
        [Display(Name = "Enrollment Year")]
        [Range(2020, 2026, ErrorMessage = "Enrollment year should be between 2020 and 2026")]
        public int EnrollmentYear { get; set; }

        [Display(Name = "Admission Decision")]
        public string AdmissionDecision { get; set; }

        [Display(Name = "Submission Date")]
        
        public DateTime SubmissionDate { get; set; }

    }
}