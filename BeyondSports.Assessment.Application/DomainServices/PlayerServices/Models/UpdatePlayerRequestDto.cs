using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.Assessment.Application.DomainServices.PlayerServices.Models
{
    public class UpdatePlayerRequestDto
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public short HeightInCentimeter { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
