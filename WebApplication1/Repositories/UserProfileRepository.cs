using Jifter.Models;
using Jifter.Utils;

namespace Jifter.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(IConfiguration configuration) : base(configuration) { }
        public List<UserProfile> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT
                        Id,
                        Name,
                        Email,
                        ImageUrl,
                        DateCreated
                        FROM UserProfile";

                    var reader = cmd.ExecuteReader();

                    List<UserProfile> profiles = new List<UserProfile>();

                    while (reader.Read())
                    {
                        profiles.Add(new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            DateCreated = DbUtils.GetDateTime(reader, "DateCreated")
                        });
                    }

                    reader.Close();

                    return profiles;
                }
            }
        }

        public UserProfile GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT
                        Name,
                        Email,
                        ImageUrl,
                        DateCreated
                        FROM UserProfile
                        WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "Id", id);

                    var reader = cmd.ExecuteReader();

                    UserProfile profile = null;

                    if (reader.Read())
                    {
                        profile = new UserProfile()
                        {
                            Id = id,
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            DateCreated = DbUtils.GetDateTime(reader, "DateCreated")
                        };
                    }

                    reader.Close();

                    return profile;
                }
            }
        }

        public List<Post> GetUserPostsWithComments(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT
                        P.Id AS [PostId],
                        P.Title,
                        P.ImageUrl,
                        P.Caption,
                        P.DateCreated,
                        C.Id AS [CommentId],
                        C.Message AS [CommentMessage],
                        C.UserProfileId AS [CommentUserId],
                        C.PostId AS [CommentPostId]
                        FROM Post P
                        INNER JOIN Comment C
                        ON C.PostId = P.Id
                        WHERE P.UserProfileId = @Id";

                    DbUtils.AddParameter(cmd, "Id", id);

                    var reader = cmd.ExecuteReader();

                    List<Post> userPosts = new List<Post>();

                    while (reader.Read())
                    {
                        Post post = new Post()
                        {
                            Id = DbUtils.GetInt(reader, "PostId"),
                            Title = DbUtils.GetString(reader, "Title"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            Caption = DbUtils.GetString(reader, "Caption"),
                            DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                            UserProfileId = id,
                            Comments = new List<Comment> ()
                        };

                        if (DbUtils.IsNotDbNull(reader, "CommentId"))
                        {
                            post.Comments.Add(new Comment()
                            {
                                Id = DbUtils.GetInt(reader, "CommentId"),
                                Message = DbUtils.GetString(reader, "CommentMessage"),
                                UserProfileId = DbUtils.GetInt(reader, "CommentUserId"),
                                PostId = DbUtils.GetInt(reader, "CommentPostId")
                            });
                        }

                        userPosts.Add(post);
                    }

                    reader.Close();

                    return userPosts;
                }
            }
        }

        public void Add(UserProfile userProfile)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO UserProfile (Name, Email, ImageUrl, DateCreated)
                        OUTPUT INSERTED.ID
                        VALUES (@Name, @Email, @ImageUrl, @DateCreated)";

                    DbUtils.AddParameter(cmd, "Name", userProfile.Name);
                    DbUtils.AddParameter(cmd, "Email", userProfile.Email);
                    DbUtils.AddParameter(cmd, "ImageUrl", userProfile.ImageUrl);
                    DbUtils.AddParameter(cmd, "DateCreated", userProfile.DateCreated);

                    userProfile.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(UserProfile userProfile)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE UserProfile
                        SET Name = @Name, Email = @Email, ImageUrl = @ImageUrl
                        WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "Name", userProfile.Name);
                    DbUtils.AddParameter(cmd, "Email", userProfile.Email);
                    DbUtils.AddParameter(cmd, "ImageUrl", userProfile.ImageUrl);
                    DbUtils.AddParameter(cmd, "Id", userProfile.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        DELETE FROM UserProfile
                        WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "Id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
