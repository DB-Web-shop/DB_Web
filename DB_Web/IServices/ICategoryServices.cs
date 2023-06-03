using DB_Web.Models;

namespace DB_Web.IServices
{
    public interface ICategoryServices
    {
        Category Add(Category category);
        Category Update(Category category);
        Category Delete(int ID);
        Category GetCategory(int id);
        IEnumerable<Category> GetAllCategories();
    }
}
