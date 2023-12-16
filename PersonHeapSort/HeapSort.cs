using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHeapSort {
    public class HeapSort {

        /// <summary>
        /// Сортирует элементы последовательности в порядке возрастания.
        /// </summary>
        /// <param name="array">массив</param>
        public void OrderBy(Person[] array) {
            Sort(array);
        }

        /// <summary>
        /// Сортирует элементы последовательности в порядке убывания.
        /// </summary>
        /// <param name="array">массив</param>
        public void OrderByDescending(Person[] array) {
            Sort(array);
            Array.Reverse(array);
        }

        private void Sort(Person[] array) {
            int length = array.Length;

            // Build heap (rearrange array)
            // Построить кучу (переставить массив)
            for (int i = length / 2 - 1; i >= 0; i--) {
                Heapify(array, length, i);
            }


            // One by one extract an element from heap
            // По одному извлекать элементы из кучи
            for (int i = length - 1; i > 0; i--) {
                // Move current root to end
                // Переместить текущий корень в конец
                Person temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                // call max heapify on the reduced heap
                // вызвать max heapify в уменьшенной куче
                Heapify(array, i, 0);
            }
        }

        // To heapify a subtree rooted with node i which is an index in arr[]. length is size of heap
        // Чтобы создать кучу поддерева, корнем которого является узел i, который является индексом в array[]. length — размер кучи
        private void Heapify(Person[] array, int length, int i) {
            int largest = i; // Initialize largest as root // Инициализировать самый большой как root
            int left = 2 * i + 1; // left = 2 * i + 1
            int right = 2 * i + 2; // right = 2 * i + 2

            // If left child is larger than root
            // Если левый дочерний элемент больше корня
            if (left < length && IfMore(array[left], array[largest])) {
                largest = left;
            }

            // If right child is larger than largest so far
            // Если правый ребенок больше, чем самый крупный на данный момент
            if (right < length && IfMore(array[right], array[largest])) {
                largest = right;
            }


            // If largest is not root
            // Если самый большой не является корнем
            if (largest != i) {
                Person swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                // Recursively heapify the affected sub-tree
                // Рекурсивно собрать в кучу затронутое поддерево
                Heapify(array, length, largest);
            }
        }

        private bool IfMore(Person a, Person b) {
            int result = string.Compare(a.LastName, b.LastName, StringComparison.InvariantCulture);

            if (result != 0) {
                return result > 0;
            } else {
                return string.Compare(a.FirstName, b.FirstName, StringComparison.InvariantCulture) > 0;
            }
        }
    }
}
