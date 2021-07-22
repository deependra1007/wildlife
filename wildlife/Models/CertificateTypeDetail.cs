using System;
using System.Collections.Generic;

#nullable disable

namespace wildlife.Models
{
    public partial class CertificateTypeDetail
    {
        public int? CertificateId { get; set; }
        public string CertificateType { get; set; }
        public DateTime? Recorddate { get; set; }
        public string UserId { get; set; }
        public string Ip { get; set; }
        public int Id { get; set; }
    }
}
