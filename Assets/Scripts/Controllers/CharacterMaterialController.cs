using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class CharacterMaterialController : MonoBehaviour
    {
        public GameObject Character;
        [SerializeField] private List<Material> _materialList = new List<Material>();
        
        public void NextMaterialButton()
        {
            var material = Character.transform.GetChild(0).GetComponent<Renderer>().material;
            Debug.Log(material);
        }

        public void PreviousMaterialButton()
        {
            
        }
    }
}
