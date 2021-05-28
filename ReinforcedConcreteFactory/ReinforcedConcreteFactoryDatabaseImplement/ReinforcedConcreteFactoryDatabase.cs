using Microsoft.EntityFrameworkCore;
using ReinforcedConcreteFactoryDatabaseImplement.Models;

namespace ReinforcedConcreteFactoryDatabaseImplement
{
    public class ReinforcedConcreteFactoryDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ReinforcedConcreteFactoryDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Material> Materials { set; get; }
        public virtual DbSet<Reinforced> Reinforceds { set; get; }
        public virtual DbSet<ReinforcedMaterial> ReinforcedMaterials { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<StoreHouse> StoreHouses { get; set; }
        public virtual DbSet<StoreHouseMaterial> StoreHouseMaterials { get; set; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Implementer> Implementers { set; get; }
        public virtual DbSet<MessageInfo> MessageInfos { set; get; }
    }
}
