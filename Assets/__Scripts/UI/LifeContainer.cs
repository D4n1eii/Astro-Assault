using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LearningProgrammingAcademy.AstroAssault.UI
{
    public class LifeContainer : MonoBehaviour
    {

        [SerializeField]
        private LifeIcon lifeIconPrefab;


        [SerializeField]
        private Color lostLifeColor = new Color(1, 1, 1, 0.5f); 

        private Player player;

        private int startingLives;


        private List<LifeIcon> icons = new List<LifeIcon>();



        private void Start()
        {
            player = Object.FindAnyObjectByType<Player>();
            if (player)
            {
                startingLives = player.Lives;
                CreateIcons();
            }
        }


        private void Update()
        {
            if(player && player.Lives < startingLives)
            {
                for (int i = 0; i < icons.Count; i++)
                {
                    if (i >= player.Lives)
                    {
                        Debug.Log("Lives: " + player.Lives);
                        icons[i].setImageColor(lostLifeColor);
                    }
                }
            }
        }

        private void CreateIcons()
        {
            for (int i = 0; i < startingLives; i++)
            {
                LifeIcon icon = Instantiate(lifeIconPrefab, transform);
                icons.Add(icon);
            }
        }
    }
}