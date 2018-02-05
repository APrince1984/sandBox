namespace FootBallData.Tables.Commands
{
    public static class TitleCommands
    {
        public static Title SaveTitle(FootBallContext context, Title title)
        {
            context.Titles.Add(title);
            context.SaveChanges();
            return title;
        }
    }
}
