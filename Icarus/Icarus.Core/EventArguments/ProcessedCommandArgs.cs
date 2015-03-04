using System;
using Icarus.Core.Enums;

namespace Icarus.Core.EventArguments
{
    public class ProcessedCommandArgs : EventArgs
    {
        public string EventName { get; set; }
        public CommandType CommandType { get; set; }
    }
}