using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
public class SurvivorSwitchManager : MonoBehaviour
{   
    /*
        This script is responsible for switching among / between survivors.
    */
    [SerializeField] private List<GameObject> survivorList;

    void Update(){
        TrySwitchSurvivor();
    }

    private void TrySwitchSurvivor(){
        if(survivorList.Count <= 1){
            return;
        }
        
        int index = -99;
        
        // take an index
        for(int i = 0; i < 10; i ++){
            if(Input.GetKeyDown(KeyCode.Alpha0 + i)){
                index = i;
                break;
            }
        }
        if(index == -99){
            // no input return
            return;
        }
        // validate input
        if(NormalisedIndex(index) < 0 || NormalisedIndex(index) >= survivorList.Count){
            Debug.Log("index out of scope");
            return;
        }
        ActivateSurvivor(NormalisedIndex(index));
    }

    private void ActivateSurvivor(int idx){
        for(int i = 0; i < survivorList.Count; i ++){
            SurvivorBase survivorScript = survivorList[i].GetComponentInChildren<SurvivorBase>();
            if(idx == i){
                // set this to be controlled by the player
                survivorScript.parameter.isPlayedByPlayer = true;

                Debug.Log($"Currently controlling {survivorList[idx]}");
            }
            else{
                // set this to be controlled by AI
                survivorScript.parameter.isPlayedByPlayer = false;
            }
        }
    }

    private int NormalisedIndex(int idx){
        return idx - 1;
    }



}
