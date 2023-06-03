using DB_Web.IServices;
using DB_Web.Models;
namespace DB_Web.Services
{
    public class ConfigswebServices : IConfigswebServices
    {
        private readonly DbWebContext db;
        public ConfigswebServices(DbWebContext db)
        {
            this.db = db;
        }

        public Configsweb GetConfigsweb()
        {
            return db.Configswebs.Where(x=>x.Id == 1).Single();
        }

        public Configsweb Update(Configsweb configsweb)
        {
            db.Update(configsweb);
            return configsweb;
        }
    }
}
