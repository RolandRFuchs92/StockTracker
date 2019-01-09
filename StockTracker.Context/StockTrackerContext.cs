using Microsoft.EntityFrameworkCore;
using StockTracker.Context.Interface;
using StockTracker.Model.Clients;
using StockTracker.Model.Clients.Config;
using StockTracker.Model.ClientStock;
using StockTracker.Model.ClientStock.Config;
using StockTracker.Model.Comm.Config;
using StockTracker.Model.Members;
using StockTracker.Model.Members.Config;
using StockTracker.Model.Persons;
using StockTracker.Model.Persons.Config;
using StockTracker.Model.Shopping;
using StockTracker.Model.Shopping.Config;
using StockTracker.Model.Stock;
using StockTracker.Model.Stock.Config;
using StockTracker.Model.StockSupplier;
using StockTracker.Model.StockSupplier.Config;

namespace StockTracker.Context
{
    public class StockTrackerContext: DbContext, IStockTrackerContext 
    {
	    public StockTrackerContext()
	    {
	    }

	    public StockTrackerContext(DbContextOptions options)
		    : base(options)
	    {
	    }

		public virtual DbSet<Person> Persons { get; set; }
	    public virtual DbSet<Member> Members { get; set; }
	    public virtual DbSet<MemberRole> MemberRoles { get; set; }
	    public virtual DbSet<StockCore> StockCores { get; set; }
	    public virtual DbSet<ClientStockLevel> ClientStockLevel { get; set; }
	    public virtual DbSet<ClientStockItem> ClientStockItem { get; set; }
	    public virtual DbSet<ShoppingListItem> ShoppingListItems { get; set; }
	    public virtual DbSet<ShoppingList> ShoppingLists { get; set; }
	    public virtual DbSet<StockType> StockTypes { get; set; }
	    public virtual DbSet<StockCategory> StockCategories { get; set; }
	    public virtual DbSet<ClientSettings> ClientSettings { get; set; }
	    public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<StockSupplierDetail> StockSupplierDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ClientSettingsConfiguration());

            modelBuilder.ApplyConfiguration(new ClientStockItemConfiguration());
            modelBuilder.ApplyConfiguration(new ClientStockLevelConfigurtion());

            modelBuilder.ApplyConfiguration(new CommCoreConfiguration());
            //modelBuilder.ApplyConfiguration(new CommDetailConfiguration());
            //modelBuilder.ApplyConfiguration(new CommErrorConfiguration());
            modelBuilder.ApplyConfiguration(new CommSendStatusTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CommTypeConfiguration());

            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new MemberRoleConfiguration());


            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            modelBuilder.ApplyConfiguration(new ShoppingListConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingListItemConfiguration());

            modelBuilder.ApplyConfiguration(new StockCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new StockCoreConfiguration());
            modelBuilder.ApplyConfiguration(new StockTypeConfiguration());

            modelBuilder.ApplyConfiguration(new StockSupplierDetailConfiguration());


        }
    }
}
 