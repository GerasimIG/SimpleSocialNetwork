using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Sandbox.CommentServiceReference;
using System.Threading;
using SimpleSocialNetwork.Sandbox.UserServiceReference;

namespace SimpleSocialNetwork.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UserServiceClient cs = new UserServiceClient())
            {
                var p = cs.GetUserByEmail("1@1.com");
                var c = p;
            }            
            Console.ReadLine();
        }
    }
}
