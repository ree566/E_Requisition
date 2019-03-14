//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_Requisition.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Requisition_Event = new HashSet<Requisition_Event>();
            this.User_Profile_REF = new HashSet<User_Profile_REF>();
            this.User_Profile_REF1 = new HashSet<User_Profile_REF>();
            this.User_Notification = new HashSet<User_Notification>();
        }
    
        public int id { get; set; }
        public string email { get; set; }
        public string jobnumber { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public int floor_id { get; set; }
        public int unit_id { get; set; }
    
        public virtual Floor Floor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Requisition_Event> Requisition_Event { get; set; }
        public virtual Unit Unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Profile_REF> User_Profile_REF { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Profile_REF> User_Profile_REF1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Notification> User_Notification { get; set; }
    }
}
