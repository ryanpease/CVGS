/* Filename: EmployeeMetadata.cs
 * Description: This class is responsible for providing metadata and validation for employees.
 * 
 * Revision History:
 *     Ryan Pease, 2016-10-27: Created
 *     Ryan Pease, 2016-10-28: Updated
 *     Ryan Pease, 2016-10-29: Updated
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RPClassLibrary;
using System.Linq;
using System.Web;

namespace VideoGameStore.Models
{
    public class EmployeeMetadata
    {
        [Display(Name = "Employee ID")]
        public int employee_id { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string username { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string employee_password { get; set; }
        [Display(Name = "Login Failures")]
        public int login_failures { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string first_name { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }
        [Required]
        [Display(Name = "Phone")]
        [PhoneNumberValidation]
        public string phone { get; set; }
        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", 
            ErrorMessage = "Invalid email address format, please use a valid address (e.g. user@outlook.com).")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Gender")]
        [StringLength(1)]
        [RegularExpression("^([m | M | f | F])$", ErrorMessage = "Invalid value. Please enter M for Male, or F for Female.")]
        public string gender { get; set; }
        [Required]
        [Display(Name = "Birthdate")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime birthdate { get; set; }
        [Required]
        [Display(Name = "Date Hired")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime date_hired { get; set; }
        [Display(Name = "Admin?")]
        public bool is_admin { get; set; }
        [Display(Name = "Inactive?")]
        public bool is_inactive { get; set; }
        [Display(Name = "Locked Out?")]
        public bool is_locked_out { get; set; }
        [Display(Name = "Notes")]
        public string notes { get; set; }
    }

    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            first_name = RPValidations.Capitalize(first_name, true);
            last_name = RPValidations.Capitalize(last_name, true);
            gender = RPValidations.Capitalize(gender, false);
            yield return ValidationResult.Success;
        }
    }
}