using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;
using System.Runtime.Serialization;

namespace SimpleSocialNetwork.BusinessServices
{
    [ServiceContract]
    public interface IPostService : IBaseService<Post, PostDto>
    {
        [OperationContract]
        List<PostDto> GetFriendsPostsByUserId(int userId);

        [OperationContract]
        List<PostDto> GetPosts(int authorId);
    }

    [DataContract]
    public class PostDto
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
        public string AuthorFirstName { get; set; }
        [DataMember]
        public string AuthorLastName { get; set; }
    }
}
