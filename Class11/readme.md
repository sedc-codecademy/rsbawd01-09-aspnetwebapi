# Exercise 1: Implementing CRUD Operations in the `Movie App`

In this exercise, you will work with the `MovieRepository`, Service and Controller class, which is responsible for performing CRUD (Create, Read, Update, Delete) operations on notes in the MoviesApp database. Your task is to implement the existing methods to make the repository and other components fully functional.

## First steps:


1. **Database Configuration:**

   Adjust the connection string in the Program.cs file to match your database setup.

2. **Add a Migration:**

   Using Entity Framework, create a migration to represent changes in your data model. Use the following command: **add-migration YourMigrationName**

3. **Update the Database:**
    
    Apply the migration to update the database schema with the following command: **update-database**

4. **Explore the domain (Entity) classes**


# Exercise: Implementing Movie Service Methods

In this exercise, you will implement various methods in the `MovieService` class, which is responsible for handling business logic related to movies. The service interacts with the `IMovieRepository` to perform operations on movie data.

## Task:

Your goal is to complete the implementation of the methods in the `MovieService` class. Follow the instructions for each method to ensure accurate and functional behavior.

**1. Implement the `AddMovie` Method:**

   - Open the `MovieService` class.
   - Locate the `AddMovie` method, which adds a new movie to the database.
   - Implement the method to perform the following tasks:
      - Validate that the `Title` is not empty.
      - Validate that the `Year` is greater than 0.
      - Validate that the `Description` (if provided) does not exceed 250 characters.
      - Convert the `AddMovieDto` to a `Movie` entity.
      - Call the corresponding method in the `_movieRepository` to add the new movie to the database.

**2. Implement the `FilterMovies` Method:**

   - Locate the `FilterMovies` method in the `MovieService`. This method filters movies based on the provided `year` and `genre`.
   - Implement the method to perform the following tasks:
      - If `genre` is provided, validate if the value is a valid genre.
      - Call the corresponding method in the `_movieRepository` to filter movies by `year` and `genre`.
      - Convert the filtered movies to a list of `MovieDto` using the provided extension methods.

**3. Implement the `GetAllMovies` Method:**

   - Find the `GetAllMovies` method in the `MovieService`. This method retrieves all movies from the database.
   - Implement the method to call the corresponding method in the `_movieRepository` to get all movies and convert them to a list of `MovieDto`.

**4. Implement the `GetMovieById` Method:**

   - Locate the `GetMovieById` method in the `MovieService`. This method retrieves a movie by its unique identifier (`id`).
   - Implement the method to validate if the movie with the specified `id` exists in the database.
   - Call the corresponding method in the `_movieRepository` to get the movie by `id` and convert it to a `MovieDto`.

# Exercise: Implementing Movie Controller Actions

In this exercise, you will implement various actions in the `MoviesController` class, responsible for handling HTTP requests related to movies. The controller interacts with the `IMovieService` to perform operations on movie data.

## Task:

Your goal is to complete the implementation of the actions in the `MoviesController` class. Follow the instructions for each action to ensure accurate and functional behavior.

**1. Implement the `Get` Action:**

   - Open the `MoviesController` class.
   - Locate the `Get` action, which retrieves all movies.
   - Implement the action to call the corresponding method in the `_movieService` to get all movies.
   - Handle exceptions and return appropriate status codes and messages.

**2. Implement the `Filter` Action:**

   - Find the `Filter` action in the `MoviesController`. This action filters movies based on the provided `year` and `genre`.
   - Implement the action to call the corresponding method in the `_movieService` to filter movies by `year` and `genre`.
   - Handle exceptions and return appropriate status codes and messages.

**3. Implement the `GetById` Action:**

   - Locate the `GetById` action in the `MoviesController`. This action retrieves a movie by its unique identifier (`id`).
   - Implement the action to call the corresponding method in the `_movieService` to get the movie by `id`.
   - Handle exceptions and return appropriate status codes and messages.

# Exercise: Implement User Controller

### Action 1: Authenticate

#### **Analysis:**
This action handles the authentication of users. It takes a `LoginModelDto` as input, attempts to authenticate the user using the `IUserService`, and returns an appropriate response. If authentication is successful, it returns the user object; otherwise, it returns an error message.

#### **Text for Students:**
Write a method called `Authenticate` that takes a `LoginModelDto` as input and attempts to authenticate the user. Use the `IUserService` to perform the authentication. If the authentication is successful, return the authenticated user; otherwise, return an appropriate error message. Make sure to handle exceptions and provide meaningful error responses.

### Action 2: Register

#### **Analysis:**
This action handles user registration. It takes a `RegisterModelDto` as input, registers the user using the `IUserService`, and returns a success message or an error message if the registration fails.

#### **Text for Students:**
Implement a method named `Register` that takes a `RegisterModelDto` as input and registers the user using the `IUserService`. If the registration is successful, return a success message; otherwise, return an error message. Ensure that you handle exceptions and provide meaningful error responses. Additionally, implement any necessary validation for the registration process, such as password complexity and email format.

# Last part: Discuss the ASP.NET Core Auth with Trainer and Asistent
