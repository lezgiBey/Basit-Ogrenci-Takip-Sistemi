//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication12
{
    using System;
    using System.Collections.Generic;
    
    public partial class users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public users()
        {
            this.duyurular = new HashSet<duyurular>();
        }
    
        public int id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }
        public Nullable<short> IllerId { get; set; }
        public Nullable<short> CinsiyetId { get; set; }
        public Nullable<short> RolId { get; set; }
        public Nullable<System.DateTime> Dogumtarihi { get; set; }
        public string Uyruk { get; set; }
        public Nullable<short> MedeniHalId { get; set; }
        public string WebSitesi { get; set; }
        public string Linkedin { get; set; }
        public short AskerlikDurumId { get; set; }
        public Nullable<short> ProgramId { get; set; }
        public Nullable<short> OgretimTurId { get; set; }
        public string GirisYili { get; set; }
        public string MezunYili { get; set; }
        public Nullable<double> DiplomaNotu { get; set; }
        public Nullable<short> CalismaDurumId { get; set; }
        public Nullable<short> BolumId { get; set; }
    
        public virtual askerlikdurumlari askerlikdurumlari { get; set; }
        public virtual bolumler bolumler { get; set; }
        public virtual calismadurumlari calismadurumlari { get; set; }
        public virtual cinsiyetler cinsiyetler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<duyurular> duyurular { get; set; }
        public virtual iller iller { get; set; }
        public virtual medenihaller medenihaller { get; set; }
        public virtual ogrenimturleri ogrenimturleri { get; set; }
        public virtual programlar programlar { get; set; }
        public virtual roller roller { get; set; }
    }
}
