﻿using Services;
using Services.Exceptions;

namespace Tests
{
    [TestClass]
    public class NoteTestsMoq
    {
        [TestMethod]
        public void GetUserNotes_ValidUserId_AllNotesForThatUser()
        {
            // Arrange
            INoteService noteService = new NoteService(MockHelper.MockUserRepository(), MockHelper.MockNoteRepository());
            int expectedResult = 2;
            int userId = 1;
            // Act
            IEnumerable<NoteDto> result = noteService.GetUserNotes(userId);
            // Assert
            Assert.AreEqual(expectedResult, result.ToList().Count);
        }
        [TestMethod]
        public void GetUserNotes_InvalidUserId_null()
        {
            // Arrange
            INoteService noteService = new NoteService(MockHelper.MockUserRepository(), MockHelper.MockNoteRepository());
            int expectedResult = 0;
            int userId = 3;
            // Act
            IEnumerable<NoteDto> result = noteService.GetUserNotes(userId);
            // Assert
            Assert.AreEqual(expectedResult, result.ToList().Count);
        }
        [TestMethod]
        public void GetNote_ValidUserId_Note()
        {
            // Arrange
            INoteService noteService = new NoteService(MockHelper.MockUserRepository(), MockHelper.MockNoteRepository());
            int userId = 1;
            int noteId = 1;
            int expectedResult = 1;
            // Act
            NoteDto result = noteService.GetNote(noteId, userId);
            // Assert
            Assert.AreEqual(expectedResult, result.Id);
        }
        [TestMethod]
        public void GetNote_InvalidUserId_Exception()
        {
            // Arrange
            INoteService noteService = new NoteService(MockHelper.MockUserRepository(), MockHelper.MockNoteRepository());
            int userId = 1;
            int noteId = 9;
            // Act / Assert
            Assert.ThrowsException<NoteException>(() => noteService.GetNote(noteId, userId));
        }
        [TestMethod]
        public void AddNote_ValidNote_NoteAdded()
        {
            // Arrange
            INoteService noteService = new NoteService(MockHelper.MockUserRepository(), MockHelper.MockNoteRepository());
            int expectedResult = 3;
            NoteDto model = new NoteDto()
            {
                Id = 4,
                Text = "Test the app",
                Color = "red",
                Tag = TagType.Work,
                UserId = 1
            };
            // Act
            noteService.AddNote(model);
            // Assert
            IEnumerable<NoteDto> resultNotes = noteService.GetUserNotes(model.UserId);
            Assert.AreEqual(expectedResult, resultNotes.ToList().Count);
        }
        [TestMethod]
        public void DeleteNote_ValidNote_NoteDeleted()
        {
            // Arrange
            INoteService noteService = new NoteService(MockHelper.MockUserRepository(), MockHelper.MockNoteRepository());
            int expectedResult = 1;
            int userId = 1;
            int noteId = 1;
            // Act
            noteService.DeleteItem(noteId, userId);
            // Assert
            IEnumerable<NoteDto> resultNotes = noteService.GetUserNotes(userId);
            Assert.AreEqual(expectedResult, resultNotes.ToList().Count);
        }
    }
}
