//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRM
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_TRINHDO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_TRINHDO()
        {
            this.tb_NHANVIEN = new HashSet<tb_NHANVIEN>();
        }
    
        public int IDTD { get; set; }
        public string TENTD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_NHANVIEN> tb_NHANVIEN { get; set; }
    }
}
