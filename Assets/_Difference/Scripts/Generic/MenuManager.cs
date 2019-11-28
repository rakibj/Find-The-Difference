using UnityEngine;
using UnityEngine.UI;

namespace _Difference.Scripts.Generic
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Dropdown languageDropdown;
        void Start()
        {
            StaticData.LostTimes = 0;
            languageDropdown.onValueChanged.AddListener(ChangeLanguage);
        }

        private void ChangeLanguage(int lang)
        {
            var language = languageDropdown.options[lang].text;
            Lean.Localization.LeanLocalization.CurrentLanguage = language;
        }
        
        

    }
}
