using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class MainMenuState : GameState
    {
        public GameState gamePlayState;

        public void PlayGame()
        {
            Exit();
            gamePlayState.Enter();
        }
    }
}
