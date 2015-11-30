using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;

namespace SimpleSocialNetwork.BusinessServices
{
    [ServiceContract]
    public interface IPostService : IBaseService<Post>
    {
        [OperationContract]
        IEnumerable<Post> GetFriendsPostsByUserId(int userId);
    }
}
