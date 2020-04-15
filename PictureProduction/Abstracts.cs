namespace PictureProduction
{
    interface IMachine
    {
        // you can add required methods here
        void Handle(Order order, IPicture picture);
    }
}
