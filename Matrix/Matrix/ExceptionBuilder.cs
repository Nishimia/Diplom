using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    public static class ExceptionBuilder
	{
		public static ArgumentNullException BuildArgumentNullException(object obj, string objName)
		{	
			string message = String.Format("{0} is null", objName);
			ArgumentNullException exception = new ArgumentNullException(objName, message);

			return exception;
		}

		public static ArgumentOutOfRangeException BuildArgumentOutOfRangeException(
			int value, string valueName, int minValue, int maxValue)
		{
			string message = String.Format("Unvalid {0}, need values between {1} and {2}",
				valueName, minValue, maxValue);
			ArgumentOutOfRangeException exception = 
				new ArgumentOutOfRangeException(valueName, value, message);

			return exception;
		}
    }
}
