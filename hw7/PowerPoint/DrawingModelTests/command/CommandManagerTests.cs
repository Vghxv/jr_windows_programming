using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace DrawingModel.Tests
{
    [TestClass]
    public class CommandManagerTests
    {
        [TestMethod]
        public void Execute_ShouldExecuteCommandAndPushToUndoStack()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();
            var commandManager = new CommandManager();

            // Act
            commandManager.Execute(commandMock.Object);

            // Assert
            commandMock.Verify(c => c.Execute(), Times.Once);
            Assert.AreEqual(1, GetPrivateField<Stack<ICommand>>(commandManager, "_undo").Count);
            Assert.AreEqual(0, GetPrivateField<Stack<ICommand>>(commandManager, "_redo").Count);
        }

        [TestMethod]
        public void Undo_ShouldUndoLastCommandAndPushToRedoStack()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();
            var commandManager = new CommandManager();
            commandManager.Execute(commandMock.Object);

            // Act
            commandManager.Undo();

            // Assert
            commandMock.Verify(c => c.ReverseExecute(), Times.Once);
            Assert.AreEqual(0, GetPrivateField<Stack<ICommand>>(commandManager, "_undo").Count);
            Assert.AreEqual(1, GetPrivateField<Stack<ICommand>>(commandManager, "_redo").Count);
        }

        [TestMethod]
        public void Redo_ShouldRedoLastUndoneCommandAndPushToUndoStack()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();
            var commandManager = new CommandManager();
            commandManager.Execute(commandMock.Object);
            commandManager.Undo();

            // Act
            commandManager.Redo();

            // Assert
            commandMock.Verify(c => c.Execute(), Times.Exactly(2));
            Assert.AreEqual(1, GetPrivateField<Stack<ICommand>>(commandManager, "_undo").Count);
            Assert.AreEqual(0, GetPrivateField<Stack<ICommand>>(commandManager, "_redo").Count);
        }

        [TestMethod]
        public void Redo_And_UndoShouldRedoLastUndoneCommandAndPushToUndoStack()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();
            var commandManager = new CommandManager();
            commandManager.Execute(commandMock.Object);
            commandManager.Execute(commandMock.Object);
            commandManager.Execute(commandMock.Object);
            commandManager.Undo();
            commandManager.Undo();
            commandManager.Undo();
            commandManager.Undo();
            commandManager.Undo();
            commandMock.Verify(c => c.Execute(), Times.Exactly(3));
            Assert.AreEqual(0, GetPrivateField<Stack<ICommand>>(commandManager, "_undo").Count);
            commandManager.Redo();
            commandManager.Redo();
            commandManager.Redo();
            commandManager.Redo();
            commandManager.Redo();
            commandMock.Verify(c => c.ReverseExecute(), Times.Exactly(3));
            Assert.AreEqual(0, GetPrivateField<Stack<ICommand>>(commandManager, "_redo").Count);
        }

        // Helper method to access private fields for testing
        private static T GetPrivateField<T>(object obj, string fieldName)
        {
            var field = obj.GetType().GetField(fieldName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            return (T)field?.GetValue(obj);
        }
    }
}
