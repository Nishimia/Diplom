using System;
using System.Collections.Generic;

namespace Matrix
{
	public class Matrix<T> where T : IComparable,
		IComparable<T>,
		IConvertible,
		IEquatable<T>,
		IFormattable
	{
		private List<List<T>> Body { set; get; }
		public int ColumnsAmmount { private set; get; }
		public int RowsAmmount { private set; get; }

		public Matrix(int columnsAmmount, int rowsAmmount)
		{
			Body = new List<List<T>>();
			ColumnsAmmount = columnsAmmount;
			RowsAmmount = rowsAmmount;
			T item = default;
			for (int i = 0; i < rowsAmmount; i++)
			{
				List<T> line = new List<T>();
				for (int j = 0; j < columnsAmmount; j++)
				{
					line.Add(item);
				}
				Body.Add(line);
			}

			return;
		}

		public void TransposeMatrix()
		{
			CheckIfBodyIsNotNull();

			List<List<T>> transposedBody = new List<List<T>>();

			for (int columnIndex = 0; columnIndex < ColumnsAmmount; columnIndex++)
			{
				List<T> line = new List<T>();
				for (int rowIndex = 0; rowIndex < RowsAmmount; rowIndex++)
				{
					line.Add(Body[rowIndex][columnIndex]);
				}
				transposedBody.Add(line);
			}

			Body = transposedBody;

			ColumnsAmmount = ColumnsAmmount ^ RowsAmmount;
			RowsAmmount = ColumnsAmmount ^ RowsAmmount;
			ColumnsAmmount = ColumnsAmmount ^ RowsAmmount;

			return;
		}

		public void SetValue(T value, int columnIndex, int rowIndex)
		{
			CheckIfBodyIsNotNull();
			CheckIfIndexIsNotOutOfRange(columnIndex, nameof(columnIndex), 0, ColumnsAmmount - 1);
			CheckIfIndexIsNotOutOfRange(rowIndex, nameof(rowIndex), 0, RowsAmmount - 1);

			Body[rowIndex][columnIndex] = value;

			return;
		}

		public void Print()
		{
			foreach (List<T> line in Body)
			{
				foreach (T cell in line)
				{
					Console.Write(cell + " ");
				}
				Console.WriteLine();
			}

			return;
		}

		public void AddColumn(List<T> column)
		{
			int columnLength = column.Count;

			CheckIfIndexIsNotOutOfRange(columnLength, nameof(columnLength), RowsAmmount, RowsAmmount);

			for (int rowIndex = 0; rowIndex < RowsAmmount; rowIndex++)
			{
				Body[rowIndex].Add(column[rowIndex]);
			}
			ColumnsAmmount += 1;

			return;
		}

		public void AddRow(List<T> row)
		{
			int rowLength = row.Count;

			CheckIfIndexIsNotOutOfRange(rowLength, nameof(rowLength), ColumnsAmmount, ColumnsAmmount);

			Body.Add(new List<T>(row));
			RowsAmmount += 1;

			return;
		}

		public void RemoveColumn(int columnIndex)
		{
			CheckIfIndexIsNotOutOfRange(columnIndex, nameof(columnIndex), 0, ColumnsAmmount);

			for (int rowIndex = 0; rowIndex < RowsAmmount; rowIndex++)
			{
				Body[rowIndex].RemoveAt(columnIndex);
			}
			ColumnsAmmount -= 1;

			return;
		}

		public void RemoveRow(int rowIndex)
		{
			CheckIfIndexIsNotOutOfRange(rowIndex, nameof(rowIndex), 0, RowsAmmount);

			Body.RemoveAt(rowIndex);
			RowsAmmount -= 1;

			return;
		}

		public List<T> GetColumn(int columnIndex)
		{
			CheckIfBodyIsNotNull();
			CheckIfIndexIsNotOutOfRange(columnIndex, nameof(columnIndex), 0, ColumnsAmmount - 1);

			List<T> column = new List<T>();
			foreach (List<T> line in Body)
			{
				column.Add(line[columnIndex]);
			}

			return column;
		}

		public List<T> GetRow(int rowIndex)
		{
			CheckIfBodyIsNotNull();
			CheckIfIndexIsNotOutOfRange(rowIndex, nameof(rowIndex), 0, RowsAmmount - 1);

			List<T> row;
			row = Body[rowIndex];

			return row;
		}

		void CheckIfIndexIsNotOutOfRange(int index, string indexName, int minValue, int maxValue)
		{
			if (index < minValue || index > maxValue)
			{
				ArgumentOutOfRangeException exception =
					ExceptionBuilder.BuildArgumentOutOfRangeException(
						index, indexName, 0, ColumnsAmmount - 1);
				throw exception;
			}

			return;
		}

		void CheckIfBodyIsNotNull()
		{
			if (Body == null)
			{
				ArgumentNullException exception =
					ExceptionBuilder.BuildArgumentNullException(Body, nameof(Body));
				throw exception;
			}

			return;
		}
	}
}