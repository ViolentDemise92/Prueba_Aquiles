using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Management
{
    public class ComboManager
    {
		// Cuenta el numero de letras consecutivas de la cadena dada
		public static string CombinationLength(string cadena)
		{
			bool isOk = true;
			string errorMessage = ""; ;
			int bestCombo = 1;
			try
			{
				if (!string.IsNullOrWhiteSpace(cadena))
				{
					if (cadena.All(char.IsLetter))
					{
						int[] nLetra = new int[2];
						int combo = 1;

						for (int i = 0; i < cadena.Length - 1; i++)
						{

							nLetra = new int[] { (int)cadena[i], (int)cadena[i + 1] };
							if ((nLetra[0] == (nLetra[1] - 1)) || (nLetra[0] == (nLetra[1] + 1)))
							{
								combo++;
							}
							else
							{
								if (bestCombo < combo) bestCombo = combo;
								combo = 1;
							}
						}

						if (bestCombo < combo) bestCombo = combo;
					}
					else
					{
						isOk = false;
						errorMessage = "The string contains numbers or special caracters";
					}
				}
				else
				{
					errorMessage = "Empty string. Insert value.";
					isOk = false;
				}
			}
			catch (Exception e)
			{
				errorMessage = e.Message;
				isOk = false;
			}

			return isOk ? bestCombo.ToString() : errorMessage;
		}
	}
}
