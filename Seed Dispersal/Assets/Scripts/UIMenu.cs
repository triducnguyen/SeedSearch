using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch
{
    public class UIMenu : MonoBehaviour
    {
        // Start is called before the first frame update
        public List<GameObject> menus;
        void Start()
        {

        }

        public void ChangeMenu(GameObject menu)
        {
            foreach (GameObject obj in menus)
                obj.SetActive(false);
            menu.SetActive(true);
        }
    }
}
