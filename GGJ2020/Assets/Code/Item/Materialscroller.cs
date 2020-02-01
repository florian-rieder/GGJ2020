﻿using Code.EventSystem.Events;
using UnityEngine;

namespace Code.Item
{
    public class Materialscroller : MonoBehaviour
    {
        [SerializeField] private MaterialEvent currentMaterialEvent;
        [SerializeField] private RepairMaterialList materialList;
   
        private int _materialListIdx = 0;
           
        void Update()
        {
   
            if (Input.GetButtonDown("MaterialScrollUp"))
            {
                _materialListIdx = (_materialListIdx + 1) % materialList.GetListSize();
                currentMaterialEvent.Raise(materialList.GetRepairTool(_materialListIdx));
            }
            else if (Input.GetButtonDown("MaterialScrollDown"))
            {
                _materialListIdx = (_materialListIdx- 1);
                if (_materialListIdx < 0)
                {
                    _materialListIdx = materialList.GetListSize() - 1;
                }
                currentMaterialEvent.Raise(materialList.GetRepairTool(_materialListIdx));
            }
        }
    }
}
