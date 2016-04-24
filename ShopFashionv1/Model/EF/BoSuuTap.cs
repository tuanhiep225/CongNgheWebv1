namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoSuuTap")]
    public partial class BoSuuTap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BoSuuTap()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        public int MaBST { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="Bạn chưa điền tên bộ sưu tập")]
        public string TenBST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
