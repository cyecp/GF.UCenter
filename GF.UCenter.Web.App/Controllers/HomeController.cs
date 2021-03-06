﻿namespace GF.UCenter.Web.App.Controllers
{
    using System.ComponentModel.Composition;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using MongoDB;
    using MongoDB.Adapters;

    /// <summary>
    /// Provide a class for home controller.
    /// </summary>
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        private readonly DatabaseContext database;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="database">Indicating the database context</param>
        [ImportingConstructor]
        public HomeController(DatabaseContext database)
        {
            this.database = database;
        }

        /// <summary>
        /// Get the index page.
        /// </summary>
        /// <returns>action result.</returns>
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Get the user list page.
        /// </summary>
        /// <returns>action result.</returns>
        public ActionResult UserList()
        {
            return this.View();
        }

        /// <summary>
        /// Get the order list page.
        /// </summary>
        /// <param name="token">Indicating the cancellation token.</param>
        /// <param name="accountId">Indicating the account id.</param>
        /// <returns>action result.</returns>
        public async Task<ActionResult> OrderList(CancellationToken token, string accountId = null)
        {
            if (!string.IsNullOrEmpty(accountId))
            {
                var account = await this.database.Accounts.GetSingleAsync(accountId, token);
                ViewBag.AccountId = account.Id;
                ViewBag.AccountName = account.AccountName;
            }

            return this.View();
        }

        /// <summary>
        /// Gets the single order page.
        /// </summary>
        /// <param name="id">indicating the order id.</param>
        /// <returns>action result.</returns>
        public ActionResult SingleOrder(string id)
        {
            ViewBag.OrderId = id;
            return this.View();
        }

        /// <summary>
        /// Get the about page.
        /// </summary>
        /// <returns>action result.</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.View();
        }

        /// <summary>
        /// Get the contact page.
        /// </summary>
        /// <returns>action result.</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}