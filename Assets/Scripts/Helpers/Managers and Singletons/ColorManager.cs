using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ResourceSimulation.Core
{
    public class ColorManager : Singleton<ColorManager>, Saveable
    {
        private Color activeColor;
        private ColorPicker colorPicker;

        protected override void Awake() {
            base.Awake();
        }

        private void OnEnable() {
            GameManager.SaveEvent += Save;
            GameManager.LoadEvent += Load;
        }

        public Color GetActiveColor()
        {
            return activeColor;    
        }
        
        public void SetNewColor(Color color)
        {
            activeColor = color;
        }

        public void Save()
        {
            PlayerPrefs.SetFloat("Color_R", activeColor.r);
            PlayerPrefs.SetFloat("Color_G", activeColor.g);
            PlayerPrefs.SetFloat("Color_B", activeColor.b);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            activeColor.r = PlayerPrefs.GetFloat("Color_R");
            activeColor.g = PlayerPrefs.GetFloat("Color_G");
            activeColor.b = PlayerPrefs.GetFloat("Color_B");
        }
    }
}

