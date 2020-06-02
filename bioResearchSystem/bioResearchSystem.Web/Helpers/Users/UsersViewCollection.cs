using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Web.Helpers.Users
{
    public class UsersViewCollection:ObjectsViewCollection<AppUser>
    {
        public string IdCurrentUser { get; set; }
    }
}
