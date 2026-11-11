using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using LearningProgrammingAcademy.AstroAssault.Utils;

namespace LearningProgrammingAcademy.AstroAssault {

    public class Dock : MonoBehaviour {        

        // == fields ==
        [SerializeField]
        private float width = 0.8f;

        [SerializeField]
        private float height = 3f;

        [SerializeField]
        [Range(1, 15)]
        private int slotCount = 5;

        [SerializeField]
        private float slotSpacing = 0.6f;

        [SerializeField]
        private DockSlot slotPrefab;

        private DockSlot[] slots;
        private GameObject enemiesParent;

        private bool isInSlot = false;
        // == messages ==
        private void Start() {
            slots = new DockSlot[slotCount];

            enemiesParent = GameObject.Find(ParentNames.ENEMIES_PARENT_NAME);

            if (!enemiesParent) {
                Debug.Log($"{ParentNames.ENEMIES_PARENT_NAME} object not found creating new object");
                enemiesParent = new GameObject(ParentNames.ENEMIES_PARENT_NAME);
            }

            CreateSlots();
        }

        private void OnDrawGizmos() {
            Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
        }


        private void Update()
        {
            // Only run if it has actually reached the slot
            if (!isInSlot) return;

            RepositionEnemies();
        }


        // == public methods ==
        public void Release()
        {
            var firstSlot = slots.First();
            Debug.Log($"releasing enemy at slot= {firstSlot.name}");

            var enemyAtFirstSlot = firstSlot.GetComponentInChildren<Enemy>();
            enemyAtFirstSlot.transform.parent = enemiesParent.transform;

            var fallingBehavior = enemyAtFirstSlot.GetComponent<FallingBehavior>();
            fallingBehavior.enabled = true;

            RepositionEnemies();
        }

        public bool IsFull() {
            return NextFreeSlot() == null;
        }
             
        public DockSlot NextFreeSlot() {
            foreach (var slot in slots) {
                if (slot.IsEmpty()) {
                    return slot;
                }
            }

            return null;
        }

        public Vector3 GetEntryPoint() {
            int diff = slotCount / 2 + 1; // +1 since we want to be above the dock
            float positionY = transform.position.y + slotSpacing * diff;
            return new Vector3(transform.position.x, positionY);
        }

        // == private methods ==
        private void RepositionEnemies() {
            // starting from 1 since first slot is empty (released or dead enemy)
            for (int i = 1; i < slots.Length; i++) {
                var previousSlot = slots[i - 1];
                var currentSlot = slots[i];

                if (previousSlot.IsEmpty() && !currentSlot.IsEmpty()) {
                    var enemyAtCurrentSlot = currentSlot.GetComponentInChildren<WaypointFollower>();

                    // reparent to previous slot
                    enemyAtCurrentSlot.transform.parent = previousSlot.transform;
                    // add waypoint
                    enemyAtCurrentSlot.AddWaypoint(previousSlot.transform.position);
                }
            }
        }




        private void CreateSlots() {
            int halfCount = slotCount / 2;
            float startY = transform.position.y - slotSpacing * halfCount;

            // if there is even number of slots start lower by half of slot spacing            
            if (slotCount % 2 == 0) {
                startY += slotSpacing / 2f;
            }
            

            for (int i = 0; i < slotCount; i++) {
                var slot = Instantiate(slotPrefab, transform);
                float yPosition = startY + i * slotSpacing;

                slot.transform.position = new Vector3(transform.position.x, yPosition);
                slots[i] = slot;
            }
        }
    }
}