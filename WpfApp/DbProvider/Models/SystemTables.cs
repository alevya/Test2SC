using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestReportApp.DbProvider.Models
{
    public class SystemTables
    {
        [Table("tables")]
        public class SystemTable
        {
            [Key, Column("id")]
            public int Id { get; set; }

            [Column("name")]
            public string Name { get; set; }

            [Column("inner_name")]
            public string InnerName { get; set; }
        }

        [Table("notification_groups")]
        public class SystemNotificationGroup
        {
            [Key, Column("id")]
            public int Id { get; set; }

            [Column("name")]
            public string Name { get; set; }

            [Column("switch")]
            public string Switch { get; set; }
        }
    }
}
