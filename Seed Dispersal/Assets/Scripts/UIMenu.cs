using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SeedSearch
{
    public class UIMenu : MonoBehaviour
    {
        public static UIMenu Instance;
        // Start is called before the first frame update
        public List<GameObject> menus;

        public void ChangeMenu(GameObject menu)
        {
            foreach (GameObject obj in menus)
                obj.SetActive(false);

            menu.SetActive(true);
        }

        public void GoToScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
        public GameObject menuobj, adventureMenu;
        public void openadventuretab(){
            menuobj.SetActive(false);
            adventureMenu.SetActive(true);
        }

        public void ReturnToMenu()
        {
            menuobj.SetActive(false);
            adventureMenu.SetActive(true);
            SoundManager.Instance.GetComponent<AudioSource>().clip = null;
        }

        public void QuitApp()
        {
            Application.Quit();
        }
    }
}
