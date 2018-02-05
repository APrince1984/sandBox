namespace FootBallData.Tables.Commands
{
    public static class TitleCommands
    {
        public static Title SaveTitle(this Title title, FootBallContext context)
        {
            context.Titles.Add(title);
            context.SaveChanges();
            return title;
        }
    }
}
