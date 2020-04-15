using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPlatform.Interfaces;

namespace MultiPlatform
{
    abstract class Factory
    {
        public abstract IGrid GetGrid();
        public abstract IButton GetButton(string content);
        public abstract ITextBox GetTextBox(string content);
    }
    class IosFactory : Factory
    {
        public override IGrid GetGrid()
        {
            return new IosGrid();
        }
        public override IButton GetButton(string content)
        {
            return new IosButton(content);
        }
        public override ITextBox GetTextBox(string content)
        {
            return new IosTextBox(content);
        }
    }
    class WindowsFactory : Factory
    {
        public override IGrid GetGrid()
        {
            return new WindowsGrid();
        }
        public override IButton GetButton(string content)
        {
            return new WindowsButton(content);
        }
        public override ITextBox GetTextBox(string content)
        {
            return new WindowsTextBox(content);
        }
    }
    class AndroidFactory : Factory
    {
        public override IGrid GetGrid()
        {
            return new AndroidGrid();
        }
        public override IButton GetButton(string content)
        {
            return new AndroidButton(content);
        }
        public override ITextBox GetTextBox(string content)
        {
            return new AndroidTextBox(content);
        }
    }
}
