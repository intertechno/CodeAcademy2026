Console.WriteLine("Hello, World!");

Car myCar = new();
Car anotherCar = new();


myCar.Make = "Toyota";
myCar.Model = "Camry";
// myCar.StartEngine();
myCar.Accelerate(30);
myCar.Decelerate(50);


Console.WriteLine($"Current speed: {myCar.CurrentSpeed} km/h");
