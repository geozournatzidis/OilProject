using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GroupProject.DAL;
using GroupProject.Models;
using GroupProject.ViewModels;

namespace GroupProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Producers (UsersAccount)

        private OilProjectDbContext db = new OilProjectDbContext();

        //public ActionResult Index()
        //{

        //    return View(db.UsersAccounts.ToList());
        //}

        // GET: Instructors
        public ActionResult Index(int? id, int? oilPressID)
        {
            var viewModel = new ProducersData();

            // eager Loading
            viewModel.UsersAccounts = db.UsersAccounts
                .Include(i => i.OilPresses)
               //.Include(i => i.Factories)
                .OrderBy(i => i.LastName);

            if (id != null)
            {
                ViewBag.UserId = id.Value;
                viewModel.OilPresses = viewModel.UsersAccounts
                    .Where(i => i.UserId == id.Value).Single().OilPresses;
            }

            //if (oilPressID != null)
            //{
            //    ViewBag.oilPressID = oilPressID.Value;
            //    // Lazy Loading
            //    viewModel.Enrollments = viewModel.Courses
            //        .Where(c => c.oilPressID == oilPressID).Single().Enrollments;
     
            //}

            return View(viewModel);
        }


//-----------------------------------------Register Page-----------------------------------------------------------//     
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(UsersAccount account)
        {
            if (ModelState.IsValid)
            {
                db.UsersAccounts.Add(account);
                db.SaveChanges();


                ModelState.Clear();
                ViewBag.Message = account.FirstName + "" + account.LastName + "Successfully Registered";
            }
            return View();
        }

//--------------------------------------Login Page----------------------------------------------------------------------------//

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsersAccount user)
        {
            //using (OilProjectDbContext db = new OilProjectDbContext())
            //{
                //var obj = db.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();

                var usr = db.UsersAccounts.Where(u => u.UserName.Equals(user.UserName) && u.Password.Equals(user.Password)).FirstOrDefault();/*== user.UserName && u.Password == user.Password); */
                if (usr != null)
                {
                    Session["UserId"] = usr.UserId.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password is Wrong");
                }               
            //}

            return View();

        }
//------------------------------Edit Section-------------------------------------------------------------------------------//
        // GET: Departments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersAccount userAccount = await db.UsersAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            //ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "LastName", department.InstructorID);
            return View(userAccount);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId,FirstName,LastName,Email,UserName,Password,ConfirmPassword")] UsersAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccount).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "LastName", department.InstructorID);
            return View(userAccount);
        }

//------------------------------------Details Section-----------------------------------------------------------------------------------------//
        
            // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersAccount usersAccount = db.UsersAccounts.Find(id); // πήγαινε στη βάση και φέρε μου by id ένα record .. και φτιάχνω ένα απλό Object χωρίς να έχω φτιάξει constructor.Μέσω της Find();
            if (usersAccount == null)
            {
                return HttpNotFound();
            }
            return View(usersAccount);
        }


 //-------------------------------------------------------Delete Section-----------------------------------------------------------------------//

        // GET: Students/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false) // πάει στη βάση βρίσκει ένα student και ρωταέι αν θέλεις να σβηστεί 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            UsersAccount usersAccount = db.UsersAccounts.Find(id);
            if (usersAccount == null)
            {
                return HttpNotFound();
            }
            return View(usersAccount);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //try
            //{

            //    //OLDCODE 

            //    //Student student = db.Students.Find(id); // εδώ πάω δυο φορές στη βάση 
            //    //db.Students.Remove(student);

            //    //NEW CODE 
            //    UsersAccount userToDelete = new UsersAccount() { UserId = id };
            //    db.Entry(userToDelete).State = EntityState.Deleted; //Φτιάχνω ένα Object student και πάω μια μόνο φορά στη βάση 

            //    db.SaveChanges();

            //}
            //catch (DataException)
            //{
            //    return RedirectToAction("Delete", new { id = id, saveChangesError = true }); // τα παίρνει απο την από πάνω μέθοδο 
            //}

            //return RedirectToAction("Index"); // if everything goes well return to index page 

            //UsersAccount user = db.UsersAccounts.Find(id);

            //Doesn't work because it is also used in class OilPress , thus we have to add extra code 

            UsersAccount users = db.UsersAccounts
                 .Include(i => i.OilPresses)  // we use this because the UserId is also used in Oilpresses as foreign key 
                 .Where(i => i.UserId == id)
                 .Single();

            db.UsersAccounts.Remove(users);
            db.SaveChanges();

            return RedirectToAction("Index");   

        }

 //-------------------------------Create Section----------------------------------------------------------------------------------------//

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,Email,UserName,Password,ConfirmPassword")] UsersAccount usersAccount) // Include σημαίνει ότι έχω φτιάξει συγκεκριμένη whitelist περνόύν δηλαδή μόνο συγκεκριμένοι 
        {
            //είναι για λόγους ασφαλείας  "ID,LastName,FirstName,EnrollmentDate"
            try
            {
                if (ModelState.IsValid)
                {
                    db.UsersAccounts.Add(usersAccount);
                    db.SaveChanges();
                    return RedirectToAction("Index");   //We put a try catch because we might enter wrong data to the database.
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save Changes");
            }
            return View(usersAccount);
        }

        public ActionResult LoggedIn()
        {
            if(Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }
    }
}