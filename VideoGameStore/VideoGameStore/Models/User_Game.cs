//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VideoGameStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User_Game
    {
        public int user_game_id { get; set; }
        public int user_id { get; set; }
        public int game_id { get; set; }
        public System.DateTime date_purchased { get; set; }
        public Nullable<int> rating { get; set; }
    
        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}