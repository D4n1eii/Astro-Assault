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
        private Color lostLifeColor = new Color(1, 1, 1, .5f); 

        
        private List<LifeIcon> icons = new List<LifeIcon>();

        private int startingLives;


        private void Start()
        {
            var player = Object.FindAnyObjectByType<Player>();
            if (player)
            {
                startingLives = player.Lives;
                CreateIcons();
            }
        }


        private void OnEnable()
        {
            Player.LostLifeEvent += OnPlayerLifeLost;
        }


        private void OnDisable()
        {
            Player.LostLifeEvent -= OnPlayerLifeLost;
        }

        private void CreateIcons()
        {
            for (int i = 0; i < startingLives; i++)
            {
                LifeIcon icon = Instantiate(lifeIconPrefab, transform);
                icons.Add(icon);
            }
            icons.Reverse();

        }


        private void OnPlayerLifeLost(int lives)
        {
            for (int i = 0; i<icons.Count; i++)
               if(i>= lives)
                {
                    icons[i].setImageColor(lostLifeColor);
                }

        }
    }
}