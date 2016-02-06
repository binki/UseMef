class SomePlugin : IPlugin
{
    public string Name { get { return GetType().Name; } }
}
