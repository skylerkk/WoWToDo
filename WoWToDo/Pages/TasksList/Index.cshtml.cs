using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WoWToDo.Model;

namespace WoWToDo.Pages.TasksList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Tasks> Tasks { get; set; }
        public async Task OnGet()
        {
            Tasks = await _db.Tasks.ToListAsync();
        }
    }
}