using ACSVisualization.Models;
using System.Windows.Documents;
using System.Collections.Generic;

namespace ACSVisualization.Events
{
    public class OnCompletedACSMessage
    {
        public OnCompletedACSMessage(List<List<Edge>> best_paths)
        {
            Result = best_paths;
        }

        public List<List<Edge>> Result { get; }
    }

}
