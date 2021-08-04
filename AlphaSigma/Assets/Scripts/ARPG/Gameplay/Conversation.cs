using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; 

/// <summary>
/// Execute Fungus block for a specific NPC
/// </summary>
namespace Albasigma.ARPG
{
    public class Conversation : MonoBehaviour
    {
        Flowchart flow;

        private void Awake()
        {
            flow = FindObjectOfType<Flowchart>();//Selects Fungus Block
            //If there are multiple Flowcharts this will need to be changed
        }

        public void PlayConversation(string blockname)
        {
            if (!flow.HasExecutingBlocks())
            {
                flow.ExecuteBlock(blockname);
            }//Executes Fungus Block 
        }
    }
}