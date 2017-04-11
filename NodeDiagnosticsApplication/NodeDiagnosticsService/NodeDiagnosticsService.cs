using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace NodeDiagnosticsService
{
    using System.Fabric;
    using Microsoft.ServiceFabric.Services.Runtime;

    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class NodeDiagnosticsService : StatelessService
    {
        public NodeDiagnosticsService(StatelessServiceContext context)
            : base(context)
        { }
    }
}
