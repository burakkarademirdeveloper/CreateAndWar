using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class MaterialController : MonoBehaviour
    {
        public GameObject Character;
        public List<Material> MaterialList = new List<Material>();
        
        private int _currentCharacterMaterialIndex;


        public static MaterialController Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void NextMaterialButton()
        {
            var currentMaterialIndex = GetCurrentCharacterMaterial();
            
            ChangeCharacterMaterial(currentMaterialIndex, 1);
        }

        public void PreviousMaterialButton()
        {
            var currentMaterialIndex = GetCurrentCharacterMaterial();
            
            ChangeCharacterMaterial(currentMaterialIndex, -1);
        }
        
        private int GetCurrentCharacterMaterial()
        {
            _currentCharacterMaterialIndex = PlayerPrefs.GetInt(Character.gameObject.name + "MaterialIndex");
            return _currentCharacterMaterialIndex;
        }

        private void ChangeCharacterMaterial(int currentMaterialIndex, int value)
        {
            if (value == 1)
            {
                if (currentMaterialIndex == MaterialList.Count - 1)
                    currentMaterialIndex = 0;
                else
                    currentMaterialIndex += value;
            }
            else
            {
                if (currentMaterialIndex == 0)
                    currentMaterialIndex = MaterialList.Count - 1;
                else
                    currentMaterialIndex += value;
            }
            
            var material = MaterialList[currentMaterialIndex];
            var characterMaterialController = Character.GetComponent<CharacterMaterialController>();
                
            characterMaterialController.ChangeMaterial(material);
            characterMaterialController.SaveMaterial(currentMaterialIndex);
        }
    }
}
