﻿using System;
using System.Diagnostics;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.Diagnostics.EventFlow.ServiceFabric;

namespace NodeDiagnosticsService
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            // The ServiceManifest.XML file defines one or more service type names.
            // Registering a service maps a service type name to a .NET type.
            // When Service Fabric creates an instance of this service type,
            // an instance of the class is created in this host process.
            using (var pipeline = ServiceFabricDiagnosticPipelineFactory.CreatePipeline("EventFlowDiagnosticPipeline"))
            {
                ServiceRuntime.RegisterServiceAsync("NodeDiagnosticsServiceType",
                    context => new NodeDiagnosticsService(context)).GetAwaiter().GetResult();

                // Prevents this host process from terminating so services keep running.
                Thread.Sleep(Timeout.Infinite);
            }
        }
    }
}
