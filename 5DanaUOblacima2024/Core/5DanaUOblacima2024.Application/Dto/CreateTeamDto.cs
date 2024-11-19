using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5DanaUOblacima2024.Application.Dto
{
    public class CreateTeamDto
    {
        public string Name { get; set; }
        public List<Guid> PlayerIds { get; set; }
    }
}
