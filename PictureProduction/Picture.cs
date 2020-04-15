using System;

namespace PictureProduction
{
    interface IPicture
    {
        string LeftFrame { get; }
        string RightFrame { get; }
        string Color { get; }
        string Text { get; }
        
        void Print();
    }
}
