namespace UdemyCarBook.Application.Features.RepositoryPattern
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        void Crete(T entity);
        void Update(T entity);
        void Remove(T entity);
        T GetById(int id);
        List<T> GetCommentsByBlogId(int id);
        public int GetCountCommentByBlog(int id);
    }
}
