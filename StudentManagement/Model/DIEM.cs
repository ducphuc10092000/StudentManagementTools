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
    
    public partial class DIEM
    {
        public int MA_DIEM { get; set; }
        public Nullable<double> DIEM_SO { get; set; }
        public Nullable<int> MA_QTMH { get; set; }
        public Nullable<int> MA_MON_HOC { get; set; }
        public Nullable<int> MA_LOAI_DIEM { get; set; }
    
        public virtual LOAI_DIEM LOAI_DIEM { get; set; }
        public virtual QUA_TRINH_HOC_MON_HOC QUA_TRINH_HOC_MON_HOC { get; set; }
    }
}
