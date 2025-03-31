using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciple
{

    // -------------------- SRP: Separate Responsibilities -------------------- //
    // Models
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PostedOn { get; set; } = DateTime.Now;
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
    }
    // Service following SRP

    public class PostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public void CreatePost(Post post)
        {
            _postRepository.Add(post);
            Console.WriteLine("Post Created: " + post.Title);
        }
    }
    public class UserService
    {
        public void RegisterUser(User user)
        {
            Console.WriteLine("User Created: " + user.Name);
        }
    }
    // -------------------- OCP: Extend Functionality Without Modification -------------------- //
    public interface IPostRepository
    {
        void Add(Post post);
    }
    public class SqlPostRepository : IPostRepository
    {
        public void Add(Post post)
        {
            Console.WriteLine("Post saved to SQL Database.");
        }
    }
    public class NoSqlPostRepository : IPostRepository
    {
        public void Add(Post post)
        {
            Console.WriteLine("Post saved to NoSQL Database.");
        }
    }
    // -------------------- LSP: Substitutable User Types -------------------- //

    public class PremiumUser : User
    {
        public void AccessPremiumContent()
        {
            Console.WriteLine("Accessing premium content...");

        }
    }
    public class GustUser : User
    {
        public void AccessFreeContent()
        {
            Console.WriteLine("Accessing free content...");
        }
    }
    // -------------------- ISP: Separate Small Interfaces -------------------- //

    public interface ICementable
    {
        void AddComment(string comment);
    }
    public interface ILikeable
    {
        void Like();
    }
    public class CommentService : ICementable
    {
        public void AddComment(string comment)
        {
            Console.WriteLine("Comment Added: " + comment);
        }
    }
    public class LikeService : ILikeable
    {
        public void Like()
        {
            Console.WriteLine("Post Liked!");
        }
    }
    // -------------------- DIP: Inject Dependencies -------------------- //

    //public class ProgramOne
    //{
    //    static void Main(string[] args)
    //    {
    //        IPostRepository sqlRepository = new SqlPostRepository();
    //        PostService postService = new PostService(sqlRepository);
    //        UserService userService = new UserService();
    //        CommentService commentService = new CommentService();
    //        LikeService likeService = new LikeService();

    //        PremiumUser user = new PremiumUser { Id = 1, Name = "John Doe", Email = "test@Gmail.com", Mobile = "9870987890" };
    //        userService.RegisterUser(user);
    //        user.AccessPremiumContent();

    //        Post post = new Post { Id = 1, Title = "SOLID Principles", Content = "Understanding SOLID in C#", Author = "Raghu", PostedOn = DateTime.Now };
    //        postService.CreatePost(post);

    //        // User interacts with the post
    //        likeService.Like();
    //        commentService.AddComment("Great explanation of SOLID principles!");

    //        Console.ReadLine();
    //    }
    //}
}
