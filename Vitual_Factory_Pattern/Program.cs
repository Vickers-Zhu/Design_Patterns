using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPlatform.Interfaces;

namespace MultiPlatform
{
	class Program
	{
        private static void BuildUI(Factory factory) //... type of platform
		{
            IGrid grid = factory.GetGrid();
            IEnumerable<IButton> buttons;
            IEnumerable<ITextBox> textBoxes;
            grid.AddButton(factory.GetButton("BigPurpleButton"));
            grid.AddButton(factory.GetButton("SmallButton"));
            grid.AddButton(factory.GetButton("Baton"));
            grid.AddTextBox(factory.GetTextBox(""));
            grid.AddTextBox(factory.GetTextBox("EmptyTextBox"));
            grid.AddTextBox(factory.GetTextBox("xoBtxeT"));
            buttons = grid.GetButtons();
            textBoxes = grid.GetTextBoxes();
            foreach (IButton bt in buttons)
            {
                bt.ButtonPressed();
                bt.DrawContent();
            }
            if (textBoxes != null)
            {
                foreach (ITextBox tb in textBoxes)
                {
                    tb.DrawContent();
                }
            }
        }

		static void Main(string[] args)
		{
			Console.WriteLine("<---------------------iOS--------------------->");
            BuildUI(new IosFactory());
            Console.WriteLine("<---------------------Windows--------------------->");
            BuildUI(new WindowsFactory());
			Console.WriteLine("<---------------------Android--------------------->");
            BuildUI(new AndroidFactory());
            Console.ReadLine();
		}
	}
}
