using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ToDoList.Model
{
    public class User : IdentityUser
    {


        public ICollection<UniversalList> UniversalList { get; set; }
        public ICollection<Item> Items { get; set; }

    }
}
