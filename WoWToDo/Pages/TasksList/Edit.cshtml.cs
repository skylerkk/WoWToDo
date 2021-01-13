using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WoWToDo.Model;

namespace WoWToDo.Pages.TasksList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Tasks Tasks { get; set; }
        public async Task OnGet(int id)
        {
            Tasks = await _db.Tasks.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var TasksFromDb = await _db.Tasks.FindAsync(Tasks.Id);
                TasksFromDb.Name = Tasks.Name;
                TasksFromDb.Location = Tasks.Location;
                TasksFromDb.Time = Tasks.Time;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}