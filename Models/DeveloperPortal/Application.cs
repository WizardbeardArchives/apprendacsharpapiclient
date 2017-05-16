using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.DeveloperPortal
{
    public class Application : ResourceBase
    {
        public Application(string href)
            : base(href)
        {
        }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        public IO.Swagger.Model.Version CurrentVersion { get; set; }

        public IO.Swagger.Model.Version TransitioningVersion { get; set; }

        public long UiAllocatedCpuMhz { get; set; }

        public long DbAllocatedCpuMhz { get; set; }

        public long SvcAllocatedCpuMhz { get; set; }

        public long WarAllocatedCpuMhz { get; set; }

        public long LinuxServiceAllocatedCpuMhz { get; set; }

        public long UiAllocatedMemoryMb { get; set; }

        public long DbAllocatedMemoryMb { get; set; }

        public long SvcAllocatedMemoryMb { get; set; }

        public long WarAllocatedMemoryMb { get; set; }

        public long LinuxServiceAllocatedMemoryMb { get; set; }

        public long AllocatedStorageMb { get; set; }
    }
}
