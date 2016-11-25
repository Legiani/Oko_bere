using System;
using System.Collections.Generic;
using System.Linq;

namespace Oko_bere
{
	/// <summary>
	/// Karta metody pro ukony s baličkem karet
	/// </summary>
	public class Karta
	{
		//listi barev baličku
		private List<string> srdce = new List<string>();
		private List<string> zaludy = new List<string>();
		private List<string> kule = new List<string>();
		private List<string> listy = new List<string>();
		private string vybrano;

		/// <summary>
		/// Iniclializaje baliček<naplní Listy jednotlivímy kartamy
		/// </summary>
		public Karta()
		{
			string[] set = new string[] { "VII", "VIII", "IX", "X", "Spodek", "Svršek", "Král", "Eso"};

			foreach (string karta in set)
			{
				srdce.Add(karta);
				zaludy.Add(karta);
				kule.Add(karta);
				listy.Add(karta);
			}
		}

		/// <summary>
		///Davej Nahodně vybere barvu a kartu
		/// </summary>
		public String Davej()
		{
			//nahodná barva
			int Barva = NoviRandom(3);

			if (Barva == 0)
			{
				try
				{
					//nahodná karta
					int misto = NoviRandom();
					vybrano = srdce.ElementAt(misto);
					srdce.RemoveAt(misto);
				}
				//když byla karta již použita, opakuje vyber
				catch (Exception)
				{
					Davej();
				}
			}
			else if (Barva == 1)
			{
				try
				{
					//nahodná karta
					int misto = NoviRandom();
					vybrano = zaludy.ElementAt(misto);
					zaludy.RemoveAt(misto);
				}
				//když byla karta již použita, opakuje vyber
				catch (Exception)
				{
					Davej();
				}

			}
			else if (Barva == 2)
			{
				try
				{
					//nahodná karta
					int misto = NoviRandom();
					vybrano = kule.ElementAt(misto);
					kule.RemoveAt(misto);
				}
				//když byla karta již použita, opakuje vyber
				catch (Exception)
				{
					Davej();
				}

			}
			else if (Barva == 3)
			{
				try
				{
					//nahodná karta
					int misto = NoviRandom();
					vybrano = listy.ElementAt(misto);
					listy.RemoveAt(misto);
				}
				//když byla karta již použita, opakuje vyber
				catch (Exception)
				{
					Davej();
				}
			}
			//vrátí kartu
			return vybrano;
		}

		//vratí hodnotu na zakladě volané karty
		public Int16 Hodnota(string karta) {

			switch (karta)
			{
				case "VII":
					return 7;

				case "VIII":
					return 8;

				case "IX":
					return 9;

				case "X":
					return 10;

				case "Spodek":
					return 1;

				case "Svršek":
					return 1;

				case "Král":
					return 2;

				case "Eso":
					return 11;

				default:
					return 0;

			}
		}

		//vylepšení funkce ranrom, vrací nahodné čislo na zaklade vstupních parametru
		public Int32 NoviRandom(int max = 7, int min = 0) {

			DateTime datumCas = DateTime.Now;

			Random rnd = new Random();

			int Cislo = (rnd.Next(min, datumCas.Second));

			while (Cislo >= max)
			{
				Cislo = Cislo % max++;
			}
			return Cislo;
		}
	}
}
