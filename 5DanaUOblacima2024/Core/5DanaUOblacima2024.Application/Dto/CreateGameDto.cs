using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5DanaUOblacima2024.Application.Dto
{
    public class CreateGameDto
    {
        public Guid Team1Id { get; set; }
        public Guid Team2Id { get; set; }
        public Guid WinnerId { get; set; }
        public int Duration { get; set; }
    }
}
