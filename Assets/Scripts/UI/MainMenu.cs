using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UIElements;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        private Button _btnNewGame;
        private Button _btnRankingBoard;
        private Button _btnQuit;

        [SerializeField] private AssetReference newGameScene;

        private void OnEnable()
        {
            var uiDocument = GetComponent<UIDocument>();

            _btnNewGame = uiDocument.rootVisualElement.Q<Button>("btnNewGame");
            _btnNewGame.RegisterCallback<ClickEvent>(OnClickNewGame);

            _btnRankingBoard = uiDocument.rootVisualElement.Q<Button>("btnRankingBoard");
            _btnRankingBoard.RegisterCallback<ClickEvent>(OnClickRankingBoard);

            _btnQuit = uiDocument.rootVisualElement.Q<Button>("btnQuit");
            _btnQuit.RegisterCallback<ClickEvent>(OnClickQuit);
        }

        private void OnClickNewGame(ClickEvent evt)
        {
            newGameScene.LoadSceneAsync();
        }

        private static void OnClickRankingBoard(ClickEvent evt)
        {
            Debug.Log("User clicked Ranking Board");
        }

        private static void OnClickQuit(ClickEvent evt)
        {
            Application.Quit();
        }

        private void OnDisable()
        {
            _btnNewGame.UnregisterCallback<ClickEvent>(OnClickNewGame);
            _btnRankingBoard.UnregisterCallback<ClickEvent>(OnClickRankingBoard);
            _btnQuit.UnregisterCallback<ClickEvent>(OnClickQuit);
        }
    }
}