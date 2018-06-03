using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoFixture;
using Moq;
using TicTacToe;

namespace DatabaseTests
{
    [TestClass]
    public class TicTacTests
    {
        [TestMethod]
        public void Game_is_ended()
        {
            //Arrange
            var _col = new Fixture().Create<bool>();
            var _row = new Fixture().Create<bool>();
            var _diag = new Fixture().Create<bool>();
            var _full = new Fixture().Create<bool>();
            var winner = new Fixture().Create<string>();

            /*bool _col = false;
            bool _row = false;
            bool _diag = false;
            bool _full = false;*/

            StatusBox stbx = new StatusBox();

            //Act
            stbx.WriteStatus_End(_row, _col, _diag, _full, winner);

            //Assert
            if (_col || _row || _diag || _full)
            {
                Assert.AreEqual("Игра окончена! Победили " + winner + ".\n", stbx.lastTextWritten, false);
            }
            else { Assert.IsNull(stbx.lastTextWritten); }
            
        }

        [TestMethod]
        public void CellTestByMock()
        {
            //Arrange
            var mock = new Mock<IMark>();            
            var cell = new Cell(mock.Object);
            var str = new Fixture().Create<string>();

            mock.Setup(x => x.PlaceMark(It.IsAny<string>())).Returns(str);

            //Act
            //cell.PlaceMark(str);

            //Assert
            Assert.AreEqual(str, cell.PlaceMark(str));
        }

        [TestMethod]
        public void MarkProv_Fake()
        {
            //Arrange
            //var imarkProvider = new MarkProviderFake();       //If uncomment MarkProviderFake...
            var imarkProvider = new MarkProvider();             //...and comment MarkProvider then test is failed
            var cr = new Cell(imarkProvider);      
            var str = new Fixture().Create<string>();

            //Act
            //cr.PlaceMark(str);

            //Assert
            Assert.AreEqual(str, cr.PlaceMark(str));
        }

    }


}
