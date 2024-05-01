IGreeter greeter = new NiceToMeetYouGreeterDecorator(new TitledGreeterDecorator(new FormalGreeter()));
string greet = greeter.Greet("Samuel L. Jackson");
Console.WriteLine(greet);