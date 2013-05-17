// to run this sample, execute:
// scriptcs -install
// scriptcs start2.csx

Require<NancyPack>().Host(new CustomBootstrapper(), new Uri("http://localhost:8888"));

public class IndexModule : NancyModule
{
    public IndexModule()
    {
        Get["/"] = _ =>	View["index"]; // located in views folder
    }
}

public class HelloModule : NancyModule
{
    public HelloModule(IGreetings greetings)
    {
        Get["/hello"] = _ => greetings.Hello;
    }
}

public interface IGreetings
{
    string Hello { get; }
}

public class Greetings : IGreetings
{
    public string Hello
    {
        get { return "Hello World!"; }
    }
}

public class CustomBootstrapper : DefaultNancyPackBootstrapper
{
    protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, IPipelines pipelines)
    {
         container.Register(typeof(IGreetings), typeof(Greetings));
    }
}