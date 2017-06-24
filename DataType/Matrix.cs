using System;
using System.Collections.Generic;

namespace INFDTA01_1.DataType {

    /// <summary>
    /// Matrix - based on https://github.com/zenogantner/MyMediaLite/blob/master/src/MyMediaLite/DataType/SparseMatrix.cs
    /// Essentially it's a multidimensional list, but with easy access.
    /// </summary>
    public class Matrix<T> where T : new() {

        protected internal List<List<T>> value_list = new List<List<T>>();
        protected internal List<List<int>> index_list = new List<List<int>>();

        public int NumberOfRows { get { return index_list.Count; } }
        public int NumberOfColumns { get; private set; }

        /// <summary>Get a row of the matrix</summary>
        /// <param name="x">the row ID</param>
        public List<int> this[int x] {
            get {
                return index_list[x];
            }
        }

        /// <summary>Create a sparse matrix with a given number of rows</summary>
        /// <param name="num_rows">the number of rows</param>
        /// <param name="num_cols">the number of columns</param>
        public Matrix(int num_rows, int num_cols) {
            for (int i = 0; i < num_rows; i++) {
                index_list.Add(new List<int>());
                value_list.Add(new List<T>());
            }

            NumberOfColumns = num_cols;
        }

        /// <summary>Access the elements of the sparse matrix</summary>
        /// <param name="x">the row ID</param>
        /// <param name="y">the column ID</param>
        public virtual T this[int x, int y] {
            get {
                if (x < index_list.Count) {
                    int index = index_list[x].BinarySearch(y);
                    if (index >= 0)
                        return value_list[x][index];
                }
                return new T();
            }
            set {
                if (x >= index_list.Count) {
                    for (int i = index_list.Count; i <= x; i++) {
                        index_list.Add(new List<int>());
                        value_list.Add(new List<T>());
                    }
                }

                int index = index_list[x].BinarySearch(y);
                if (index >= 0) {
                    value_list[x][index] = value;
                } else {
                    int new_index = ~index;
                    index_list[x].Insert(new_index, y);
                    value_list[x].Insert(new_index, value);
                }
            }
        }
    }
}