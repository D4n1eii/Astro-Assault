using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearningProgrammingAcademy.AstroAssault {

    public class DockSlot : MonoBehaviour {

        // == messages ==
        private void OnDrawGizmos() {
            Gizmos.DrawWireSphere(transform.position, 0.25f);
        }

        // == public methods ==
        public bool IsEmpty() {
            return transform.childCount == 0;
        }
    }
}
