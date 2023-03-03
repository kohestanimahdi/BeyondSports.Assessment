using BeyondSports.Assessment.Application.DomainServices.PlayerServices.Models;
using System.ComponentModel.DataAnnotations;

namespace BeyondSports.Assessment.API.Models.RequestModels
{
    public class AddPlayerRequest
    {
        [Required(ErrorMessage = "Enter the name of the player is required")]
        public string Name { get; set; }
        public short HeightInCentimeter { get; set; }
        public DateOnly BirthDate { get; set; }

        public AddPlayerRequestDto MapToDto() =>
            new AddPlayerRequestDto
            {
                BirthDate = BirthDate,
                Name = Name,
                HeightInCentimeter = HeightInCentimeter
            };
    }
}
