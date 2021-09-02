using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Albasigma.UI;
using Albasigma.ARPG;
using Albasigma.Cards;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Albasigma
{
    /// <summary>
    /// Saves GameData to file
    /// Data is stored here AND in a scriptable object. 
    /// </summary>
    public class GameData
    {
        public float playerhealth;
        public float playerdrive;
        public int PlayerScene;

        public SkillList SkillsList;
        public DecisionTracker Tracker;
        public Bag Bag;
        public Deck Deck;
        public PlayerStats Stats; 

        public Vector3 PlayerSaveLocation; 

        public GameData(float h, float d, int s, Vector3 l)
        {
            playerhealth = h; playerdrive = d; PlayerScene = s; PlayerSaveLocation = l;
        }

        public void SetSOData(SkillList skillList, DecisionTracker decisionTracker, Bag bag, Deck deck, PlayerStats playerStats)
        {
            SkillsList = skillList; Tracker = decisionTracker; Bag = bag; Deck = deck; Stats = playerStats; 
        }
    }

    [RequireComponent(typeof(PlayerScriptableObjectsController))]
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; set;  }

        [SerializeField]
        PlayerPauseUI complexPauseUI;

        [SerializeField]
        GameObject simplePauseUI; 

        public ArenaManager CurrentArena; 

        public bool Paused = false;

        public SkillList SkillsList;
        public DecisionTracker Tracker;
        public Bag Bag;
        public Deck Deck;
        public PlayerStats Stats;

        public string filepath = "Autosave";

        PlayerControls pc;
        private void Awake()
        {
            pc = new PlayerControls();
            Instance = this;
            pc.Player.Pause.performed += Pause_performed;
        }

        private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Paused = !Paused;

            if (!Paused)
            {
                Time.timeScale = 1; 
            }
            else
            {
                Time.timeScale = 0; 
            }

            if (CurrentArena.AllEnemiesDefeated && Stats.PlayerLevel.CurrentLevel > 7)
            {

                complexPauseUI.gameObject.SetActive(Paused);
            }
            else
            {
                simplePauseUI.gameObject.SetActive(Paused); 
            }
        }
        
        public void SaveGame()
        {
            PlayerMovement movement = FindObjectOfType<PlayerMovement>();
            PlayerCombat combat = movement.GetComponent<PlayerCombat>();
            Vector3 PlayerLocation = movement.transform.position;
            PlayerScriptableObjectsController PSOC = GetComponent<PlayerScriptableObjectsController>(); 

            int current_scene = SceneManager.GetActiveScene().buildIndex;

            GameData GD = new GameData(combat.Currenthealth, combat.CurrentDrive, current_scene, PlayerLocation);
            GD.SetSOData(SkillsList, Tracker, Bag, Deck, Stats);

            string autosave = Application.persistentDataPath + "/" + filepath + ".json";
            FileStream file = File.Create(autosave);
            string json = JsonUtility.ToJson(GD);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, json);
            file.Close();

        } // Saves player data to file. 

        public void LoadGame()
        {
            SceneManager.sceneLoaded += OnGameDataLoaded; 
        }

        #region For Level Manager

        [SerializeField]
        GameObject BoxTransitionAnimation;

        public void AreaTransition(float time)//TEMP NEED LEVEL MANAGER
        {
            StartCoroutine(AreaBlackout(time)); 
        }//Creates a transition from box to box

        IEnumerator AreaBlackout(float time)
        {
            BoxTransitionAnimation.SetActive(true);
            yield return new WaitForSecondsRealtime(time);
            BoxTransitionAnimation.SetActive(false); 
        }

        #endregion

        public GameData LoadGameData()
        {
            string autosave = Application.persistentDataPath + "/" + filepath + ".json";
            FileStream file = File.OpenRead(autosave);
            BinaryFormatter bf = new BinaryFormatter();
            string json = (string)bf.Deserialize(file);

            GameData GD = JsonUtility.FromJson<GameData>(json);
            SkillsList = GD.SkillsList;
            Tracker = GD.Tracker;
            Bag = GD.Bag;
            Deck = GD.Deck;
            Stats = GD.Stats;
            file.Close(); 

            //Will need to save deckdata to file as the player data is saved to file

            return GD; 
        } // Loads player data 

        public void SetCombatStats(PlayerCombat combat, GameData GD)
        {
            combat.CurrentDrive = GD.playerdrive;
            combat.Currenthealth = GD.playerhealth;
            combat.transform.position = GD.PlayerSaveLocation;
        } //Set's the player's combat stats to the ones on file. 

        private void OnGameDataLoaded(Scene scene, LoadSceneMode mode)
        {
            PlayerCombat combat = FindObjectOfType<PlayerCombat>();
            SetCombatStats(combat, LoadGameData()); 
        }//What happens when the game data is loaded

        public void GameOver()
        {
            SceneManager.LoadScene(0);
        }//On death loads main menu
        //Will need to be edited to be a gameover screen

        private void OnEnable()
        {
            pc.Enable(); 
        }

        private void OnDisable()
        {
            pc.Disable(); 
        }
    }
}