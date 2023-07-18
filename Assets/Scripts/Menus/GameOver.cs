using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public void Restart()
    {
        // Aqui dentro coloque todos os c�digos que fazem o jogo recome�ar.
        Destroy(gameObject);
    }

    public void Quit()
    {
        // Esse "Application.Quit()" s� funciona FORA do editor do Unity.
        UnityEngine.Application.Quit();
    }

}
