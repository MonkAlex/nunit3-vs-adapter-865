using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace nunit3_vs_adapter_865
{
  public class Program
  {
    public static void Main(string[] args)
    {
      using (var server = new NamedPipeServerStream(Guid.NewGuid().ToString("N"), PipeDirection.InOut,
        NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte, PipeOptions.None))
      {
        server.WaitForConnection();
      }
    }
  }

  [TestFixture]
  public class Test
  {
    [Test]
    public void Method()
    {
      Task.Run(() => Program.Main(new string[0]));
      Assert.Pass();
    }
  }
}
