# CategoriesController – Documentation

## 1. Overview

`CategoriesController` is an ASP.NET Core **MVC controller** responsible for managing recipe categories in the HealthyRecipes application.  
The controller communicates with the service layer and returns **Razor Views** to the user.

Its main responsibilities are:
- Displaying categories
- Creating new categories
- Editing existing categories
- Soft deleting categories

---

## 2. Security

The controller is **protected using ASP.NET Core Identity authentication**.

- The controller uses the `[Authorize]` attribute
- Only authenticated users can:
  - Create categories
  - Edit categories
  - Delete categories
- Anonymous users are allowed to:
  - View all categories
  - View category details

This ensures that only authorized users can modify application data.

---

## 3. Routing

Routing follows the default MVC convention.

The controller is accessible via the following route:


---

## 4. Controller Actions

### 4.1 Index

**HTTP Method:** GET  
**Route:** `/Categories`

#### Purpose
Displays a list of all active (not deleted) categories.

#### Parameters
- None

#### Return Value
- Razor View containing a collection of `Category` objects

#### Possible Unexpected Results
- Empty list if no categories exist in the database

---

### 4.2 Details

**HTTP Method:** GET  
**Route:** `/Categories/Details/{id}`

#### Purpose
Displays detailed information about a single category.

#### Parameters
- `Guid id` – Unique identifier of the category

#### Return Value
- Razor View containing a `Category` object

#### Possible Unexpected Results
- `404 Not Found` if the category does not exist or is soft deleted

---

### 4.3 Create (GET)

**HTTP Method:** GET  
**Route:** `/Categories/Create`

#### Purpose
Displays a form for creating a new category.

#### Parameters
- None

#### Return Value
- Razor View with an empty form

---

### 4.4 Create (POST)

**HTTP Method:** POST  
**Route:** `/Categories/Create`

#### Purpose
Creates a new category in the database.

#### Parameters
- `Category category` – Category object submitted from the form

#### Return Value
- Redirects to `Index` action after successful creation

#### Possible Unexpected Results
- Form is returned again if model validation fails

---

### 4.5 Edit (GET)

**HTTP Method:** GET  
**Route:** `/Categories/Edit/{id}`

#### Purpose
Displays a form for editing an existing category.

#### Parameters
- `Guid id` – Category identifier

#### Return Value
- Razor View containing the category data

#### Possible Unexpected Results
- `404 Not Found` if the category does not exist

---

### 4.6 Edit (POST)

**HTTP Method:** POST  
**Route:** `/Categories/Edit/{id}`

#### Purpose
Updates an existing category.

#### Parameters
- `Guid id` – Category identifier
- `Category category` – Updated category data

#### Return Value
- Redirects to `Index` after successful update

#### Possible Unexpected Results
- `400 Bad Request` if IDs do not match
- `404 Not Found` if the category does not exist

---

### 4.7 Delete (GET)

**HTTP Method:** GET  
**Route:** `/Categories/Delete/{id}`

#### Purpose
Displays a confirmation page for deleting a category.

#### Parameters
- `Guid id` – Category identifier

#### Return Value
- Razor View with category details

---

### 4.8 Delete (POST)

**HTTP Method:** POST  
**Route:** `/Categories/Delete/{id}`

#### Purpose
Performs a **soft delete** on the category.

#### Parameters
- `Guid id` – Category identifier

#### Return Value
- Redirects to `Index` after successful deletion

#### Possible Unexpected Results
- `404 Not Found` if the category does not exist

---

## 5. Used Service

The controller depends on the `CategoryService`, which implements the `ICategory` interface.

### Responsibilities of CategoryService:
- Communication with the database
- Business logic related to categories
- Soft delete implementation
- Data validation at service level

The controller accesses the service through dependency injection.

---

## 6. Database Models

### 6.1 Category Entity

The `Category` entity represents a recipe category in the system.

#### Key Characteristics:
- Uses `Guid` as primary key
- Supports **soft delete**
- Stores metadata for creation and updates
- Has a many-to-many relationship with recipes

#### Important Fields:
- `Id` – Primary key
- `Name` – Category name
- `Deleted` – Indicates soft deletion
- `CreatedAt` / `UpdatedAt` – Metadata timestamps

---

### 6.2 Ingredient Entity

The `Ingredient` entity represents a food ingredient with nutritional information.

#### Key Characteristics:
- Stores nutritional values per 100 grams
- Supports soft delete
- Can be linked to multiple recipes
- Can be associated with allergies

#### Important Fields:
- `Name` – Ingredient name
- `CaloriesPer100g`
- `ProteinPer100g`
- `CarbsPer100g`
- `FatPer100g`
- `Source` – Indicates ingredient origin
- `Deleted` – Soft delete flag

---

## 7. Architectural Benefits

- Clear separation of concerns (Controller → Service → Data)
- MVC pattern improves maintainability
- Soft delete prevents data loss
- Authentication protects critical actions
- Easily extendable for future features

