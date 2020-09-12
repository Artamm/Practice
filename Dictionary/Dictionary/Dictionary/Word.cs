using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Word
    {
        public string id { get; set; }
        private string russian { get; set; }
        private string lithuanian { get; set; }
        private string english { get; set; }



        public string id1
        {
            get => id;
            set => id = value;
        }

        public string russian1
        {
            get => russian;
            set => russian = value;
        }

        public string english1
        {
            get => english;
            set => english = value;
        }

        public string lithuanian1
        {
            get => lithuanian;
            set => lithuanian = value;
        }

        public Word(string russian, string english, string lithuanian )
        {

            this.russian = russian.ToLower();
            this.lithuanian = lithuanian.ToLower();
            this.english = english.ToLower();
        }
        public Word(string text)
        {
            ;
        }

        public Word(string id, string russian, string lithuanian, string english)
        {
            this.id = id;
            this.russian = russian;
            this.lithuanian = lithuanian;
            this.english = english;
        }

        public Word()
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
