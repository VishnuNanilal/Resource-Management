using UnityEngine;

namespace ResourceSimulation.Core
{
    public class ColorManager : Singleton<ColorManager>, Saveable
    {
        private Color currentColor;
        private ColorPicker colorPicker;

        protected override void Awake() {
            base.Awake();
            CurrentColorLoad();
        }

        private void OnEnable() {
            GameManager.SaveEvent += Save;
            GameManager.LoadEvent += Load;
        }

        public Color GetActiveColor()
        {
            return currentColor;    
        }
        
        public void SetNewColor(Color color)
        {
            currentColor = color;
            CurrentColorSave();
        }

        public void Save()
        {
            PlayerPrefs.SetFloat("PreSelectColor_R", currentColor.r);
            PlayerPrefs.SetFloat("PreSelectColor_G", currentColor.g);
            PlayerPrefs.SetFloat("PreSelectColor_B", currentColor.b);
            PlayerPrefs.SetFloat("Color_R", currentColor.r);
            PlayerPrefs.SetFloat("Color_G", currentColor.g);
            PlayerPrefs.SetFloat("Color_B", currentColor.b);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            currentColor.r = PlayerPrefs.GetFloat("Color_R");
            currentColor.g = PlayerPrefs.GetFloat("Color_G");
            currentColor.b = PlayerPrefs.GetFloat("Color_B");
            PlayerPrefs.SetFloat("PreSelectColor_R", currentColor.r);
            PlayerPrefs.SetFloat("PreSelectColor_G", currentColor.g);
            PlayerPrefs.SetFloat("PreSelectColor_B", currentColor.b);
        }

        private void CurrentColorSave() //to preselect last selected color while the game loads
        {
            PlayerPrefs.SetFloat("PreSelectColor_R", currentColor.r);
            PlayerPrefs.SetFloat("PreSelectColor_G", currentColor.g);
            PlayerPrefs.SetFloat("PreSelectColor_B", currentColor.b);
            PlayerPrefs.Save();
        }

        private void CurrentColorLoad() //to preselect last selected color while the game loads
        {
            currentColor.r = PlayerPrefs.GetFloat("PreSelectColor_R");
            currentColor.g = PlayerPrefs.GetFloat("PreSelectColor_G");
            currentColor.b = PlayerPrefs.GetFloat("PreSelectColor_B");

            if(currentColor == null)
                currentColor = Color.red;
        }
    }
}

