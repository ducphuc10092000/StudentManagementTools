//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentManagement.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class HOC_SINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOC_SINH()
        {
            this.CT_LOP_HOC_SINH = new HashSet<CT_LOP_HOC_SINH>();
            this.QUA_TRINH_HOC_HOC_KY = new HashSet<QUA_TRINH_HOC_HOC_KY>();
            this.QUA_TRINH_HOC_NAM_HOC = new HashSet<QUA_TRINH_HOC_NAM_HOC>();
        }
    
        public int MA_HOC_SINH { get; set; }
        public string HO_TEN { get; set; }
        public string SO_DIEN_THOAI { get; set; }
        public string DIA_CHI { get; set; }
        public string HO_TEN_CHA { get; set; }
        public string HO_TEN_ME { get; set; }
        public Nullable<int> MA_TON_GIAO { get; set; }
        public Nullable<int> MA_DAN_TOC { get; set; }
        public string SDT_PHU_HUYNH { get; set; }
        public string AVATAR { get; set; }
        public Nullable<int> MA_QUOC_TICH { get; set; }
        public string GIOI_TINH { get; set; }
        public string NGAY_SINH { get; set; }
        public Nullable<bool> DA_CO_LOP_HOC { get; set; }
        public Nullable<int> MA_LOP_DANG_HOC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_LOP_HOC_SINH> CT_LOP_HOC_SINH { get; set; }
        public virtual DAN_TOC DAN_TOC { get; set; }
        public virtual LOP LOP { get; set; }
        public virtual QUOC_TICH QUOC_TICH { get; set; }
        public virtual TON_GIAO TON_GIAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUA_TRINH_HOC_HOC_KY> QUA_TRINH_HOC_HOC_KY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUA_TRINH_HOC_NAM_HOC> QUA_TRINH_HOC_NAM_HOC { get; set; }
    }
}
