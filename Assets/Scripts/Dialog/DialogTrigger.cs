using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Ink.Runtime;
namespace Dialog{
public class DialogTrigger : MonoBehaviour
    {
        [Header("Ink JSON")]
        [SerializeField] TextAsset inkJSON;
        private void Update() {
            if(InputManager.getInstance().GetNextPresseed()){
            
                DialogManager.GetInstance().EnterDiaglogMode(inkJSON);
            }
    
        }
    }
}

