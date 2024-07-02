namespace GameProject.Dtos;

public record class GameSummaryDto(
    int Id,
    string Name,
    string Genre,
    decimal price,
    DateOnly ReleaseDate
    );
