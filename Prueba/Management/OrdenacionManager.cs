using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Management
{
    public class OrdenacionManager
    {
		// Devuelve si un concepto existe
		public static bool ConceptExist(String cadena)
		{
			return Enum.IsDefined(typeof(Concepto), cadena);
		}

		// Genera una cadena con formato con los datos procesados
		public static string OrdenacionPedido(string cadena)
		{
			List<Pedido> lPedidos = new List<Pedido>();
			bool isOk = true;
			string errorMessage = "";

			try
			{
				if (!string.IsNullOrWhiteSpace(cadena))
				{
					List<Pedido> lAngulares = new List<Pedido>();

					List<string> data = new List<string>();

					string[] separators = { @"\n", @"\r" };
					string[] words = cadena.Split(separators, StringSplitOptions.RemoveEmptyEntries);

					data.AddRange(words);

					if (data != null && data.Count > 0)
					{
						int i = 0;
						bool nObtained = false;

						while (isOk && i < data.Count)
						{
							if (!nObtained)
							{
								if (ConceptExist(data[i]))
								{
									lPedidos.Add(new Pedido()
									{
										concepto = (Concepto)Enum.Parse(typeof(Concepto), data[i]),
										reg = i
									});
								}
								else
								{
									if (int.TryParse(data[i], out _))
									{
										nObtained = true;
										lAngulares = lPedidos.Where(o => o.concepto == Concepto.ANGULAR).ToList();
									}
									else
									{
										isOk = false;
										errorMessage = "Wrong Format.";
									}
								}
							}
							if (nObtained && lPedidos.Count > 0)
							{
								int pos = (i % lPedidos.Count);
								int field = (i / lPedidos.Count);
								switch (field)
								{
									case 1:
										int n1;
										if (int.TryParse(data[i], out n1))
										{
											lPedidos[pos].pos = int.Parse(data[i]);
										}
										else
										{
											isOk = false;
										}
										break;
									case 2:
										lPedidos[pos].calidad = data[i];
										break;
									case 3:
										float n3;
										if (float.TryParse(data[i], out n3))
										{
											lPedidos[pos].med1 = float.Parse(data[i].Replace(',', '.'));
										}
										else
										{
											isOk = false;
										}
										break;
									case 4:
										int n4;
										if (int.TryParse(data[i], out n4))
										{
											lPedidos[pos].med2 = int.Parse(data[i]);
										}
										else
										{
											isOk = false;
										}

										break;
									case 5:
										double n5;
										if (double.TryParse(data[i], out n5))
										{
											lPedidos[pos].lon = double.Parse(data[i]);
										}
										else
										{
											isOk = false;
										}

										break;
									case 6:
										foreach (var angulares in lAngulares)
										{
											if (lPedidos[angulares.reg].med3 == null)
											{
												int n6;
												if (int.TryParse(data[i], out n6))
												{
													lPedidos[angulares.reg].med3 = int.Parse(data[i]);
												}
												else
												{
													isOk = false;
												}
												break;
											}
										}
										break;
								}

								if (!isOk)
								{
									errorMessage = "Wrong Format.";
								}
							}
							i++;
						}
					}
				}
				else
				{
					isOk = false;
					errorMessage = "Empty string. Insert value.";
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				errorMessage = e.Message;

			}

			return isOk ? SetFormatOrdenacion(lPedidos) : errorMessage;
		}

		// Dada una lista de clase pedido, genera una cadena con formato
		public static string SetFormatOrdenacion(List<Pedido> lPedidos)
		{
			string result = "";
			foreach (var pedido in lPedidos)
			{
				result += pedido.concepto + " " + pedido.med1 + "X" + pedido.med2 + (pedido.med3 != null ? "X" + pedido.med3 : "") + "X" + pedido.lon + " " + pedido.calidad + "\n";
			}
			return result;
		}
	}
}
