# Buying & Owning Real Estate

This C# application that helps users determine the tax rate for a given municipality on a specific date. 
It uses Entity Framework Core with SQLite to manage and query tax data database.

## Project Structure
- `buying_owning_real_estate.csproj`: File containing project dependencies.
- `Program.cs`: Main entry point of the application.
- `Services/TaxService.cs`: Contains the `TaxService` class business logic to get tax rates.
- `Models/Municipality.cs`: Defines the `Municipality` entity class.
- `Models/Tax.cs`: Defines the `Tax` entity class.
- `Data/ApplicationDbContext.cs`: Defines the `ApplicationDbContext` class with Entity Framework Core.

## How to Run
1. **Clone the repository**:
    ```sh
    git clone https://github.com/UsernameDiana/buying_owning_real_estate.git
    cd buying_owning_real_estate
    ```

2. **Build the project**:
    ```sh
    dotnet build
    ```

3. **Run the application**:
    ```sh
    dotnet run
    ```

4. **Follow the prompts**:
    Enter the municipality name and date when prompted to get the tax rate.
    **Example:**
    ```
    Enter municipality name:
    Copenhagen
    Enter date (yyyy-mm-dd):
    2016-01-01
    Tax rate for Copenhagen on 2016-01-01 is 0,2
    ```
