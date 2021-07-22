using System;
using System.Collections.Generic;

#nullable disable

namespace wildlife.Models
{
    public partial class CertificateOtherDetail
    {
        public int? CertificateId { get; set; }
        public string Scientific { get; set; }
        public string Speciman { get; set; }
        public string Appendixno { get; set; }
        public string Source { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public string TotalExported { get; set; }
        public DateTime? Recorddate { get; set; }
        public string UserId { get; set; }
        public string Ip { get; set; }
        public int Id { get; set; }
    }
}
