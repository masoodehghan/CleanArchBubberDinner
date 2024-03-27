namespace BubberDinner.Contracts.Menus;

public record MenuResponse(
    string id,
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
    string id,
    string Name,
    string Description,
    List<MenuItemResponse> MenuItemResponses
);

public record MenuItemResponse(
    string id,
    string Name,
    string Description
);

