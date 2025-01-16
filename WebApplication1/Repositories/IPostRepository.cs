using Jifter.Models;

namespace Jifter.Repositories
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Delete(int id);
        List<Post> GetAll();
        Post GetByIdWithComments(int id);
        List<Post> GetAllWithComments();
        Post GetById(int id);
        List<Post> Search(string criterion, bool sortDescending);
        List<Post> Hottest(DateTime date);
        void Update(Post post);
    }
}