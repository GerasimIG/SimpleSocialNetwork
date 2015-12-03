using SimpleSocialNetwork.WebUI.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleSocialNetwork.WebUI.ApiControllers
{
    public class UsersController : ApiController
    {
        private readonly UserServiceClient _userService;
        public UsersController()
        {
            _userService = new UserServiceClient();
        }
        public HttpResponseMessage Get()
        {
            try
            {
                List<UserDto> users = _userService.GetRandomUsers(10);
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
                UserDto user = _userService.GetById(id);
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
                 _userService.RemoveById(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
            }
        }
    }
}