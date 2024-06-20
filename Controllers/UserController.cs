using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
using System;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            return View(userlist);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Find the user in the userlist by their ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the specified ID, return a HttpNotFound result
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, return the Details view, passing in the user
            return View(user);
        }


        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // Validate the received user
                if (ModelState.IsValid)
                {
                    // Add the new user to the list
                    userlist.Add(user);

                    // Redirect to the Index view after adding the user to the list
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // For simplicity, we're just returning the same view with the user model
                // In a real application, you might want to display a user-friendly error message
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            // If we got this far, something failed, redisplay form
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // Find the user in the userlist by their ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the specified ID, return a HttpNotFound result
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, return the Edit view, passing in the user
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                // Check if the model state is valid
                if (ModelState.IsValid)
                {
                    // Find the existing user in the userlist
                    var existingUser = userlist.FirstOrDefault(u => u.Id == id);

                    // If no user is found with the specified ID, return a HttpNotFound result
                    if (existingUser == null)
                    {
                        return HttpNotFound();
                    }

                    // Update the existing user's properties with the values from the form
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;
                    // Update other properties as needed

                    // Redirect to the Index action to display the updated list of users
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // For simplicity, we're just returning the Edit view with the user model
                // In a real application, you might want to display a user-friendly error message
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            // If we got this far, something failed, redisplay form with the user data
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Find the user in the userlist by their ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the specified ID, return a HttpNotFound result
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, return the Delete view, passing in the user
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Find the user in the userlist by their ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If a user is found, remove the user from the list
            if (user != null)
            {
                userlist.Remove(user);
            }

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }
    }
}
