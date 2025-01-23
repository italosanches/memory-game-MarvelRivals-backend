namespace MemoryGame.Parameters
{
    public class ScoreQueryParameters
    {
        //public int UserQuantityScores { get; set; } 
        public int CardsQuantities { get; set; }

        public ScoreQueryParameters(int cardQuantites)
        {
            //UserQuantityScores = userQuantityScores > 10 ? 10 : userQuantityScores;
            CardsQuantities    = cardQuantites <= 0 ? 12 : cardQuantites;
        }
    }
}
