using matrixSearch.Model;
using System.Collections.Generic;
using System.Linq;

namespace matrixSearch.Features
{
    public class WordFinder
    {
        #region vars

        private IEnumerable<string> _matrix;
        private List<Counter> _found;
        private int _rowCount = 0, _columnCount = 0;
        #endregion

        #region constructor
        public WordFinder(IEnumerable<string> matrix)
        {
            this._matrix = matrix;
            this._found = new List<Counter>();
            this._rowCount = matrix.Count();
            this._columnCount = matrix.First().Length;
        }
        #endregion

        #region public
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var i = 0;
            this._matrix.ToList().ForEach(row =>
            {
                this.CheckWord(row, wordstream);
                if (i < this._columnCount)
                {
                    var column = this.GetColumn(i).ToLower();
                    this.CheckWord(column, wordstream);
                    i++;
                }
            });
            
            return from f in _found orderby f.Times descending select f.Word;
        }
        #endregion

        #region private        

        private string GetColumn(int i)
        {
            var column = string.Empty;
            for (var j = 0; j < _rowCount; j++)
            {
                column += this._matrix.ToList()[j][i];
            }
            return column;
        }

        private void CheckWord(string row, IEnumerable<string> wordstream)
        {
            wordstream.ToList().ForEach(word =>
            {
                if (row.ToLower().Contains(word.ToLower()))
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
        #endregion
    }
}
