using System;
using System.Collections.Generic;
using System.Linq;
using Rewired;
using UnityEngine;
using Random = UnityEngine.Random;

public class VaultManager : MonoBehaviour
{
    public PuzzleManagerData ManagerData;
    public List<VaultPair> Buttons;
    public bool RandomizeList = true;
    [SerializeField]
    private int activeInt = 0;

	public Material newMaterial;
    private Renderer render;

    public GameEvent puzzleComplete;

    private void OnEnable()
    {

        activeInt = 0;
        if (RandomizeList)
            Buttons = Buttons.OrderBy(a => Random.Range(0, 2)).ToList();


        for (var i = 0; i < Buttons.Count; i++)
        {
            Buttons[i].Button.TriggerStay += TriggerStay;
            //Buttons[i].order = i;
        }

        ManagerData.Complete = false;
    }

    private void OnDisable()
    {
        foreach (var vaultPair in Buttons)
            vaultPair.Button.TriggerStay -= TriggerStay;
    }

    private void TriggerStay(VaultButton btn, Collider obj)
    {
        if (obj.tag != "Player")
            return;

        //If not player 1 (aka id: 0)
        if (!ReInput.players.GetPlayer(0).GetButtonDown("A"))
            return;

        
        for (var i = 0; i < Buttons.Count; i++)
        {
            
            if (Buttons[i].Button == btn)
            {
                
                if (!Buttons[i].Activated)
                {
                    Buttons[i].Activated = true;
                    
                    render = btn.GetComponent<Renderer>();
                    Material[] mats = render.materials;
                    mats[1] = newMaterial;
                    render.materials = mats;

                    Buttons[i].Light.intensity = 5;

                    Material[] wireMats = Buttons[i].wire.materials;
                    mats[0] = Buttons[i].ActiveWire;
                    Buttons[i].wire.materials = mats;   //make a func

                    ++activeInt;
                    
                    if (activeInt == 4)
                    {
                        OnPuzzleComplete();
                    }
                }
            }
        }
    }

    private void OnPuzzleComplete()
    {
        
        ManagerData.Complete = true;
        puzzleComplete.Invoke();

    }

    [Serializable]
    public class VaultPair
    {
        public int order;
        public bool Activated;
        public VaultButton Button;
		public Material ActiveWire;
        public Light Light;
        public Renderer wire;

    }
}
