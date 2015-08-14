using FMScoutFramework.Core;
using FMScoutFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTests
{
    public static class TestHelper
    {
        public static FMCore GetLoadedCore()
        {
            var autoResetEvent = new AutoResetEvent(false);

            var core = new FMCore(DatabaseModeEnum.Realtime);

            core.GameLoaded += () =>
            {
                autoResetEvent.Set();
            };

            core.LoadData();

            autoResetEvent.WaitOne();

            return core;
        }
    }
}
