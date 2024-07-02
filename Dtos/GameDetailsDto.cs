﻿namespace GameProject.Dtos;

public record class GameDetailsDto(
    int Id,
    string Name,
    int GenreId,
    decimal price,
    DateOnly ReleaseDate
    );
