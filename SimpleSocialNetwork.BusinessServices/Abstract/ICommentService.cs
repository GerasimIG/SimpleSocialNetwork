using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SimpleSocialNetwork.Domain;

namespace SimpleSocialNetwork.BusinessServices
{
    [ServiceContract]
    public interface ICommentService : IBaseService<Comment, CommentDto>
    {
        [OperationContract]
        List<CommentDto> GetByPostId(int postId);
    }

    [DataContract]
    public class CommentDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public System.DateTime DatePosted { get; set; }
        [DataMember]
        public int AuthorId { get; set; }
        [DataMember]
        public int PostId { get; set; }
    }
}
