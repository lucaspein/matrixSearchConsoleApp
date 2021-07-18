using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixSearch.Features
{
    public class Counter
    {
        public int Times { get; set; }
        public string Word { get; set; }
    }

    public class WordFinder
    {
        private IEnumerable<string> _matrix;

        private List<Counter> _found;

        public WordFinder(IEnumerable<string> matrix)
        {
            this._matrix = matrix;
            this._found = new List<Counter>();
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            this._matrix.ToList().ForEach(row => {
                this.CheckRow(row, wordstream);
            });
            
            var res = from f in _found orderby f.Times descending select f.Word;
            return res;
        }

        private void CheckRow(string row, IEnumerable<string> wordstream)
        {
            wordstream.ToList().ForEach(word => { 
                if(row.Contains(word))
                {
                    WordFound(word);
                }
            });
        }

        private void WordFound(string word)
        {
            var alreadyAdded = _found.Where(w => w.Word.ToLower() == word.ToLower()).FirstOrDefault();
            if (alreadyAdded != null)
            {
                alreadyAdded.Times += 1;
            }
            else
            {                
                _found.Add(new Counter() { Word = word, Times = 1 });
            }
        }
    }
}
