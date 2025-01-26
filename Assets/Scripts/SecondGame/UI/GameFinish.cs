using TMPro;
using UnityEngine;

namespace SecondGame
{
    public class GameFinish : MonoBehaviour
    {
        [SerializeField]
        private GameObject _panelFinish;

        [SerializeField]
        private TMP_Text _textFinish;

        private GameDeck _gameDeck;

        private GameCard[] _objectPeacksOfTheTriangles;

        private bool isWin = false, isFinishing = false;

        public void Init(GameCard[] gameCards, GameDeck gameDeck)
        {
            _objectPeacksOfTheTriangles = gameCards;
            _gameDeck = gameDeck;
        }

        private void CheckFinishingGame()
        {
            isWin = CheckPicks();

            if ((_gameDeck._spriteCards != null && _gameDeck._spriteCards.Count == 0 && _gameDeck.SearchTrueElements()) || isWin)
                isFinishing = true;

            if (isFinishing)
            {
                _panelFinish.SetActive(true);

                if (isWin)
                {
                    _textFinish.text = "ѕоздравл€ю, ты выиграл! —ыграем ещЄ?";
                }
                else
                {
                    _textFinish.text = "”вы, ты проиграл. —ыграем ещЄ?";
                }
            }
        }

        private bool CheckPicks()
        {
            if (_objectPeacksOfTheTriangles != null)
            {
                for (int i = 0; i < _objectPeacksOfTheTriangles.Length; i++)
                {
                    if (_objectPeacksOfTheTriangles[i] != null && _objectPeacksOfTheTriangles[i].IsActive)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private void OnEnable()
        {
            RebootActiveCardParent.NewActiveCardAssigned += CheckFinishingGame;
        }

        private void OnDisable()
        {
            RebootActiveCardParent.NewActiveCardAssigned -= CheckFinishingGame;
        }
    }
}