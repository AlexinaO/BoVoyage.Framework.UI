using System;

namespace BoVoyage.Framework.Metier
{
	public class MetierException : Exception
	{
		public MetierException(string message) : base(message)
		{
		}
	}
}