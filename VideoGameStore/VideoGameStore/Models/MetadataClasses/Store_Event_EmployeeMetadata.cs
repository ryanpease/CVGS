/* Filename: Store_Event_EmployeeMetadata.cs
 * Description: This class is responsible for providing metadata and validation for the employees registered to work at an event.
 * 
 * Revision History:
 *     Ryan Pease, 2016-10-29: Created
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoGameStore.Models
{
    public class Store_Event_EmployeeMetadata
    {
        [Display(Name = "Store Event Employee ID")]
        public int store_event_employee_id { get; set; }
        [Required]
        [Display(Name = "Store Event ID")]
        public int store_event_id { get; set; }
        [Required]
        [Display(Name = "Employee ID")]
        public int employee_id { get; set; }
    }

    [MetadataType(typeof(Store_Event_EmployeeMetadata))]
    public partial class Store_Event_Employee
    {

    }
}