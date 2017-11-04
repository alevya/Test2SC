using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestReportApp.DbProvider.Models
{
    public class Source
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("P_S_DateTime")]
        public DateTime DateTime { get; set; }

        [Column("P_S_Severity")]
        public string Severity { get; set; }
    }
}
