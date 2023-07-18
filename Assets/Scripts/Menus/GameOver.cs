using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public void Restart()
    {
        // Aqui dentro coloque todos os códigos que fazem o jogo recomeçar.
        Destroy(gameObject);
    }

    public void Quit()
    {
        // Esse "Application.Quit()" só funciona FORA do editor do Unity.
        UnityEngine.Application.Quit();
    }

}
