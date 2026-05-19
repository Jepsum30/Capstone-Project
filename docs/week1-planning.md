Week 1 – Planning & Data Setup
1. Problem Statement
Insurance carriers struggle to assign incoming claims to the right adjuster efficiently. Manual assignment leads to delays, uneven workloads, and mismatches between adjuster skills and claim complexity.
The Adjuster Workload Optimizer solves this by automatically assigning claims based on skillset, jurisdiction, experience, and current workload.

2. Project Goals
Automate claim assignment using a rules‑based scoring engine.

Improve adjuster utilization and reduce backlog.

Provide transparent reasoning for each assignment.

Offer dashboards for supervisors to monitor workloads.

Support manual overrides with audit logging.

3. User Roles
Adjuster – Views assigned claims, workload, and performance history.

Supervisor/Admin – Reviews recommendations, overrides assignments, monitors team workload.

System – Processes incoming claims and generates assignment recommendations.

4. System Overview
The system ingests claim data, evaluates adjuster profiles, calculates a suitability score, and recommends the best adjuster.
A .NET API handles backend logic, MySQL stores data, and a Bootstrap UI displays dashboards.