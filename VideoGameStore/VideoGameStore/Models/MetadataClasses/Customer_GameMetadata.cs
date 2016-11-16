/* Filename: Customer_GameMetadata.cs
 * Description: This class is responsible for providing metadata and validation for customer games.
 * 
 * Revision History:
 *     Ryan Pease, 2016-10-29: Created
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RPClassLibrary;
using System.Linq;
using System.Web;

namespace VideoGameStore.Models
{
    public class Customer_GameMetadata
    {
        [Display(Name = "Customer Game ID")]
        public int customer_game_id { get; set; }
        [Required]
        [Display(Name = "Customer ID")]
        public int customer_id { get; set; }
        [Required]
        [Display(Name = "Game ID")]
        public int game_id { get; set; }
        [Required]
        [Display(Name = "Date Purchased")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DateNotInFuture]
        public System.DateTime date_purchased { get; set; }
        [Display(Name = "Rating")]
        [Range(0, 5)]
        public Nullable<int> rating { get; set; }
    }

    [MetadataType(typeof(Customer_GameMetadata))]
    public partial class Customer_Game
    {

    }
}