//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wsInformante.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class APP_VI_INVESTIGATIONS
    {
        public APP_VI_INVESTIGATIONS()
        {
            this.APP_VI_CONTRIBUTIONS = new HashSet<APP_VI_CONTRIBUTIONS>();
            this.APP_VI_INVESTIGA_INVESTIGATORS = new HashSet<APP_VI_INVESTIGA_INVESTIGATORS>();
            this.APP_VI_INVESTIGATION_FILES = new HashSet<APP_VI_INVESTIGATION_FILES>();
        }
    
        public decimal INVESTIGATION_ID { get; set; }
        public decimal CRIME_ID { get; set; }
        public string NUNC { get; set; }
        public string TITLE { get; set; }
        public string DESCRIPTION { get; set; }
        public string STATE { get; set; }
        public string CITY { get; set; }
        public Nullable<System.DateTime> CRIME_DATE { get; set; }
        public Nullable<decimal> STATUS { get; set; }
    
        public virtual ICollection<APP_VI_CONTRIBUTIONS> APP_VI_CONTRIBUTIONS { get; set; }
        public virtual APP_VI_CRIMES APP_VI_CRIMES { get; set; }
        public virtual ICollection<APP_VI_INVESTIGA_INVESTIGATORS> APP_VI_INVESTIGA_INVESTIGATORS { get; set; }
        public virtual ICollection<APP_VI_INVESTIGATION_FILES> APP_VI_INVESTIGATION_FILES { get; set; }
    }
}
