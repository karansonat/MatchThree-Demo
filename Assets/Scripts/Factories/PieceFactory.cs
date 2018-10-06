namespace MatchThree.Core
{
    public class PieceFactory
    {
        #region Singleton

        private static PieceFactory _instance = new PieceFactory();
        public static PieceFactory Instance
        {
            get { return _instance; }
        }

        static PieceFactory()
        {
        }

        private PieceFactory()
        {
        }

        #endregion //Singleton

        #region Factory Methods

        #endregion //Factory Methods
    }
}
