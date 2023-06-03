using DB_Web.Models;
namespace DB_Web.IServices
{
    public interface IConfigswebServices
    {
        Configsweb Update(Configsweb configsweb);
        Configsweb GetConfigsweb();
    }
}
