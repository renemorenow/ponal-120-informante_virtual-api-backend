//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wsInformante.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class APP_VI_CONTRIBUTIONS
    {
        public APP_VI_CONTRIBUTIONS()
        {
            this.APP_VI_CONTRIBUTIONS_FILES = new HashSet<APP_VI_CONTRIBUTIONS_FILES>();
        }
    
        public decimal CONTRIBUTION_ID { get; set; }
        public decimal INVESTIGATION_ID { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<decimal> INFORMANT_ID { get; set; }
    
        public virtual ICollection<APP_VI_CONTRIBUTIONS_FILES> APP_VI_CONTRIBUTIONS_FILES { get; set; }
        public virtual APP_VI_INFORMANTS APP_VI_INFORMANTS { get; set; }
        public virtual APP_VI_INVESTIGATIONS APP_VI_INVESTIGATIONS { get; set; }
    }
}
