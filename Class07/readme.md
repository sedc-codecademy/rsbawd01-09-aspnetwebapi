# Exercise 1: Implementing CRUD Operations in the `NoteRepository`

In this exercise, you will work with the `NoteRepository` class, which is responsible for performing CRUD (Create, Read, Update, Delete) operations on notes in the NotesApp database. Your task is to implement the existing methods to make the repository fully functional.

## First steps:


1. **Database Configuration:**

   Adjust the connection string in the Program.cs file to match your database setup.

2. **Add a Migration:**

   Using Entity Framework, create a migration to represent changes in your data model. Use the following command: **add-migration YourMigrationName**

3. **Update the Database:**

Apply the migration to update the database schema with the following command: **update-database**


## Instructions:

1. **Implement the `Add` method:**

   The `Add` method is used to add a new note to the database. Implement this method by adding the provided note entity to the `_notesAppDbContext` and saving the changes to the database using the `SaveChanges` method.

2. **Implement the `Delete` method:**

   The `Delete` method should delete the given note entity from the database. You need to remove the entity from the `_notesAppDbContext` and then call `SaveChanges` to persist the changes.

3. **Implement the `GetAll` method:**

   The `GetAll` method should return a list of all notes in the database. Ensure that you join the `Notes` table with the `Users` table using the `Include` method. Return the list of notes.

4. **Implement the `GetById` method:**

   The `GetById` method should retrieve a note by its unique identifier (id). Join the `Notes` table with the `Users` table using `Include` and return the first note where the id matches the provided parameter.

5. **Implement the `Update` method:**

   The `Update` method is used to update an existing note in the database. Implement this method by updating the provided note entity within the `_notesAppDbContext` and then call `SaveChanges` to persist the changes.

# Exercise 2: Implementing Note Service Methods

In this exercise, you will implement the `AddNote`, `GetAllNotes`, and `GetById` methods in the `NoteService` class. The `NoteService` is responsible for managing notes in the NotesApp application.

## Instructions:

1. **Implement the `AddNote` Method:**

   - Open the `NoteService` class.
   - Locate the `AddNote` method. This method is responsible for adding a new note to the database.
   - Implement the method to perform the following tasks:
     - Validate the `addNoteDto` input.
     - Check if the user with the specified `UserId` exists.
     - Ensure that the `Text` field is not empty and does not exceed 100 characters.
     - Map the `addNoteDto` to a `Note` domain model.
     - Add the new note to the database using the `_noteRepository`.

2. **Implement the `GetAllNotes` Method:**

   - Locate the `GetAllNotes` method in the `NoteService` class. This method retrieves a list of all notes from the database.
   - Implement the method to perform the following tasks:
     - Retrieve all notes from the database using the `_noteRepository`.
     - Map the retrieved `Note` objects to `NoteDto` objects.
     - Return a list of `NoteDto` objects.

3. **Implement the `GetById` Method:**

   - Find the `GetById` method in the `NoteService` class. This method retrieves a note by its unique identifier (id).
   - Implement the method to perform the following tasks:
     - Retrieve the note with the specified `id` from the database using the `_noteRepository`.
     - Check if the note exists, and if not, throw a `NoteNotFoundException`.
     - Map the retrieved `Note` object to a `NoteDto` object.
     - Return the `NoteDto`.

## Note:

- Pay attention to input validation and error handling to ensure the methods handle various scenarios correctly.

By completing this exercise, you will have implemented essential functionality in the `NoteService` for adding, retrieving all notes, and retrieving notes by their unique identifiers.

# Exercise 3: Implementing Controller Actions in ASP.NET Core

In this exercise, you will implement controller actions in an ASP.NET Core application by calling methods from the service layer. The controller is responsible for handling HTTP requests and returning appropriate responses.

## Scenario:

You are working on a NotesApp project, and you need to implement controller actions for managing notes. The `NotesController` interacts with the `INoteService` to perform CRUD operations on notes.

## Instructions:

1. **Implement the `Get` Action:**

   - Open the `NotesController` class.
   - Locate the `Get` action, which handles HTTP GET requests to retrieve all notes.
   - Implement the action by calling the `GetAllNotes` method from the `_noteService`.
   - Return an HTTP 200 status code with the list of `NoteDto` objects as the response.

2. **Implement the `GetById` Action:**

   - Find the `GetById` action in the `NotesController`. This action handles HTTP GET requests to retrieve a single note by its `id`.
   - Implement the action by calling the `GetById` method from the `_noteService`.
   - Handle potential exceptions, such as `NoteNotFoundException`, and return the appropriate status codes with error messages.

3. **Implement the `AddNote` Action:**

   - Locate the `AddNote` action, which handles HTTP POST requests to add a new note.
   - Implement the action by calling the `AddNote` method from the `_noteService` with the provided data from the request body.
   - Handle potential exceptions, such as `NoteDataException`, and return the appropriate status codes with error messages.

4. **Implement the `UpdateNote` Action:**

   - Find the `UpdateNote` action in the `NotesController`. This action handles HTTP PUT requests to update an existing note.
   - Implement the action by calling the `UpdateNote` method from the `_noteService` with the provided data from the request body.
   - Handle potential exceptions, such as `NoteNotFoundException` and `NoteDataException`, and return the appropriate status codes with error messages.

5. **Implement the `DeleteNote` Action:**

   - Locate the `DeleteNote` action, which handles HTTP DELETE requests to delete a note by its `id`.
   - Implement the action by calling the `DeleteNote` method from the `_noteService`.
   - Handle potential exceptions, such as `NoteNotFoundException`, and return the appropriate status codes with success or error messages.

6. Test each of the implemented actions to ensure they work as expected by using tools like Postman or Swagger.

## Note:

- Pay attention to error handling and return the correct status codes and messages based on the outcomes of the service layer methods.

By completing this exercise, you will have implemented controller actions for managing notes in the NotesApp application by calling methods from the service layer.

# ----- Homework Assignment: Implementing User Management

In this homework assignment, you will implement the User management feature in an ASP.NET Core application. This feature includes creating a User controller, a User service, and a User repository to handle user-related operations.

## Task:

Your goal is to create the necessary components to manage users, including creating, retrieving, updating, and deleting user data.

**1. Implement the User Repository:**

   - Create a `UserRepository` class that implements the necessary methods to perform CRUD operations for users. This should include methods to add, retrieve, update, and delete user data. The user repository should interact with the database using Entity Framework or any other preferred database access technology.

**2. Implement the User Service:**

   - Create a `UserService` class that interacts with the `UserRepository`. The service should provide methods for adding, retrieving, updating, and deleting users. It should also include any necessary business logic, validation, and error handling related to user operations.

**3. Implement the User Controller:**

   - Create a `UserController` that handles HTTP requests related to users. Implement actions for creating new users, retrieving user information by ID, updating user details, and deleting users. The controller should call the corresponding methods from the `UserService` to perform these operations.

**4. Test the User Management Feature:**

   - Create test cases to ensure the functionality of the User management feature. Test each of the controller actions by sending HTTP requests (POST, GET, PUT, DELETE) using a tool like Postman. Verify that user data can be created, retrieved, updated, and deleted accurately, and look into database to see the data.
   
**5. Send github url to Zoka :)**

**&. Enjoy the weekend days**

