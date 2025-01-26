using TMPro;
using UnityEngine;

namespace SecondGame
{
    public class SetTextMoves : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _textMoves;

        private void SettingTextMove()
        {
            _textMoves.text = PlayerPrefs.GetInt("Moves").ToString() + " moves";
        }

        private void OnEnable()
        {
            RebootActiveCardParent.NewActiveCardAssigned += SettingTextMove;
        }

        private void OnDisable()
        {
            RebootActiveCardParent.NewActiveCardAssigned += SettingTextMove;
        }
    }
}