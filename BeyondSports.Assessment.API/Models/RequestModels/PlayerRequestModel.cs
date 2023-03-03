using BeyondSports.Assessment.Application.DomainServices.PlayerServices.Models;
using System.ComponentModel.DataAnnotations;

namespace BeyondSports.Assessment.API.Models.RequestModels
{
    public class PlayerRequestModel
    {
        [Required(ErrorMessage = "Enter the name of the player is required")]
        public string Name { get; set; }
        public short HeightInCentimeter { get; set; }
        public DateOnly BirthDate { get; set; }

        public AddPlayerRequestDto MapToCreateDto() =>
            new AddPlayerRequestDto
            {
                BirthDate = BirthDate,
                Name = Name,
                HeightInCentimeter = HeightInCentimeter
            };

        public UpdatePlayerRequestDto MapToUpdateDto(uint id) =>
            new UpdatePlayerRequestDto
            {
                Id = id,
                BirthDate = BirthDate,
                Name = Name,
                HeightInCentimeter = HeightInCentimeter
            };
    }
}
