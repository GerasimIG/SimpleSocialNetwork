using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain.Interfaces;

namespace SimpleSocialNetwork.Domain.Services
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
            : base(commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IEnumerable<Comment> GetByPostId(int postId)
        {
            return _commentRepository.GetByPostId(postId);
        }
    }
}
