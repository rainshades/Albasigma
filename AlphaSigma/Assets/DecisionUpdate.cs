using Fungus;
using Albasigma.ARPG;

namespace Albasigma.FungusAddon
{
    [CommandInfo("Friendly", "Update Decision", "Makes a bool in the Decision Tracker true")]
    public class DecisionUpdate : Command
    {
        public int Decision_Number;
        public DecisionTracker Tracker; 

        public override void Execute()
        {
            base.Execute();
            Tracker.Decisions[Decision_Number] = true; 
            Continue(); 
        }
    }
}