using matrixSearch.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace matrixSearch.Features
{
    public class WordFinder
    {
        #region vars
        private const int maxTakenResult = 10;
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
            //All rows
            this._matrix.ToList().ForEach(row =>
            {
                this.CheckWord(row, wordstream);
            });

            //All columns
            for (int columnIndex = 0; columnIndex < this._columnCount; columnIndex++)
            {
                if (columnIndex < this._columnCount)
                {
                    var column = this.GetColumn(columnIndex).ToLower();
                    this.CheckWord(column, wordstream);
                    columnIndex++;
                }               
            }                        
            var result = from f in _found orderby f.Times descending select f.Word;
            return result.Take(maxTakenResult);
        }
        #endregion

        #region private        

        private string GetColumn(int columnIndex)
        {
            var column = string.Empty;
            for (var i = 0; i < _rowCount; i++)
            {
                column += this._matrix.ToList()[i][columnIndex];
            }
            return column;
        }

        private void CheckWord(string row, IEnumerable<string> wordstream)
        {
            wordstream.ToList().ForEach(word =>
            {
                if (row.ToLower().Contains(word.ToLower()))
                {
                    this.WordFound(word);
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
