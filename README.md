# 🔥 FireSync

[![Deploy to Staging](https://github.com/akv3sic/firesync/actions/workflows/staging-docker-deploy.yml/badge.svg)](https://github.com/akv3sic/firesync/actions/workflows/staging-docker-deploy.yml)

FireSync is a comprehensive management system designed to assist fire departments, both volunteer and professional, in managing intervention logs, inventory, and staff competencies. This application aims to streamline operations, improve response times, and enhance overall efficiency within the fire department.

## Technologies

FireSync is built using the following technologies:

- **Blazor** - For creating a dynamic and interactive user interface.
- **.NET 9** - The backend framework providing robust support for the application’s logic.
- **MudBlazor** - A modern UI component library for Blazor, ensuring a responsive and sleek design.
- **PostgreSQL** - A reliable, open-source relational database used to store application data.
- **Docker** - For containerizing the PostgreSQL database and ensuring a consistent development environment.

## Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop)

### Setting Up the Project

1. **Clone the Repository:**

    ```bash
    git clone https://github.com/akv3sic/firesync
    cd firesync
    ```

2. **Setup PostgreSQL with Docker:**

    Create and start the PostgreSQL container using Docker Compose:

    ```bash
    docker-compose up -d
    ```

3. **Run the Application:**

    Start the Blazor Server application:

    ```bash
    dotnet run
    ```
    
