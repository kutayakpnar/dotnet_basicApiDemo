namespace GameProject.Dtos;

public record class createGameDto(
    string Name,
    string Genre,
    decimal price,
    DateOnly ReleaseDate
);
