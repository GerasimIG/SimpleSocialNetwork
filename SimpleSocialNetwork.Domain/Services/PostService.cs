using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain.Interfaces;

namespace SimpleSocialNetwork.Domain.Services
{
    public class PostService : BaseService<Post>, IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
            : base(postRepository)
        {
            _postRepository = postRepository;
        }

        public IEnumerable<Post> GetFriendsPostsByUserId(int userId)
        {
            return _postRepository.GetFriendsPostsByUserId(userId);
        }
    }
}
