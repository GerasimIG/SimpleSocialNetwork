using SimpleSocialNetwork.WebUI.CommentServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleSocialNetwork.WebUI.ApiControllers
{
    public class CommentsController : ApiController
    {
        private readonly CommentServiceClient _commentService;
        public CommentsController()
        {
            _commentService = new CommentServiceClient();
        }
        public HttpResponseMessage Get()
        {
            try
            {
                List<CommentDto> users = _commentService.GetAll();
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
                CommentDto user = _commentService.GetById(id);
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
                _commentService.RemoveById(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
            }
        }
    }
}