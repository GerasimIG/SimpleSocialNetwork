using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Sandbox.CommentServiceReference;

namespace SimpleSocialNetwork.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            using (CommentServiceClient cs = new CommentServiceClient())
            {
                var p = cs.GetByPostId(1118);
                var c = p;
            }
            
            Console.ReadLine();
        }
    }
}
