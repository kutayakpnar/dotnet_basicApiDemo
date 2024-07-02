using System.ComponentModel.DataAnnotations;

namespace GameProject.Dtos;

public record class createGameDto(
    [Required] [StringLength(50)] string Name,
    int  GenreId,
    [Range(1,100)]decimal price,
    DateOnly ReleaseDate
);
