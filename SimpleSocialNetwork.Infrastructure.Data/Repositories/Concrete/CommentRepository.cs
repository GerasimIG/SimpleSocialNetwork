using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;

namespace SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public IEnumerable<Comment> GetByPostId(int postId)
        {
            var postComments = dbContext.Posts.Find(postId).Comments;
            return postComments;
        }
    }
}
