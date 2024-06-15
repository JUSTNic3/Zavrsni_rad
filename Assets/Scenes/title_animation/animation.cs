using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class animation : MonoBehaviour
{
    [SerializeField] Animator title;
    [SerializeField] Animator message;

    void Start(){
        title.Play("fade_in", 0, 0.0f);
        message.Play("fade_in_message", 0, 0.0f);
        Invoke("back_to_title", 5);
    }
    void back_to_title(){
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
}
