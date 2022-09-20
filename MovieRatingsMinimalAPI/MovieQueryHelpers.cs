namespace MovieRatingsMinimalAPI
{
    public static class MovieQueryHelpers
    {
        public static string GetAllMovieRatings()
        {
            return "SELECT * FROM MovieRating ORDER BY Title;";
        }

        public static string InsertMovieRatings()
        {
            return @"
                INSERT INTO MovieRating (Created,CreatedBy,Modified,ModifiedBy,IsActive,Title,ReleaseDate,ImagePosterUrl,Rating) 
                VALUES (CURDATE(),'system',CURDATE(),'system',TRUE,@Title, @ReleaseDate,@ImagePosterUrl,@Rating);
            ";
        }
    }
}