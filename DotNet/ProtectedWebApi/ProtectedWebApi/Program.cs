using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------------------------------------------------------
// JWT authentication
// -----------------------------------------------------------------------------
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

// Explicitly enable authentication and authorization middleware.
// Minimal APIs can add these automatically when the services are registered,
// but here the authentication pipeline is easier to see.
app.UseAuthentication();
app.UseAuthorization();

// =============================================================================
// PUBLIC ENDPOINT
// =============================================================================
app.MapGet("/", () => Results.Ok(new
{
    name = "Authentication Training API",
    message = "For training use only."
}));

// =============================================================================
// PART 1: API KEY / SHARED SECRET
// =============================================================================
//
// Expected header:
//
// X-Api-Key: <secret>
//
// The secret itself comes from configuration.
// -----------------------------------------------------------------------------
app.MapGet("/api/apikey", (HttpRequest request, IConfiguration configuration) =>
{
    var expectedApiKey = configuration["TrainingApi:ApiKey"];

    if (string.IsNullOrWhiteSpace(expectedApiKey))
    {
        // This is a SERVER configuration problem, not a client problem.
        return Results.Problem(
            title: "Server configuration error",
            detail: "The API key has not been configured.",
            statusCode: StatusCodes.Status500InternalServerError);
    }

    if (!request.Headers.TryGetValue("X-Api-Key", out var providedApiKey))
    {
        return Results.Json(
            new
            {
                error = "authentication_required",
                message = "X-Api-Key header is required."
            },
            statusCode: StatusCodes.Status401Unauthorized);
    }

    if (providedApiKey != expectedApiKey)
    {
        return Results.Json(
            new
            {
                error = "invalid_api_key",
                message = "The supplied API key is not valid."
            },
            statusCode: StatusCodes.Status401Unauthorized);
    }

    return Results.Ok(new
    {
        message = "API key accepted.",
        secretInformation = "The launch code is 12345."
    });
});

// -----------------------------------------------------------------------------
// API-key protected POST.
//
// This gives us an opportunity to distinguish:
//
// authentication failure -> 401
// malformed/invalid request -> 400 / 422
// success                -> 200
// -----------------------------------------------------------------------------
app.MapPost("/api/apikey/message",
    (HttpRequest request,
     IConfiguration configuration,
     MessageRequest message) =>
    {
        var expectedApiKey = configuration["TrainingApi:ApiKey"];

        if (string.IsNullOrWhiteSpace(expectedApiKey))
        {
            return Results.Problem(
                title: "Server configuration error",
                statusCode: StatusCodes.Status500InternalServerError);
        }

        if (!request.Headers.TryGetValue("X-Api-Key", out var providedApiKey) ||
            providedApiKey != expectedApiKey)
        {
            return Results.Json(
                new
                {
                    error = "invalid_authentication",
                    message = "A valid X-Api-Key header is required."
                },
                statusCode: StatusCodes.Status401Unauthorized);
        }

        // Authentication succeeded.
        // Now we are validating APPLICATION DATA.
        if (string.IsNullOrWhiteSpace(message.Text))
        {
            return Results.Json(
                new
                {
                    error = "validation_failed",
                    message = "Text must not be empty."
                },
                statusCode: StatusCodes.Status422UnprocessableEntity);
        }

        if (message.Text.Length > 100)
        {
            return Results.Json(
                new
                {
                    error = "validation_failed",
                    message = "Text must not exceed 100 characters."
                },
                statusCode: StatusCodes.Status422UnprocessableEntity);
        }

        return Results.Ok(new
        {
            received = message.Text,
            length = message.Text.Length
        });
    });

// =============================================================================
// PART 2: JWT BEARER AUTHENTICATION
// =============================================================================
//
// Important to remember:
// Do NOT manually read and validate the Authorization header.
//
// Instead, ASP.NET Core's JwtBearer authentication handler does this before the
// endpoint executes.
//
// No token       -> 401
// Invalid token  -> 401
// Expired token  -> 401
// Valid token    -> endpoint runs
// -----------------------------------------------------------------------------
app.MapGet("/api/jwt", (ClaimsPrincipal user) =>
    {
        return Results.Ok(new
        {
            message = "JWT accepted.",

            authenticated = user.Identity?.IsAuthenticated,
            authenticationType = user.Identity?.AuthenticationType,
            name = user.Identity?.Name,

            // The validated JWT has been converted into claims.
            claims = user.Claims.Select(c => new
            {
                type = c.Type,
                value = c.Value
            })
        });
    })
    .RequireAuthorization();

// =============================================================================
// JWT + REQUEST VALIDATION
// =============================================================================
//
// Valid authentication does not mean the request itself is valid.
// -----------------------------------------------------------------------------
app.MapPost("/api/jwt/message", (ClaimsPrincipal user, MessageRequest message) =>
    {
        if (string.IsNullOrWhiteSpace(message.Text))
        {
            return Results.Json(
                new
                {
                    error = "validation_failed",
                    message = "Text must not be empty."
                },
                statusCode: StatusCodes.Status422UnprocessableEntity);
        }

        if (message.Text.Length > 100)
        {
            return Results.Json(
                new
                {
                    error = "validation_failed",
                    message = "Text must not exceed 100 characters."
                },
                statusCode: StatusCodes.Status422UnprocessableEntity);
        }

        return Results.Ok(new
        {
            user = user.Identity?.Name,
            received = message.Text
        });
    })
    .RequireAuthorization();


// =============================================================================
// JWT + AUTHORIZATION
// =============================================================================
//
// This endpoint requires:
//
// 1. A valid JWT
// 2. The Admin role
//
// No/invalid token             -> 401
// Valid token, no Admin role   -> 403
// Valid token + Admin role     -> 200
// -----------------------------------------------------------------------------
app.MapGet("/api/jwt/admin", (ClaimsPrincipal user) =>
    {
        return Results.Ok(new
        {
            message = "Welcome to the admin endpoint.",
            user = user.Identity?.Name
        });
    })
    .RequireAuthorization(policy =>
        policy.RequireRole("Admin"));


// run the application
app.Run();


// =============================================================================
// DTOs
// =============================================================================
public record MessageRequest(string? Text);
