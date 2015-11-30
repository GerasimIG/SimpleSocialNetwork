using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete;

namespace SimpleSocialNetwork.BusinessServices.Concrete
{
    public class PostService : BaseService<Post>, IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService()
        {
            _postRepository = new PostRepository();
            _repository = _postRepository;
        }

        public IEnumerable<Post> GetFriendsPostsByUserId(int userId)
        {
            return _postRepository.GetFriendsPostsByUserId(userId);
        }
    }
}
