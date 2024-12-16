﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data_Layer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using System.Data.Common;
    using System.Data.Entity.Core.EntityClient;
    using System.Data.SqlClient;

    public partial class HRMEntities : DbContext
    {
        //public HRMEntities()
        //    : base("name=HRMEntities")
        //{

        //}
        
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tb_BAOHIEM> tb_BAOHIEM { get; set; }
        public virtual DbSet<tb_BOPHAN> tb_BOPHAN { get; set; }
        public virtual DbSet<tb_CHUCVU> tb_CHUCVU { get; set; }
        public virtual DbSet<tb_CHUYENNHANVIEN> tb_CHUYENNHANVIEN { get; set; }
        public virtual DbSet<tb_CONGTY> tb_CONGTY { get; set; }
        public virtual DbSet<tb_DANTOC> tb_DANTOC { get; set; }
        public virtual DbSet<tb_LUONGCOBAN> tb_LUONGCOBAN { get; set; }
        public virtual DbSet<tb_NHANVIEN_PHUCAP> tb_NHANVIEN_PHUCAP { get; set; }
        public virtual DbSet<tb_TONGIAO> tb_TONGIAO { get; set; }
        public virtual DbSet<tb_TRINHDO> tb_TRINHDO { get; set; }
        public virtual DbSet<tb_BANGCONG> tb_BANGCONG { get; set; }
        public virtual DbSet<tb_BANGCONG_CHITIET> tb_BANGCONG_CHITIET { get; set; }
        public virtual DbSet<tb_KYCONG> tb_KYCONG { get; set; }
        public virtual DbSet<tb_KYCONGCHITIET> tb_KYCONGCHITIET { get; set; }
        public virtual DbSet<tb_LOAICA> tb_LOAICA { get; set; }
        public virtual DbSet<tb_LOAICONG> tb_LOAICONG { get; set; }
        public virtual DbSet<tb_NANGLUONG> tb_NANGLUONG { get; set; }
        public virtual DbSet<tb_THOIVIEC> tb_THOIVIEC { get; set; }
        public virtual DbSet<tb_UNGLUONG> tb_UNGLUONG { get; set; }
        public virtual DbSet<tb_BANGLUONG> tb_BANGLUONG { get; set; }
        public virtual DbSet<tb_DANHSACHPHUCAP> tb_DANHSACHPHUCAP { get; set; }
        public virtual DbSet<tb_HOPDONG> tb_HOPDONG { get; set; }
        public virtual DbSet<tb_KHENTHUONG_KYLUAT> tb_KHENTHUONG_KYLUAT { get; set; }
        public virtual DbSet<tb_PHONGBAN> tb_PHONGBAN { get; set; }
        public virtual DbSet<tb_PHUCAP> tb_PHUCAP { get; set; }
        public virtual DbSet<tb_TANGCA> tb_TANGCA { get; set; }
        public virtual DbSet<tb_USER> tb_USER { get; set; }
        public virtual DbSet<tb_NHANVIEN> tb_NHANVIEN { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
