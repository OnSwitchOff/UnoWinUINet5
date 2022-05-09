using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataBase
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        {
            this.DataBaseCreated = Database.EnsureCreated();
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
            this.DataBaseCreated = Database.EnsureCreated();
        }

        public bool DataBaseCreated { get; private set; }

        public DbSet<Entities.ApplicationLog.ApplicationLog> ApplicationLogs => Set<Entities.ApplicationLog.ApplicationLog>();
        public DbSet<Entities.Documents.Document> Documents => Set<Entities.Documents.Document>();
        public DbSet<Entities.Exchanges.Exchange> Exchanges => Set<Entities.Exchanges.Exchange>();
        public DbSet<Entities.Items.Item> Items => Set<Entities.Items.Item>();
        public DbSet<Entities.ItemsCodes.ItemCode> ItemsCodes => Set<Entities.ItemsCodes.ItemCode>();
        public DbSet<Entities.ItemsGroups.ItemsGroup> ItemsGroups => Set<Entities.ItemsGroups.ItemsGroup>();
        public DbSet<Entities.OperationDetails.OperationDetail> OperationDetails => Set<Entities.OperationDetails.OperationDetail>();
        public DbSet<Entities.OperationHeader.OperationHeader> OperationHeaders => Set<Entities.OperationHeader.OperationHeader>();
        public DbSet<Entities.Partners.Partner> Partners => Set<Entities.Partners.Partner>();
        public DbSet<Entities.PartnersGroups.PartnersGroup> PartnersGroups => Set<Entities.PartnersGroups.PartnersGroup>();
        public DbSet<Entities.PaymentTypes.PaymentType> PaymentTypes => Set<Entities.PaymentTypes.PaymentType>();
        public DbSet<Entities.Serializations.Serialization> Serializations => Set<Entities.Serializations.Serialization>();
        public DbSet<Entities.Settings.Setting> Settings => Set<Entities.Settings.Setting>();
        public DbSet<Entities.Store.Store> Stores => Set<Entities.Store.Store>();
        public DbSet<Entities.VATGroups.VATGroup> Vatgroups => Set<Entities.VATGroups.VATGroup>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                string dataBasePath = string.Empty;
                if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
                {
                    dataBasePath = System.IO.Path.Combine(
                        System.IO.Path.GetPathRoot(Environment.SystemDirectory),
                        "ProgramData",
                        "Axis",
                        "Uno");

                    if (!System.IO.Directory.Exists(dataBasePath))
                    {
                        System.IO.Directory.CreateDirectory(dataBasePath);
                    }

                    dataBasePath = System.IO.Path.Combine(
                        dataBasePath,
                        "AxisUno.db");
                }
                else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Linux))
                {
                    dataBasePath = "dataBase231.db";
                }
                else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
                {
                    dataBasePath = "dataBase231.db";
                }
                else
                {
                    throw new Exception("Unidentified operating system!");
                }

                var connectionStringBuilder = new SqliteConnectionStringBuilder()
                {
                    DataSource = dataBasePath,
                };

                optionsBuilder.UseSqlite(connectionStringBuilder.ToString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
