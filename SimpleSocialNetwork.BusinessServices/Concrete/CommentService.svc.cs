using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete;
using AutoMapper;

namespace SimpleSocialNetwork.BusinessServices
{
    public class CommentService : BaseService<Comment, CommentDto>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService()
        {
            _commentRepository = new CommentRepository();
            _repository = _commentRepository;
        }

        public List<CommentDto> GetByPostId(int postId)
        {
            var result = _commentRepository.GetByPostId(postId);

            List<CommentDto> list = null;

            if (result != null)
            {
                list = new List<CommentDto>();
                foreach(var el in result)
                {
                    var commentDto = Mapper.Map<CommentDto>(el);
                    list.Add(commentDto);
                }
            }

            return list;
        }

        public int GetCount()
        {
            return 5;
        }
    }
}
