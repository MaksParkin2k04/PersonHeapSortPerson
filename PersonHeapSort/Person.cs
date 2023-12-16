using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHeapSort {
    public class Person {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public override string ToString() {
            return $"{LastName} {FirstName}";
        }
    }
}
