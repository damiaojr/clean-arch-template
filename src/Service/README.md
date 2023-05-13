# SERVICE

A .NET Service project is a type of software project that uses the .NET framework to create long-running background processes. It can be used to implement server-side functionality that runs continuously in the background and requires minimal user interaction.

Once the service logic has been implemented, you can install the .NET Service using the installation wizard or command-line tools provided by the .NET framework. The service can then be started or stopped using the Services console in Windows.

.NET Services are typically designed to run continuously in the background, and may be configured to start automatically when the system boots up. They have access to the full range of .NET APIs, enabling them to interact with the operating system and other services running on the same machine.

```c#
using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;

namespace MyService
{
    public partial class MyService : ServiceBase
    {
        private Timer _timer;

        public MyService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _timer = new Timer(WriteToEventLog, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        protected override void OnStop()
        {
            _timer.Dispose();
        }

        private void WriteToEventLog(object state)
        {
            EventLog.WriteEntry("MyService", "Service is running", EventLogEntryType.Information);
        }
    }
}
```

*The communication with the application layer must be done using [Mediatr](https://github.com/jbogard/MediatR) and it should only expose DTO classes.*