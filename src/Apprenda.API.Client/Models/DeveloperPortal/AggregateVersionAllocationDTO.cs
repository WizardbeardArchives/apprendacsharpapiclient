using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.DeveloperPortal
{
    public class AggregateVersionAllocationDTO
    {
        public string VersionAlias { get; set; }

        public string AppAlias { get; set; }


        public Guid AppDeveloperId { get; set; }


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


        public double UiAllocatedCpuFractionOfCore { get; set; }


        public double DbAllocatedCpuFractionOfCore { get; set; }


        public double SvcAllocatedCpuFractionOfCore { get; set; }


        public double WarAllocatedCpuFractionOfCore { get; set; }


        public double LinuxServiceAllocatedCpuFractionOfCore { get; set; }


        public double PodAllocatedCpuFractionOfCore { get; set; }


        public long PodAllocatedMemoryMb { get; set; }


        public int UiInstances { get; set; }


        public int DbInstances { get; set; }


        public int SvcInstances { get; set; }


        public int LinuxInstances { get; set; }


        public int WarInstances { get; set; }


        public int PodInstances { get; set; }
    }
}
