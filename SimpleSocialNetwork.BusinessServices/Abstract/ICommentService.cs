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
    public interface ICommentService : IBaseService<Comment>
    {
        [OperationContract]
        IEnumerable<Comment> GetByPostId(int postId);
    }
}
