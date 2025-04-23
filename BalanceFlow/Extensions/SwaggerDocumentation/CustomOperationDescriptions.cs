using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BalanceFlow.Extensions.SwaggerDocumentation
{
    public class CustomOperationDescriptions : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context?.ApiDescription?.HttpMethod is null || context.ApiDescription.RelativePath is null)
                return;

            var routeHandlers = new Dictionary<string, Action>
                {
                    { "cashEntry", () => HandleCashEntryOperations(operation, context) },
                    { "dailyBalance", () => HandleDailyBalanceOperations(operation, context) }
                };

            foreach (var routeHandler in routeHandlers)
            {
                if (context.ApiDescription.RelativePath.Contains(routeHandler.Key))
                {
                    routeHandler.Value.Invoke();
                    break;
                }
            }
        }

        private void HandleCashEntryOperations(OpenApiOperation operation, OperationFilterContext context)
        {
            var method = context.ApiDescription.HttpMethod;
            var path = context.ApiDescription.RelativePath?.ToLower() ?? string.Empty;

            if (method == "POST")
            {
                operation.Summary = "Create a new financial entry.";
                operation.Description = "Adds a new financial entry (debit or credit).";
                AddResponses(operation, "200", "The entry was successfully created.");
            }
            else if (method == "GET")
            {
                operation.Summary = "Retrieve all entries";
                operation.Description = "This endpoint allows you to retrieve details of all existing entries.";
                AddResponses(operation, "200", "All entries were successfully retrieved.");
            }
        }

        private void HandleDailyBalanceOperations(OpenApiOperation operation, OperationFilterContext context)
        {
            var method = context.ApiDescription.HttpMethod;
            var path = context.ApiDescription.RelativePath?.ToLower() ?? string.Empty;

            if (method == "POST")
            {
                operation.Summary = "Create a new daily balance.";
                operation.Description = "Adds a new daily balance.";
                AddResponses(operation, "200", "The daily balance was successfully created.");
            }
            else if (method == "GET")
            {
                operation.Summary = "Gets all daily consolidated balances";
                operation.Description = "This endpoint allows you to retrieve details of all daily consolidated balances.";
                AddResponses(operation, "200", "All daily consolidated balances were successfully retrieved.");
            }
        }

        private void AddResponses(OpenApiOperation operation, string statusCode, string description)
        {
            if (!operation.Responses.ContainsKey(statusCode))
            {
                operation.Responses.Add(statusCode, new OpenApiResponse { Description = description });
            }
        }
    }
}