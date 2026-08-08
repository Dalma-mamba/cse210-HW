Inheritance is a programming principle that allows one class to reuse and build on the features of another class. In simple terms, a child class can inherit the properties and methods of a parent class, which helps us avoid rewriting the same code over and over. This is important because it makes programs easier to organize, easier to maintain, and easier to expand. A major benefit of inheritance is that it reduces duplicate code and creates a clear structure. When several classes share common behavior, that shared behavior can be placed in one base class and reused by all of the related classes.

In my mindfulness program, inheritance is used to connect the different activity types. The base class Activity contains the shared logic for starting the activity, asking for the duration, showing countdowns, and ending the activity. Then each specific activity class, such as BreathingActivity, ReflectionActivity, and ListingActivity, inherits from Activity and adds its own unique behavior. This means I did not have to repeat the same start and end logic in every activity class. Instead, I could focus on what makes each activity different.

Here is a code example from the program:

```csharp
public abstract class Activity
{
    public void Run()
    {
        DisplayStartingMessage();
        _duration = GetDuration();
        PrepareToBegin();
        PerformActivity();
        DisplayEndingMessage();
    }
}

public class BreathingActivity : Activity
{
    protected override void PerformActivity()
    {
        // Breathing-specific behavior
    }
}
```

This example shows inheritance because BreathingActivity inherits from Activity. The child class gets the shared Run method from the parent class, while also defining its own special behavior. In real-world terms, inheritance helps us model relationships between things in a natural way. For example, all mindfulness activities share the same general structure, but each one has its own purpose. Inheritance lets the program reflect that relationship clearly and efficiently.

Screenshot from the start of the team meeting:
Insert your team-meeting screenshot here.
