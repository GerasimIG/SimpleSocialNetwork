using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocialNetwork.Domain.BL
{
    public static class Config
    {
        private const int _postsPerPage = 20;
        private const int _commentsPerPage = 20;
        private const int _usersPerPage = 20;
        private const int _messagesHistory = 30;
        private const int _autocompleteResults = 10;
        private const int _messageLength = 25;
        public static int PostsPerPage
        {
            get
            {
                return _postsPerPage;
            }
        }
        public static int CommentsPerPage
        {
            get
            {
                return _commentsPerPage;
            }
        }
        public static int UsersPerPage
        {
            get
            {
                return _usersPerPage;
            }
        }
        public static int MessagesHistory
        {
            get
            {
                return _messagesHistory;
            }
        }
        public static int AutocompleteResults
        {
            get
            {
                return _autocompleteResults;
            }
        }

        public static int MessageLength
        {
            get
            {
                return _messageLength;
            }
        }
    }
}
