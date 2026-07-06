# PSN Trophy Tracker

PSN Trophy Tracker is a personal fullstack web application for tracking PlayStation games, trophy progress, earned trophies, and missing trophies.

The main goal of the project is to provide a clear local dashboard for PlayStation trophy data, with a special focus on identifying pending trophies and sorting them by rarity.

This is an unofficial project and is not affiliated with Sony Interactive Entertainment or PlayStation.

## Project Idea

PlayStation trophy lists can become hard to follow across many games, especially when the user wants to know which trophies are still missing and which ones are the rarest.

This project is designed to solve that problem by synchronizing trophy data, storing it in a local relational database, and exposing it through a web interface.

The MVP focuses on three core questions:

- Which games are in the trophy list?
- Which trophies have already been earned for each game?
- Which trophies are still missing, ordered by rarity?

## Planned Features

- Dashboard with overall trophy progress.
- Games list with platform, progress, trophy counts, and last update date.
- Game details page with earned and pending trophies.
- Global missing trophies page.
- Sorting missing trophies by rarity.
- Filters by game, platform, trophy type, rarity, and completion status.
- Manual synchronization flow.
- Synchronization history with success and error status.
- Swagger/OpenAPI documentation for the backend.
- SQL Server persistence.
- Docker support for local infrastructure.

## Out of Scope for the MVP

The first version is intentionally focused and does not include:

- Public rankings.
- Social features.
- Comments.
- Multiple user accounts.
- Friend comparisons.
- Trophy guides.
- Mobile application.
- Production deployment.
- PSNProfiles scraping as a core dependency.

These features may be considered later, but they are not part of the initial scope.

## Tech Stack

### Backend

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- Dependency Injection
- HttpClientFactory

### Frontend

- Angular
- TypeScript
- Angular Router
- Angular Services
- Reactive Forms
- HTTP Client
- Angular Material or PrimeNG

### Infrastructure

- Docker Compose for SQL Server
- EF Core Migrations
- Environment variables or user secrets for sensitive settings

## Suggested Architecture

The backend is planned as a simple layered application:

```text
backend/
  TrophyTracker.Api/
  TrophyTracker.Application/
  TrophyTracker.Domain/
  TrophyTracker.Infrastructure/
```

### TrophyTracker.Api

Responsible for REST controllers, Swagger configuration, dependency injection, CORS, middleware, and error handling.

### TrophyTracker.Application

Responsible for use cases, services, DTOs, validation, and orchestration between the API, domain, and infrastructure layers.

### TrophyTracker.Domain

Responsible for core entities, enums, and domain rules.

### TrophyTracker.Infrastructure

Responsible for Entity Framework Core, database mappings, migrations, repositories, persistence, and external PlayStation trophy API integration.

## Core Domain Model

### Game

Represents a PlayStation game in the trophy list.

Typical fields:

- Title
- Platform
- Icon URL
- Progress
- Trophy counts
- PlayStation communication identifier
- Last update date

### Trophy

Represents a trophy that belongs to a game.

Typical fields:

- Name
- Description
- Type
- Hidden status
- Icon URL
- Game relationship

### UserTrophy

Represents the local status of a trophy.

Typical fields:

- Earned status
- Earned date
- Rarity
- Earned percentage
- Progress information

### SyncHistory

Represents a synchronization execution.

Typical fields:

- Start date
- Finish date
- Status
- Games processed
- Trophies processed
- Error message, when applicable

## Main Screens

### Dashboard

Displays overall progress, including total games, total trophies, earned trophies, missing trophies, platinum trophies, average progress, rarest missing trophy, and last synchronization date.

### Games

Lists synchronized games and allows filtering by title, platform, progress, and completion status.

### Game Details

Displays all trophies for a selected game, including type, rarity, earned status, earned date, hidden status, and icon.

### Missing Trophies

The main screen of the application. It lists all pending trophies across all games and sorts them by rarity, with the rarest trophies first.

### Sync History

Shows recent synchronization attempts and helps diagnose synchronization errors without exposing sensitive data.

## Conceptual API Endpoints

```text
POST /api/sync/psn
GET  /api/sync/history
GET  /api/sync/history/{id}

GET  /api/games
GET  /api/games/{id}
GET  /api/games/{id}/trophies

GET  /api/trophies/missing
GET  /api/trophies/earned
GET  /api/trophies/summary

GET  /api/dashboard
```

## Development Roadmap

1. Create the backend solution and project structure.
2. Configure SQL Server with Docker.
3. Add Entity Framework Core and the initial database model.
4. Seed controlled sample data.
5. Build game and trophy read endpoints.
6. Build the missing trophies endpoint with rarity sorting.
7. Create the Angular project and base layout.
8. Build the dashboard, games list, game details, and missing trophies screens.
9. Add synchronization history.
10. Add PlayStation trophy synchronization.
11. Improve error handling, pagination, filters, and logs.
12. Add basic automated tests.
13. Add screenshots and detailed setup instructions.

## Local Setup

The project is in an early stage. Detailed setup instructions will be added as the backend, frontend, and Docker files are created.

The expected local workflow will be:

```text
1. Start SQL Server with Docker Compose.
2. Run EF Core migrations.
3. Start the ASP.NET Core API.
4. Start the Angular frontend.
5. Open the web application in the browser.
```

## Security Notes

Sensitive data such as PlayStation authentication tokens must never be committed to the repository.

The frontend should not handle sensitive PlayStation credentials directly. External API authentication and synchronization should be handled by the backend.

## License

This project is licensed under the MIT License.
