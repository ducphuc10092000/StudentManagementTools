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
    
    public partial class HOC_KY
    {
        public int MA_HOC_KY { get; set; }
        public string TEN_HOC_KY { get; set; }
        public Nullable<int> MA_NAM_HOC { get; set; }
    
        public virtual NAM_HOC NAM_HOC { get; set; }
    }
}
