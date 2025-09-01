using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
public class SurvivorManager : MonoBehaviour
{   
    /*
        This script is responsible for switching among / between survivors.
    */
    public static List<GameObject> survivorList = new List<GameObject>();

    void OnEnable()
    {
        EventManager.OnSurvivorDied += RemoveSurvivor;
    }

    void OnDisable()
    {
        EventManager.OnSurvivorDied -= RemoveSurvivor;
    }
    void Update(){
        // Debug.Log(survivorList.Count);
        
        TrySwitchSurvivor();
    }

    private void TrySwitchSurvivor(){
        if (survivorList == null)
        {
            Debug.Log("list is null");
            return;
        }
        if (survivorList.Count < 1)
        {
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

                // Debug.Log($"Currently controlling {survivorList[idx]}");
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

    private void RemoveSurvivor(GameObject survivor) {
        for (int i = 0; i < survivorList.Count; i ++) {
            Transform childTransform = survivorList[i].transform.GetChild(0);
            GameObject curSurvivor = childTransform.gameObject;
            if (curSurvivor == survivor)
            {
                // remove from the list
                Destroy(survivorList[i]);
                survivorList.RemoveAt(i);
                
                break;
            }
        }
    }

}
