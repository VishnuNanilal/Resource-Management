using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ResourceSimulation.Core
{
    public class ColorManager : MonoBehaviour, Saveable
    {
        private Color activeColor;
        private ColorPicker colorPicker;

        private void Awake() {
            colorPicker = FindObjectOfType<ColorPicker>();
            colorPicker.onColorChanged += SetNewColor;
            SceneHandler.Instance.SceneCompleteProcesses += ApplyColors;
            GameManager.Instance.Save += Save;
            GameManager.Instance.Load += Load;
        }

        private void SetNewColor(Color color)
        {
            activeColor = color;
        }

        private void ApplyColors()
        {
            PrefabColorHandler[] colorHandlers = FindObjectsOfType<PrefabColorHandler>();
            foreach(PrefabColorHandler colorHandler in colorHandlers)
            {
                colorHandler.SetColor(activeColor);
            }
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
            ApplyColors();
        }
    }
}

