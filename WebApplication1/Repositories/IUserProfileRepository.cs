using Jifter.Models;

namespace Jifter.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        void Delete(int id);
        List<UserProfile> GetAll();
        UserProfile GetById(int id);
        List<Post> GetUserPostsWithComments(int id);
        void Update(UserProfile userProfile);
    }
}