using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.DbProvider.Models
{
    public class Correlation
    {
        [Table("korrelation_suspicious")]
        public class CorrelationSuspicious
        {
            [Key, Column("id")]
            public int Id { get; set; }

            [Column("P_S_DateTime")]
            public DateTime DateTime { get; set; }

            [Column("P_S_Severity")]
            public string Severity { get; set; }

            [Column("P_S_LinkedHash")]
            public string LinkedHash { get; set; }
        }

        [Table("korrelation_suspicious_high")]
        public class CorrelationSuspiciousHigh
        {
            [Key, Column("id")]
            public int Id { get; set; }

            [Column("P_S_DateTime")]
            public DateTime DateTime { get; set; }

            [Column("P_S_Severity")]
            public string Severity { get; set; }

            [Column("P_S_LinkedHash")]
            public string LinkedHash { get; set; }
        }

        [Table("korrelation_awareness")]
        public class CorrelationAwareness
        {

            [Key, Column("id")]
            public int Id { get; set; }

            [Column("P_S_DateTime")]
            public DateTime DateTime { get; set; }

            [Column("P_S_Severity")]
            public string Severity { get; set; }

            [Column("P_S_LinkedHash")]
            public string LinkedHash { get; set; }
        }

        [Table("korrelation_awareness_high")]
        public class CorrelationAwarenessHigh
        {

            [Key, Column("id")]
            public int Id { get; set; }

            [Column("P_S_DateTime")]
            public DateTime DateTime { get; set; }

            [Column("P_S_Severity")]
            public string Severity { get; set; }

            [Column("P_S_LinkedHash")]
            public string LinkedHash { get; set; }
        }

        [Table("korrelation_analyze")]
        public class CorrelationAnalyze
        {

            [Key, Column("id")]
            public int Id { get; set; }

            [Column("P_S_DateTime")]
            public DateTime DateTime { get; set; }

            [Column("P_S_Severity")]
            public string Severity { get; set; }

            [Column("P_S_LinkedHash")]
            public string LinkedHash { get; set; }
        }
    }
}
