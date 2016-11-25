using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Oko_bere
{
	class MainClass
	{	
		/// <summary>
		/// Hlavní metoda projektu
		/// </summary>
		/// <param name="args">V args na prvním míste je uloženo jmneo hráče</param>
		public static void Main(string[] args)
		{
			//definování proměních
			bool konec = true;
			char stisknuto;
			string hrac = null;
			Int32 hodnota = 0;
			Int32 hodnotaPC = 0;
			Karta karta = new Karta();

			//listi s kartamy jednotlivích hráču
			List<string> KartyHrac = new List<string>();
			List<string> KartyPc = new List<string>();

			//uvodní dialog
			Console.WriteLine("************************************");
			Console.WriteLine("*             Oko bere!            *");
			Console.WriteLine("************************************");
			Console.WriteLine("");

			//kontrola, jedná se o první hru (je žu vyplnění heslo od minule)
			if (args[0] == "null")
			{
				//dialog
				Console.Write("Chcete zobrazit pravidla (Y,N):");
				//je zmačknuto "y"
				if (Cti() == 'y')
				{
					//vypis pravidel hry
					Console.WriteLine("Jedná se o českou variantu vycházející z francouzského originálu karetní hry \"VINGT-ET-UN\". Z původního základu pochází také např. Blackjack a Baccarat. Právě v bodovém ohodnocení karet se pravidla různí. I karetní hra Oko (neboli jednadvacet či oko bere) má pravidla regionálně odlišná, někteří hráči např. počítají J,Q,K = 1, jiní zase J=1, Q=2, K=3.\n\nExistují i různé výklady postupu při vlastní hře. Dle prvního rozdá bankéř každému i sobě po dvou kartách. Hráči s výjimkou bankéře si karty prohlédnou a mohu požádat o další. Přitom uzavírají s bankéřem sázky. Pokud již žádný z hráčů další karty nechce, odkryje své i bankéř a případně si je rovněž doplní. Dle druhého výkladu bankéř nejprve stanoví výši sázky, zamíchá karty a každému rozdá reversem vzhůru po jedné, včetně sebe. Svou kartu otočí lícem vzhůru. Následně dle pořadí přidává hráči podle jeho přání vždy postupně jednu kartu po druhé (pokud o ni hráč požádá, např. výrazem \"DALŠÍ\", \"JEŠTĚ\", \"DÁVEJ\" apod.). Hráč musí uzavřít sázku, pokud součet hodnot jeho karet je deset a více. Snaží se přiblížit co nejvíce hodnotě 21, ale kdykoliv může ohlásit \"DOST\". Pokud riskuje příliš a jednadvacet přesáhne, musí ohlásit \"PŘES\" a platí bankéři sázku ihned. Když bankéř obslouží všechny hráče, může sám dobírat ke své vyložené kartě a snažit se také o jednadvacet. Následně každý hráč vypořádává svou sázku s bankéřem, nikoliv hráči mezi sebou navzájem.\n\nObecně platí, že vyšší součet vyhrává nad nižším. V případě shody vyhrává vždy bankéř. Pokud v průběhu hry obdrží hráč nebo bankéř dvě esa (jako dvě první karty), ohlásí \"21\". Již se dále o hru nezajímá, protože okamžitě inkasuje trojnásobek sázky.\n\n\n");
					//dialog
					Console.Write("Pravidlu zavřeš (N)");
					//čeká dokud není zmačknuto "n" ukončení
					while (Cti() != 'n')
					{
						//čekej 100milis
						Thread.Sleep(100);
					}
					//udělá 9 mezer pro pokračování ve hře
					for (int i = 0; i < 8; i++)
					{
						Console.WriteLine("");
					}

					//uvodní dialog
					Console.WriteLine("************************************");
					Console.WriteLine("*             Oko bere!            *");
					Console.WriteLine("************************************");
					Console.WriteLine("");

				}
				//funkce pro vyčištení řadku
				SmazVybraniRadek(Console.CursorTop);
				//dialog
				Console.Write("Zadejte svojí přezdívku:");
				//přečte jmeno hráče
				hrac = Console.ReadLine();
				//zapiče jmeno hráče do argumentu
				args[0] = hrac;
			}
			//fc. pro smazaní řadku
			SmazVybraniRadek(Console.CursorTop-1);
			//dialog
			Console.WriteLine("Vítej " + hrac);
			Console.WriteLine("");
			Console.Write("Rozdávám....");


			//rozdá karty PC
			for (int i = 0; i < 2; i++)
			{
				KartyPc.Add(karta.Davej());
				Thread.Sleep(1000);

			}
			//rozdá karty hrači
			for (int i = 0; i < 2; i++)
			{
				KartyHrac.Add(karta.Davej());
				Thread.Sleep(1000);
			}
			//smaže dialog "Rozdavam.."
			SmazVybraniRadek(Console.CursorTop);

			//Samotní ciklus hry
			while (konec == true)
			{
				//mezera
				Console.WriteLine();
				//reser hodnoty
				hodnota = 0;
				//dialog
				Console.Write("V ruce máš:");

				//vypočet hodnoty karet
				foreach (var item in KartyHrac)
				{
					Console.Write(item + " ");
					hodnota = hodnota + karta.Hodnota(item);


				}
				//když přesáhne 21 konec RIP
				if (hodnota >= 21)
				{
					break;
				}
				//dialog
				Console.WriteLine();
				Console.WriteLine("Což v čislech je: " + hodnota);
				Console.Write("Další kartu nebo končíš (D/K):");

				//přečte stisknutí symbol
				stisknuto = Cti();
				//je to "d"
				if (stisknuto == 'd' && konec != false)
				{
					//přidej hračovy kartu
					KartyHrac.Add(karta.Davej());

				}
				//je to "k"
				if (stisknuto == 'k' && konec != false)
				{
					//ukonči hru
					konec = false;
				}


			}

			//dodání karet "dilerovy??ted nevim česky"
			do
			{
				//odchicení problému
				try
				{
					//na zakladě hodnoty dodání karet bankeři
					foreach (var item in KartyPc)
					{
						hodnotaPC = hodnotaPC + karta.Hodnota(item);
						//když má mín jak 19 dej mu kartu
						if (hodnotaPC < 19)
						{
							KartyPc.Add(karta.Davej());
							break;
						}

					}
					//přepnutím se ukončí smička jelikož dankeř dostal maximum
					konec = false;
				}
				//problem -> zkuz to znova
				catch (Exception)
				{
					konec = true;
				}
				//reset hodnoty
				hodnotaPC = 0;
			} while (konec == true);

			//vypočet hodnoty karet PC
			foreach (var item in KartyPc)
			{
				//hodnotaPC se rovná hodnote všech karet v Listu "KartyPC"
				hodnotaPC = hodnotaPC + karta.Hodnota(item);
			}

			//vypis hodnot hráču
			Console.WriteLine();
			Console.WriteLine("Ti máš "+hodnota+" Počitač má "+hodnotaPC);
			Console.WriteLine();

			//jednotlivíé hlašky pro ruzné vyhry/prohry
			if (hodnota == 21)
			{
				
				Console.WriteLine("*******Je to tam, čistá VÍHRA*******");
			}
			else if (hodnota < 21 && hodnotaPC > 21)
			{

				Console.WriteLine("********Je to tam, :-> VÍHRA********");
			}
			else if (hodnota < 21 && hodnota > hodnotaPC)
			{

				Console.WriteLine("************Těsná VÍHRA*************");
			}
			else { 
				Console.WriteLine("† † † † † Tak to nevišlo :-(† † † † †");
			}

			//dialog
			Console.WriteLine();
			Console.Write("Chcete hrát znovu (Y,N):");

			//když chce hrát znovu
			if (Cti() == 'y')
			{
				
				Console.WriteLine("");
				//do args zapiše jmeno hrače
				args[0] = hrac;
				//znovu spustí program
				MainClass.Main(args);
			}





			}

		/// <summary>
		/// Cti znaky z konzole
		/// </summary>
		public static char Cti() { 
			Thread.Sleep(100);
			ConsoleKeyInfo vst = Console.ReadKey();
			return Char.ToLower(vst.KeyChar);
		}

		/// <summary>
		/// Smaze vybrani radek.
		/// </summary>
		/// <param name="cisloRadku">cislo ciskteneho radku</param>
		public static void SmazVybraniRadek(int cisloRadku)
		{
			Console.SetCursorPosition(0, cisloRadku);
			//Funkční pouze ve Win
			//Console.Write(new string(' ', Console.WindowWidth));
			for (int k = 0; k < 60; k++)
			{
				Console.Write(" ");
			}
			Console.SetCursorPosition(0, cisloRadku);
		}

	}
}
