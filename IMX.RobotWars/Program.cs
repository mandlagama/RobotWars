// See https://aka.ms/new-console-template for more information
using IMX.RobotWars;

var arena = new Arena(5, 5);//setup 5x5 arena

var robot1 = new Robot(arena, new Position(1, 2, 'N'));//first robot
robot1.ProcessCommands("LMLMLMLMM");
var newPosition = robot1.GetPosition();
if (arena.IsAvailablePosition(newPosition))
    arena.PlaceRobot(newPosition);
else
    Console.WriteLine("Requested position is not available or out of bounds.");
Console.WriteLine(newPosition);

var robot2 = new Robot(arena, new Position(3, 3, 'E'));//second Robot
robot2.ProcessCommands("MMRMMRMRRM");
var newPosition2 = robot2.GetPosition();
if (arena.IsAvailablePosition(newPosition2))
    arena.PlaceRobot(newPosition2);
else
    Console.WriteLine("Requested position is not available or out of bounds.");
Console.WriteLine(newPosition2);

