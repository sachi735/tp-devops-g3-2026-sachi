namespace DevOpsTp.Api.Quests;

public static class QuestEndpoints
{
    public static RouteGroupBuilder MapQuestEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/quests")
            .WithTags("Quests");

        group.MapGet("/", GetAllQuests)
        .WithName("GetQuests");

        group.MapGet("/{id:int}", GetQuestById)
        .WithName("GetQuestById");

        group.MapGet("/summary", GetQuestSummary)
        .WithName("GetQuestSummary");

        group.MapPost("/", CreateQuest)
        .WithName("CreateQuest");

        group.MapPatch("/{id:int}/accept", AcceptQuest)
        .WithName("AcceptQuest");

        group.MapPatch("/{id:int}/complete", CompleteQuest)
        .WithName("CompleteQuest");

        group.MapPatch("/{id:int}/abandon", AbandonQuest)
        .WithName("AbandonQuest");

        return group;
    }

    private static IResult GetAllQuests(QuestStore store)
    {
        return Results.Ok(store.GetAll());
    }

    private static IResult GetQuestById(int id, QuestStore store)
    {
        var quest = store.GetById(id);
        return quest is null ? Results.NotFound() : Results.Ok(quest);
    }

    private static IResult GetQuestSummary(QuestStore store)
    {
        return Results.Ok(store.GetSummary());
    }

    private static IResult CreateQuest(CreateQuestRequest request, QuestStore store)
    {
        var errors = QuestValidation.ValidateCreate(request);
        if (errors.Length > 0)
        {
            return Results.BadRequest(new { errors });
        }

        var quest = store.Create(request);
        return Results.Created($"/api/quests/{quest.Id}", quest);
    }

    private static IResult AcceptQuest(int id, QuestStore store)
    {
        return UpdateQuestStatus(
            id,
            store,
            store.Accept,
            "only available quests can be accepted");
    }

    private static IResult CompleteQuest(int id, QuestStore store)
    {
        return UpdateQuestStatus(
            id,
            store,
            store.Complete,
            "only accepted quests can be completed");
    }

    private static IResult AbandonQuest(int id, QuestStore store)
    {
        return UpdateQuestStatus(
            id,
            store,
            store.Abandon,
            "only accepted quests can be abandoned");
    }

    private static IResult UpdateQuestStatus(
        int id,
        QuestStore store,
        Func<int, Quest?> updateQuest,
        string conflictMessage)
    {
        var existingQuest = store.GetById(id);
        if (existingQuest is null)
        {
            return Results.NotFound();
        }

        var quest = updateQuest(id);
        return quest is null
            ? Results.Conflict(new { error = conflictMessage })
            : Results.Ok(quest);
    }
}
