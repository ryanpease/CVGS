/* Filename: ReportsController.cs
 * Description: This class is responsible for interaction with reports.
 * 
 * Revision History:
 *     Ryan Pease, 2016-10-23: Created
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoGameStore.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
    }
}