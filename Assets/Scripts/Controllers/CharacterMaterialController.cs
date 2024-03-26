using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class CharacterMaterialController : MonoBehaviour
    {
        private Renderer _renderer;

        private void Start()
        {
            _renderer = transform.GetChild(0).GetComponent<Renderer>();
            
            var materialList = MaterialController.Instance.MaterialList;
            GetMaterial(materialList);
        }

        public void SaveMaterial(int materialIndex)
        {
            PlayerPrefs.SetInt(gameObject.name + "MaterialIndex", materialIndex);
        }

        public void ChangeMaterial(Material material)
        {
            _renderer.material = material;
        }

        private void GetMaterial(List<Material> materialList)
        {
            var materialIndex = PlayerPrefs.GetInt(gameObject.name + "MaterialIndex");
            
            ChangeMaterial(materialList[materialIndex]);
        }
    }
}
