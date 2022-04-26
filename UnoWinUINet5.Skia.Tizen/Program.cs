using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace UnoWinUINet5.Skia.Tizen
{
	class Program
{
	static void Main(string[] args)
	{
		var host = new TizenHost(() => new UnoWinUINet5.App(), args);
		host.Run();
	}
}
}
