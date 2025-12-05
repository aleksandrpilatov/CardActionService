# Card Actions Service

A robust **.NET 8 Microservice** designed to evaluate and return allowed operations for user cards based on dynamic business rules.

This solution implements the requirements of the programming task with a strong focus on **Clean Architecture**, **Extensibility** (Open/Closed Principle), and **Reliability**.

## 📋 Project Overview

The service exposes a RESTful API endpoint that accepts a `UserId` and `CardNumber`, evaluates them against a business rules matrix (Card Type vs. Card Status), and returns a list of allowed actions (e.g., `ACTION1`, `ACTION2`).

### Key Features
*   **Framework:** Built on **.NET 8** (ASP.NET Core Web API).
*   **Architecture:** Implements the **Strategy Pattern (Rule Engine)** to decouple business logic from the HTTP layer.
*   **Validation:** Uses **FluentValidation** pipeline behaviors to strictly validate inputs (returning HTTP 400) before they reach the controller.
*   **Reliability:** Implements `IExceptionHandler` for centralized, modern Global Exception Handling (returning standardized HTTP 500 ProblemDetails).
*   **Observability:** Utilizes **Structured Logging** for clear and searchable logs.
*   **Documentation:** Fully integrated with **Swagger / OpenAPI**.

## 🏗️ Architectural Decisions

### 1. Extensibility (Rule Engine)
To meet the requirement of **"extensibility"** and avoid unmaintainable `if-else` chains, the business logic is implemented using the **Strategy Pattern**.
*   **Interface:** `IActionRule` defines the contract for a rule.
*   **Implementation:** Each rule (e.g., `Action6Rule`) is a separate class responsible for a specific logic requirement.
*   **Benefit:** Adding a new action type in the future requires **zero modifications** to the existing Controller or Service code. You simply create a new Rule class and register it.

### 2. Code Quality (Clean Controller)
The `CardActionsController` is kept strictly as an orchestration layer.
*   It does **not** contain manual checks like `string.IsNullOrWhiteSpace`.
*   Input validation is handled by the `FluentValidation` middleware, keeping the controller code clean and readable.

### 3. Error Handling
Traditional `try-catch` blocks are removed from the controllers.
*   The service uses the .NET 8 **`IExceptionHandler`** abstraction.
*   This ensures that all unhandled exceptions are caught globally, logged structurally, and returned as a safe **RFC 7807 ProblemDetails** response.

## 📂 Project Structure

```text
CardActionsService/
├── Controllers/
│   └── CardActionsController.cs    # Thin API Endpoint
├── DTOs/
│   ├── GetCardActionsRequest.cs    # Input Model (Route Parameters)
│   └── CardActionsResponse.cs      # Standardized Output Model
├── Extensions/
│   └── ServiceCollectionExtensions.cs # DI Container Configuration
├── Handlers/
│   └── GlobalExceptionHandler.cs   # Centralized 500 Error Handler
├── Models/
│   ├── CardDetails.cs              # Domain Entities & Enums
│   └── ...
├── Rules/                          # BUSINESS LOGIC (STRATEGY PATTERN)
│   ├── IActionRule.cs              # Rule Interface
│   └── ActionRules.cs              # Concrete Rule Implementations
├── Services/
│   ├── CardService.cs              # Data Provider (Mock)
│   └── CardActionService.cs        # Rule Orchestrator
├── Validators/
│   └── GetCardActionsRequestValidator.cs # FluentValidation Rules
└── Program.cs                      # App Configuration
