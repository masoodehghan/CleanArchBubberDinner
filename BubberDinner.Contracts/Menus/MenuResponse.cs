namespace BubberDinner.Contracts.Menus;

public record MenuResponse(
    string Id,
    string Name,
    string Description,
    float? AverageRating,
    List<MenuSectionResponse> MenuSectionResponses,
    string HostId,
    List<string> DinnerIds,
    List<string> MenuReviewIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record MenuSectionResponse(
    string Id,
    string Name,
    string Description,
    List<MenuItemResponse> MenuItemResponses
);

public record MenuItemResponse(
    string Id,
    string Name,
    string Description
);

