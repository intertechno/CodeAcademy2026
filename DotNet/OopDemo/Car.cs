class Car
{
    // Properties
    public string Make { get; set; } = "";
    public string Model { get; set; } = "";
    public int CurrentSpeed { get; set; }
    public bool EngineRunning { get; set; }

    // Methods
    public void StartEngine()
    {
        EngineRunning = true;
        Console.WriteLine("Engine started.");
    }

    public void StopEngine()
    {
        EngineRunning = false;
        Console.WriteLine("Engine stopped.");
    }

    public void Accelerate(int speedIncrease)
    {
        if (!EngineRunning)
        {
            // Console.WriteLine("Cannot accelerate. The engine is not running.");
            throw new InvalidOperationException("Cannot accelerate. " +
                "The engine is not running. Call StartEngine() before accelerating.");
        }

        CurrentSpeed += speedIncrease;
        Console.WriteLine($"Accelerating. Current speed: {CurrentSpeed} km/h");
    }

    public void Decelerate(int speedIncrease)
    {
        CurrentSpeed -= speedIncrease;

        if (CurrentSpeed < 0)
        {
            CurrentSpeed = 0;
        }

        Console.WriteLine($"Decelerating. Current speed: {CurrentSpeed} km/h");
    }
}
