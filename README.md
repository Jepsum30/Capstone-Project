Week 2 – Backend API, Database Integration & UI Wiring
This week focused on building the full backend foundation for the Adjuster Workload Optimizer, integrating MySQL with Entity Framework Core, implementing all API endpoints, and wiring up the front‑end pages to live data. The result is a fully functional Week‑2 system with CRUD operations, working UI pages, and a stable database schema.

*Week 2 Objectives
Build complete EF Core models for all system entities

Create MySQL tables and enforce correct schema

Implement full CRUD API endpoints

Resolve navigation relationships and foreign keys

Fix serialization issues (circular references)

Connect UI pages to live API data

Push all changes to GitHub with documentation

*Database & Entity Framework Core
Completed Models
Adjuster

Claim

Assignment

PerformanceHistory

User

Each model includes:

Column mappings ([Column("FIELD_NAME")])

Table mappings ([Table("table_name")])

Navigation properties

Foreign key relationships

Database Fixes Completed
Corrected MySQL schema mismatches (INT → DECIMAL)

Fixed missing table name mapping (performance_history)

Cleaned invalid date formats

Added proper foreign key constraints

Ensured all tables match EF Core expectations

*ApplicationDbContext Configuration
All relationships are now correctly configured:

Assignment → Adjuster (many‑to‑one)

Assignment → Claim (many‑to‑one)

PerformanceHistory → Adjuster (many‑to‑one)

PerformanceHistory → Claim (many‑to‑one)

Circular reference issues were resolved using:

csharp
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
*API Endpoints (CRUD)
All endpoints are fully implemented and tested:

Adjusters
GET /api/Adjusters

GET /api/Adjusters/{id}

POST /api/Adjusters

PUT /api/Adjusters/{id}

DELETE /api/Adjusters/{id}

Claims
GET /api/Claims

GET /api/Claims/{id}

POST /api/Claims

PUT /api/Claims/{id}

DELETE /api/Claims/{id}

Assignments
GET /api/Assignments

GET /api/Assignments/{id}

POST /api/Assignments

PUT /api/Assignments/{id}

DELETE /api/Assignments/{id}

PerformanceHistory
GET /api/PerformanceHistory

GET /api/PerformanceHistory/{id}

POST /api/PerformanceHistory

PUT /api/PerformanceHistory/{id}

DELETE /api/PerformanceHistory/{id}

Users
GET /api/Users

POST /api/Users

Authentication endpoints (Week‑3)

*Front‑End Pages Completed
Working Pages
assignments.html — loads assignments from API

adjusters.html — displays adjuster list

claims.html — shows all claims

performance.html — loads performance history

register.html — user creation

login.html — authentication UI

dashboard.html — placeholder for Week‑3 analytics

All pages fetch live data from the API using JavaScript fetch() calls.

🧪 Testing Completed
Verified all CRUD endpoints in browser & Swagger

Confirmed MySQL inserts/updates/deletes

Validated UI pages load correct data

Ensured no circular reference crashes

Confirmed JSON output is stable and consistent

*GitHub Deliverables
All Week‑2 code pushed

.vs/, bin/, obj/ removed and ignored

Updated project structure

Clean commit history showing Week‑2 progress

* Recommended Screenshots for Submission
Place these in /docs/week2/:

Assignments page

Performance page

Claims page

Adjusters page

Swagger UI

MySQL table structure

API JSON output examples

*Week 2 Summary
Week‑2 successfully delivered a complete backend foundation, database integration, and functional UI pages. The system now supports full CRUD operations, stable data relationships, and live front‑end interaction. All major issues (table mismatches, circular references, type casting errors, date formatting, and EF navigation loops) were resolved.

The project is fully prepared for Week‑3 enhancements, including analytics, workload scoring, and assignment optimization logic.
