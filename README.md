# Physical Person Directory
### Overview
The Physical Person Directory is a structured application designed for managing personal records. It is organized into three main components:

```📌 Project Structure```

🔹 PhysicalPersonDirectory.Api

    Handles the API layer, facilitating interactions between the user interface and backend services.

🔹 PhysicalPersonDirectory.Core

    Contains the core business logic and domain entities, managing key operations and data structures.

🔹 PhysicalPersonDirectory.Infra

    Manages infrastructure concerns, including data access implementations and external service integrations.

![image](https://github.com/user-attachments/assets/147c49cd-6ebc-4a75-b92f-f4824c2155df)


## 1️⃣ API Layer

🔹Technology: ASP.NET Web API

🔹Purpose: Acts as the entry point of the application, handling HTTP requests and routing them to the appropriate services.

## 2️⃣ Core Layer (Business Logic)
This is the heart of the application, consisting of multiple sub-layers:

🔹 Use Cases (Application Services) 

    Responsible for orchestrating API requests and business logic execution.

    Handles validations (DTO, DTO Validations).

🔹 Domain

    Defines the core entities.

    Implements Pure Business Logic (PBL) without dependencies on infrastructure or external services.

🔹 Data Access Object (DAO)

    Contains Business Data Access Objects (BDAO) to interact with the database.
    
    Uses Repository Pattern to manage database operations efficiently.
    
## 3️⃣ Infrastructure Layer
Handles external concerns such as data persistence and third-party services.

🔹 Data Access Layer (DAL)

    Generic SQL Repository: Manages database interactions with a common pattern.

    Generic File Repository: Handles file storage operations.

🔹 Third-Party Libraries

    Includes external libraries or services integrated into the system.
