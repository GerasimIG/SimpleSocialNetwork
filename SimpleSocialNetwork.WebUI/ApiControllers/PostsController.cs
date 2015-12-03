using SimpleSocialNetwork.WebUI.PostServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleSocialNetwork.WebUI.ApiControllers
{
    public class PostsController : ApiController
    {
        private readonly PostServiceClient _postService;
        public PostsController()
        {
            _postService = new PostServiceClient();
        }
        public HttpResponseMessage Get()
        {
            try
            {
                List<PostDto> users = _postService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
            }
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                PostDto user = _postService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _postService.RemoveById(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
            }
        }
    }
}