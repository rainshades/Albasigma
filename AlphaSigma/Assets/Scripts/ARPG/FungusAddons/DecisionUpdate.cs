using Fungus;
using Albasigma.ARPG;

/// <summary>
/// Decision Tracker Accessor for Fungus. 
/// </summary>
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
            Tracker.Decisions[Decision_Number].Done = true;
            Continue();
        }
    }    
}