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

namespace SimpleSocialNetwork.BusinessServices
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService()
        {
            _commentRepository = new CommentRepository();
            
        }

        public IEnumerable<Comment> GetByPostId(int postId)
        {
            return _commentRepository.GetByPostId(postId);
        }
    }
}
