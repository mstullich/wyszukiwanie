using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StringSearch
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private void SearchBtn_Click(object sender, RoutedEventArgs e)
		{
			string[] lines = File.ReadAllLines("../../../Puchatek.txt");
			TextBox searchBox = (TextBox)FindName("SearchBox");
			string SearchPhrase = searchBox.Text;

			if (SearchPhrase != null && SearchPhrase != "")
			{

				// BruteSearch
				Stopwatch sw = new Stopwatch();
				sw.Start();
				int bruteSearch = BruteSearch(lines, SearchPhrase);
				sw.Stop();
				Label lbl = (Label)FindName("BruteLbl");
				lbl.Content = "Count: " + bruteSearch + ", Time (sec): " + sw.Elapsed.TotalSeconds;
			}
		}
		private int BruteSearch(string[] lines, string searchPhrase)
		{
			int count = 0;
			for (int i = 0; i < lines.Length; i++)
			{
				string l = lines[i];
				int r = l.IndexOf(searchPhrase);
				while (r > -1)
				{
					count++;
					l = l.Substring(r + searchPhrase.Length);
					r = l.IndexOf(searchPhrase);
				}
			}

			return count;
		}
	}
}