using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetworkAPIViewer.ViewModels.Commands
{
    public class AsyncRelayCommand : AsyncCommandBase
    {
        private readonly Func<Task> _execute;

        public AsyncRelayCommand(Func<Task> execute, Action<Exception> onException) : base(onException)
        {
            _execute = execute;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _execute();
        }
    }
}
