namespace MatchThree.Core
{
    public class CellFactory
    {
        #region Singleton

        private static CellFactory _instance = new CellFactory();
        public static CellFactory Instance
        {
            get { return _instance; }
        }

        static CellFactory()
        {
        }

        private CellFactory()
        {
        }

        #endregion //Singleton

        #region Factory Methods

        #endregion //Factory Methods
    }
}
