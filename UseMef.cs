using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

[InheritedExport(typeof(IPlugin))]
public interface IPlugin
{
    string Name { get; }
}

[Export(typeof(UseMef))]
public class UseMef
{
    [ImportMany]
    public IEnumerable<IPlugin> Plugins { get; set; }

    public int Run(string[] args)
    {
        foreach (var plugin in Plugins)
	    Console.WriteLine("Plugin " + plugin.Name);
        return 0;
    }

    public static int Main(string[] args)
    {
        using (var catalog = new ApplicationCatalog())
	{
	    using (var container = new CompositionContainer(catalog))
	    {
	        return container.GetExportedValue<UseMef>().Run(args);
	    }
	}
    }
}
