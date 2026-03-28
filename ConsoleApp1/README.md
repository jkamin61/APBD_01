# University Equipment Rental System

## Project description
This project is a C# console application for managing a university equipment rental system.  
The system allows adding users and equipment, renting equipment, returning it, checking availability, and generating a simple summary report.

## Main features
- add users (`Student`, `Employee`)
- add equipment (`Laptop`, `Camera`, `Projector`)
- display all equipment
- display only available equipment
- rent equipment to users
- return equipment and calculate penalty for late return
- mark equipment as unavailable
- display active rentals for a selected user
- display overdue rentals
- generate a summary report

## Project structure
The project is divided into a few main parts:

- `domain` – domain classes such as `User`, `Equipment`, `Rental`
- `service` – business logic responsible for operations on users, equipment and rentals
- `exceptions` – custom exceptions used in invalid operations
- `Program.cs` – console scenario showing how the system works

## Design decisions
I tried to separate domain objects from business logic and from the console layer.

- `Equipment` and `User` are base classes for more specific types.
- `RentalService` contains the main rental logic such as checking limits, checking equipment availability, and calculating penalties.
- `EquipmentService` and `UserService` are responsible for managing their own data.
- `Program.cs` only demonstrates the system flow and does not contain the main business rules.

This structure was chosen to keep the code more readable and easier to modify.

## Cohesion, coupling and responsibilities
I tried to keep classes focused on one responsibility:
- domain classes describe the system objects
- services handle operations and business rules
- the console layer only displays results

Because of that, the project avoids putting all logic in one file and makes future changes easier.

## How to run
1. Open the project in JetBrains Rider or Visual Studio.
2. Build the solution.
3. Run the application from `Program.cs`.

## Example scenario
The application demonstrates:
- adding users and equipment
- successful rental
- invalid rental attempt
- return on time
- late return with penalty
- final report