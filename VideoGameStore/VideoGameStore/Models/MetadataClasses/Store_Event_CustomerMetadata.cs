/* Filename: Store_Event_CustomerMetadata.cs
 * Description: This class is responsible for providing metadata and validation for the customers registered for an event.
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
    public class Store_Event_CustomerMetadata
    {
        [Display(Name = "Store Event Customer ID")]
        public int store_event_customer_id { get; set; }
        [Required]
        [Display(Name = "Store Event ID")]
        public int store_event_id { get; set; }
        [Required]
        [Display(Name = "Customer ID")]
        public int customer_id { get; set; }
    }

    [MetadataType(typeof(Store_Event_CustomerMetadata))]
    public partial class Store_Event_Customer
    {

    }
}