using System;
using System.Collections.Generic;

#nullable disable

namespace wildlife.Models
{
    public partial class CertificateCountryDetail
    {
        public int? CertificateId { get; set; }
        public string Origin { get; set; }
        public string Permitno { get; set; }
        public string Country { get; set; }
        public DateTime? CertificateDate { get; set; }
        public string NoOperation { get; set; }
        public DateTime? Recorddate { get; set; }
        public string UserId { get; set; }
        public string Ip { get; set; }
        public int Id { get; set; }
    }
}
