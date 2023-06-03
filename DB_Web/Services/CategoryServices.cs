using DB_Web.IServices;
using DB_Web.Models;

namespace DB_Web.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly DbWebContext db;
        public CategoryServices(DbWebContext db)
        {
            this.db = db;
        }

        public Category Add(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category;
        }

        public Category Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return db.Categories;
        }

        public Category GetCategory(int id)
        {
             return db.Categories.Find(id);
        }

        public Category Update(Category category)
        {
            db.Update(category);
            db.SaveChanges();
            return category;
        }
    }
}
