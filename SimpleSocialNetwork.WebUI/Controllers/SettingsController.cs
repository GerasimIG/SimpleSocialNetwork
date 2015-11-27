using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleSocialNetwork.WebUI.ViewModels;
using SimpleSocialNetwork.WebUI.Authentication.Abstract;
using SimpleSocialNetwork.Domain.Interfaces;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.WebUI.Security.Abstract;
using AutoMapper;
using SimpleSocialNetwork.Domain.BL;

namespace SimpleSocialNetwork.WebUI.Controllers
{
    [Authorize(Roles = "ApprovedMember")] 
    public class SettingsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthProvider _authProvider;
        private readonly ILocationService _locationService;
        private readonly IHash _hash;
        public SettingsController(IUserService userService, IAuthProvider authProvider, 
            ILocationService locationService, IHash hash) 
        {
            _userService = userService;
            _authProvider = authProvider;
            _locationService = locationService;
            _hash = hash;
        }
        public ViewResult Index()
        {
            var user = _userService.GetById(_authProvider.CurrentUserId);

            var settingsViewModel = new SettingsViewModel()
            {
                UpdateLogin = Mapper.Map<SimpleSocialNetwork.WebUI.ViewModels.UpdateLoginViewModel>(user),
                UpdateProfile = Mapper.Map<SimpleSocialNetwork.WebUI.ViewModels.UpdateProfileViewModel>(user),
                UpdateProfileImage = Mapper.Map<SimpleSocialNetwork.WebUI.ViewModels.UpdateProfileImageViewModel>(user),
                UpdatePassword = new UpdatePasswordViewModel()
            };
           
            // подумати над тим, щоб використати модель
            ViewBag.CurrentUserId = _authProvider.CurrentUserId;
            
            IEnumerable<GenderTypes> genderTypes = Enum.GetValues(typeof(GenderTypes))
                                                           .Cast<GenderTypes>();
            // теж може якось винести з контроллера
            var projection = from gender in genderTypes
                             select new SelectListItem
                             {
                                 Value = ((byte)gender).ToString(),
                                 Text = gender.ToString()
                             };

            ViewBag.Genders = projection;

            return View(settingsViewModel);
        }

        public JsonResult GetLocations(string term)
        {
            // забрати меджік намбер
            var locations = _locationService.GetLocationsByCityTerm(term, Config.AutocompleteResults);

            // можна організувати, використовуючи view-model
            var projection = from l in locations
                             select new
                             {
                                 id = l.Id,
                                 label = l.CityName + ", " + l.RegionName + ", " + l.CountryCode
                             };

            return Json(projection.ToList(), JsonRequestBehavior.AllowGet);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePassword(UpdatePasswordViewModel model)
        {
            // подумати над покращенням валідації пароля + інформація про результат зміни пароля
            if (ModelState.IsValid)
            {
                System.Guid newPassword = _hash.HashString(model.NewPassword);
                System.Guid oldPassword = _hash.HashString(model.OldPassword);

                bool result = _userService.UpdatePassword(newPassword, oldPassword,_authProvider.CurrentUserId);
                if (result)
                {
                    return RedirectToAction("Index");
                }                  
                ModelState.AddModelError("", "Old password is incorrect");
            }
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateLogin(UpdateLoginViewModel model)
        {
            if (ModelState.IsValid)
            {   
               bool result = _userService.UpdateEmail(model.Email, _authProvider.CurrentUserId);
               if (result)
               {
                   return RedirectToAction("Index");
               }

               ModelState.AddModelError("", "Login is already taken");
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProfile(UpdateProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.LocationId == 0 && model.FullLocation != null)
                {
                    ModelState.AddModelError("", "Incorrect location, please select location from list");
                    return RedirectToAction("Index");
                }

                var user = _userService.GetById(_authProvider.CurrentUserId);

                Mapper.Map<UpdateProfileViewModel,SimpleSocialNetwork.Domain.User>(model, user);
                if (user.LocationId == 0) user.LocationId = null;
                _userService.Update(user);
            }
            return RedirectToAction("Index");
        }

        // Переробити, доробити, виключення, подумати, що робити з великими файлами
        [HttpPost]
        public ActionResult UpdateImage(HttpPostedFileBase userImage)
        {
            if (ModelState.IsValid)
            {
                if (userImage != null)
                {
                    string imageMimeType = userImage.ContentType;
                    byte[] imageData = new byte[userImage.ContentLength];
                    userImage.InputStream.Read(imageData, 0, userImage.ContentLength);

                    bool result = _userService.UpdateImage(imageData,imageMimeType,_authProvider.CurrentUserId);
                    if (!result)
                    {
                        ModelState.AddModelError("", "Select jpg, png or gif image ");
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
