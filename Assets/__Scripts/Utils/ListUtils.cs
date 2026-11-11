using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearningProgrammingAcademy.Utils {

    public static class ListUtils {

        public static Stack<T> CreateShuffledStack<T>(IList<T> values) where T : Object {
            // copy list
            var list = new List<T>(values);
            var stack = new Stack<T>();

            while (list.Count > 0) {

                // get next item at random index
                var randomIndex = Random.Range(0, list.Count);
                var randomItem = list[randomIndex];

                // remove item from list and push it to top of the stack
                list.RemoveAt(randomIndex);
                stack.Push(randomItem);
            }

            return stack;
        }
    }
}
