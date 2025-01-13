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
        void Update(Post post);
    }
}