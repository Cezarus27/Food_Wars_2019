namespace Projekt_JPWP
{
    public class Player
    {
        private int _score;

        public int Score { get => _score; set => _score = value; }
        public Player()
        {
            _score = 0;
        }

        public void ScoreCounter(int number, int minute, int second)
        {
            float scaler = 0;

            if ( minute >= 1 )
                scaler = 0.45f;

            _score = _score + 10 * number - second * 5 - (int)(10 * number * scaler);
        }
    }
}
