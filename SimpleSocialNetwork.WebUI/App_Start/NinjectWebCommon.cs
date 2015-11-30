[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SimpleSocialNetwork.WebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SimpleSocialNetwork.WebUI.App_Start.NinjectWebCommon), "Stop")]


namespace SimpleSocialNetwork.WebUI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    
    using SimpleSocialNetwork.Domain;
    using SimpleSocialNetwork.Domain.Interfaces;
    using SimpleSocialNetwork.Domain.Services;
    using SimpleSocialNetwork.Infrastructure.Data.Repositories;
    using SimpleSocialNetwork.WebUI.Authentication.Concrete;
    using SimpleSocialNetwork.WebUI.Authentication.Abstract;
    using SimpleSocialNetwork.WebUI.Security.Concrete;
    using SimpleSocialNetwork.WebUI.Security.Abstract;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            /*
            kernel.Bind(typeof(IBaseService<>)).To(typeof(BaseService<>));
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IFriendService>().To<FriendService>();
            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<IMessageService>().To<MessageService>();
            kernel.Bind<ILocationService>().To<LocationService>();
            */

            /*
            kernel.Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IFriendRepository>().To<FriendRepository>();
            kernel.Bind<IPostRepository>().To<PostRepository>();
            kernel.Bind<ICommentRepository>().To<CommentRepository>();
            kernel.Bind<IMessageRepository>().To<MessageRepository>();
            kernel.Bind<ILocationRepository>().To<LocationRepository>();
            */

            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
            kernel.Bind<IHash>().To<MD5Hash>();
        }        

    }
}
