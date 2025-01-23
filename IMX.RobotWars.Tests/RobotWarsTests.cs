using IMX.RobotWars;

namespace IMX.RobotWars.Tests
{
    [TestClass]
    public class RobotWarsTests
    {
        private readonly Arena _arena = new Arena(5, 5);
        [TestMethod]
        public void TestInitialPosition()
        {
            // Arrange
            var robot = new Robot(_arena, new Position(1, 2, 'N'));

            // Assert
            Assert.AreEqual(1, robot.GetPosition().X);
            Assert.AreEqual(2, robot.GetPosition().Y);
            Assert.AreEqual('N', robot.GetPosition().Heading);
        }

        [TestMethod]
        public void TestSpinLeft()
        {
            // Arrange
            var robot = new Robot(_arena, new Position(0, 0, 'N'));

            // Act
            robot.ProcessCommands("L");

            // Assert
            Assert.AreEqual('W', robot.GetPosition().Heading);
        }

        [TestMethod]
        public void TestSpinRight()
        {
            var robot = new Robot(_arena, new Position(0, 0, 'N'));

            robot.ProcessCommands("R");

            Assert.AreEqual('E', robot.GetPosition().Heading);
        }

        [TestMethod]
        public void TestMoveNorth()
        {
            var robot = new Robot(_arena, new Position(1, 2, 'N'));

            robot.ProcessCommands("M");

            Assert.AreEqual(3, robot.GetPosition().Y);
        }

        [TestMethod]
        public void TestMoveSouth()
        {
            var robot = new Robot(_arena, new Position(1, 2, 'S'));

            robot.ProcessCommands("M");

            Assert.AreEqual(1, robot.GetPosition().Y);
        }

        [TestMethod]
        public void TestMoveEast()
        {
            var robot = new Robot(_arena, new Position(1, 2, 'E'));

            robot.ProcessCommands("M");

            Assert.AreEqual(2, robot.GetPosition().X);
        }

        [TestMethod]
        public void TestMoveWest()
        {
            var robot = new Robot(_arena, new Position(1, 2, 'W'));

            robot.ProcessCommands("M");

            Assert.AreEqual(0, robot.GetPosition().X);
        }

        [TestMethod]
        public void TestComplexInstructions()
        {
            var robot = new Robot(_arena, new Position(1, 2, 'N'));

            robot.ProcessCommands("LMLMLMLMM");

            Assert.AreEqual(1, robot.GetPosition().X);
            Assert.AreEqual(3, robot.GetPosition().Y);
            Assert.AreEqual('N', robot.GetPosition().Heading);
        }

        [TestMethod]
        public void TestBoundaryConstraints()
        {
            var robot = new Robot(_arena, new Position(5, 5, 'N'));

            robot.ProcessCommands("M");

            Assert.AreEqual(5, robot.GetPosition().Y);
        }

        [TestMethod]
        public void TestMultipleRotations()
        {
            var robot = new Robot(_arena, new Position(0, 0, 'N'));

            robot.ProcessCommands("LLRR");

            Assert.AreEqual('N', robot.GetPosition().Heading);
        }
    }
}