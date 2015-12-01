using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete;
using AutoMapper;

namespace SimpleSocialNetwork.BusinessServices.Concrete
{
    public class PostService : BaseService<Post, PostDto>, IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService()
        {
            _postRepository = new PostRepository();
            _repository = _postRepository;
        }

        public List<PostDto> GetFriendsPostsByUserId(int userId)
        {
            var result = _postRepository.GetFriendsPostsByUserId(userId);

            List<PostDto> list = null;

            if (result != null)
            {
                list = new List<PostDto>();
                foreach (var el in result)
                {
                    var postDto = Mapper.Map<PostDto>(el);
                    list.Add(postDto);
                }
            }

            return list;
        }
    }
}
