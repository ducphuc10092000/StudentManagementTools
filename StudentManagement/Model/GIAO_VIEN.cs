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
    
    public partial class GIAO_VIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIAO_VIEN()
        {
            this.GIANG_DAY = new HashSet<GIANG_DAY>();
        }
    
        public int MA_GIAO_VIEN { get; set; }
        public string HO_TEN { get; set; }
        public System.DateTime NGAY_SINH { get; set; }
        public Nullable<int> GIOI_TINH { get; set; }
        public string SO_DIEN_THOAI { get; set; }
        public string EMAIL { get; set; }
        public Nullable<int> MA_TON_GIAO { get; set; }
        public Nullable<int> MA_DAN_TOC { get; set; }
        public Nullable<int> MA_BO_MON { get; set; }
        public Nullable<int> MA_TAI_KHOAN { get; set; }
    
        public virtual BO_MON BO_MON { get; set; }
        public virtual DAN_TOC DAN_TOC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIANG_DAY> GIANG_DAY { get; set; }
        public virtual TAI_KHOAN TAI_KHOAN { get; set; }
        public virtual TON_GIAO TON_GIAO { get; set; }
    }
}
