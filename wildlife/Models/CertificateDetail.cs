using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace wildlife.Models
{
    public partial class CertificateDetail
    {



        [Display(Name = "Certificate Number")]
        public string CertificateNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Validdate { get; set; }

        public bool IsExport { get; set; }
        public bool IsReExport { get; set; }
        public bool IsImport { get; set; }
        public bool IsOther { get; set; }
        public string ImporterAddress { get; set; }
        public string ImporterCountry { get; set; }
        public string ExporterAddress { get; set; }
        public string ExportPort { get; set; }
        public string SpecialCondition { get; set; }
        public string Purpose { get; set; }
        public string StampNo { get; set; }
        public string StampName { get; set; }
        public string StampAddress { get; set; }
        public string IssuedBy { get; set; }
        public string IssuedPlace { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? Recorddate { get; set; }
        public string UserId { get; set; }
        public string Ip { get; set; }



        public string ScientificA { get; set; }
        public string SpecimenA { get; set; }

        public string AppendixA { get; set; }
        public string TradeA { get; set; }
        public string QuantityA { get; set; }
        public string UnitA { get; set; }

        public string TotalExportedA { get; set; }

        public string ScientificB { get; set; }
        public string SpecimenB { get; set; }

        public string AppendixB { get; set; }
        public string TradeB { get; set; }
        public string QuantityB { get; set; }
        public string UnitB { get; set; }
        public string TotalExportedB { get; set; }
        public string ScientificC { get; set; }
        public string SpecimenC { get; set; }

        public string AppendixC { get; set; }
        public string TradeC { get; set; }
        public string QuantityC { get; set; }
        public string UnitC { get; set; }
        public string TotalExportedC { get; set; }


        public string OriginA { get; set; }
        public string PermitNoA { get; set; }
        public DateTime? DateA { get; set; }
        public string ReExportA { get; set; }
        public string CertificateNoA { get; set; }
        public DateTime? DateaA { get; set; }
        public string NoOfOperationA { get; set; }

        public string OriginB { get; set; }
        public string PermitNoB { get; set; }
        public DateTime? DateB { get; set; }
        public string ReExportB { get; set; }
        public string CertificateNoB { get; set; }
        public DateTime? DateaB { get; set; }
        public string NoOfOperationB { get; set; }

        public string OriginC { get; set; }
        public string PermitNoC { get; set; }
        public DateTime? DateC { get; set; }
        public string ReExportC { get; set; }
        public string CertificateNoC { get; set; }
        public DateTime? DateaC { get; set; }
        public string NoOfOperationC { get; set; }


        [Key]
        public int Id { get; set; }
    }
}
